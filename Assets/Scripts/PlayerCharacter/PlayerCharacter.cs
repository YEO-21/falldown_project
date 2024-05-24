using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  플레이어 캐릭터 객체를 나타내는 컴포넌트
/// </summary>
public sealed class PlayerCharacter : MonoBehaviour, IFallingObjectCollisionable
{
    [Header("# 캐릭터 비주얼 오브젝트")]
    public Transform m_CharacterVisual;

    /// <summary>
    /// 초기 Yaw 회전값을 기록하기 위한 변수
    /// </summary>
    private float _InitialYawRotation;


    /// <summary>
    /// 이동 컴포넌트를 나타냅니다.
    /// </summary>
    private PlayerCharacterMovement _Movement;

    private Animator _Animator;

    private void Awake()
    {
        // 플레이어 상태 객체 초기화
        GameManager.instance.playerState.Initialize();

        // 사용되는 컴포넌트를 미리 찾습니다.
        _Movement = GetComponent<PlayerCharacterMovement>();
        _Animator = GetComponentInChildren<Animator>();

        // 초기 Yaw 회전값을 기록합니다.
        _InitialYawRotation = m_CharacterVisual.eulerAngles.y;
    }

    private void Start()
    {
        //Debug.Log(PlayerUI.GetUI<GameUI>().gameObject.name);

        // 게임 오버 콜백 등록
        GameManager.instance.playerState.onPlayerDead += CALLBACK_OnGameOver;
    }

    private void Update()
    {

        // 수평 축 입력
        float horizontalAxisValue = HorizontalInput();

        // 수평 축 입력을 추가합니다.
        _Movement.AddHorizontalMovementInput(horizontalAxisValue);

        // X 축에 적용된 속력을 얻습니다.
        float currentXSpeed = _Movement.GetCurrentXSpeed();

        // 애니메이션 파라미터를 갱신합니다.
        UpdateAnimationParameters(currentXSpeed);

        // Yaw 회전 갱신
        UpdateYawRotation(currentXSpeed);
    }

    /// <summary>
    /// 수평 축 입력
    /// 키보드 입력을 위한 메서드
    /// </summary>
    /// <returns></returns>
    private float HorizontalInput()
    {
        float horizontalAxisValue = 0.0f;

        if (Input.GetKey(KeyCode.LeftArrow)) horizontalAxisValue -= 1.0f;
        else if (Input.GetKey(KeyCode.RightArrow)) horizontalAxisValue += 1.0f;

        return horizontalAxisValue;
    }

    /// <summary>
    /// 애니메이션 파라미터를 갱신합니다.
    /// </summary>
    private void UpdateAnimationParameters(float xSpeed)
    {
        // 이동 상태를 나타내기 위한 변수
        bool isMove = Mathf.Abs(xSpeed) > 0.01f;

        // 애니메이션 전환용 파라미터 값 설정
        _Animator.SetBool("_IsMove", isMove);

    }

    /// <summary>
    /// Yaw 회전을 갱신합니다.
    /// </summary>
    /// <param name="xSpeed"></param>
    private void UpdateYawRotation(float xSpeed)
    {
        // 추가될 Yaw 회전값입니다.
        float addYawAngle = Mathf.Clamp(xSpeed, -1.0f, 1.0f) * -90.0f;

        // 설정시킬 회전값을 계산합니다.
        Vector3 newRotation = Vector3.up * (_InitialYawRotation + addYawAngle);

        // 계산된 회전값을 적용합니다.
        m_CharacterVisual.eulerAngles = newRotation;


    }

    /// <summary>
    /// 게임 오버되었을 경우 호출되는 메서드입니다.
    /// </summary>
    private void CALLBACK_OnGameOver()
    {
        // GoToMainSceneTimer() 코루틴 시작
        StartCoroutine(GoToMainSceneTimer());

        // 최고 점수 데이터 갱신
        UpdateBestScoreData();
    }

    /// <summary>
    /// 메인씬 전환 타이머
    /// </summary>
    /// <returns></returns>
    private IEnumerator GoToMainSceneTimer()
    {
        // 3초 대기
        yield return new WaitForSeconds(3.0f);

        // MainScene으로 전환합니다.
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene_Main");

    }

    /// <summary>
    /// 최고 점수 데이터를 갱신합니다.
    /// </summary>
    private void UpdateBestScoreData()
    {
        GameManager gameManager = GameManager.instance;
        PlayerState playerState = gameManager.playerState;

        // 최고 점수 갱신
        gameManager.scoreFilerReadWriter.UpdateBestScore(playerState.score);
    }


    void IFallingObjectCollisionable.OnTrashObjectDetected(float damage)
    {
        GameManager.instance.playerState.AddHp(-damage);
    }

    void IFallingObjectCollisionable.OnFishObjectDetected(float recoveryHpValue)
    {
        GameManager.instance.playerState.AddHp(recoveryHpValue);

    }

    void IFallingObjectCollisionable.AddScore(float score)
    {
        GameManager.instance.playerState.AddScore(score);
    }

    
}
