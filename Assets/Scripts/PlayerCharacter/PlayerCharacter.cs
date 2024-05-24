using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  �÷��̾� ĳ���� ��ü�� ��Ÿ���� ������Ʈ
/// </summary>
public sealed class PlayerCharacter : MonoBehaviour, IFallingObjectCollisionable
{
    [Header("# ĳ���� ���־� ������Ʈ")]
    public Transform m_CharacterVisual;

    /// <summary>
    /// �ʱ� Yaw ȸ������ ����ϱ� ���� ����
    /// </summary>
    private float _InitialYawRotation;


    /// <summary>
    /// �̵� ������Ʈ�� ��Ÿ���ϴ�.
    /// </summary>
    private PlayerCharacterMovement _Movement;

    private Animator _Animator;

    private void Awake()
    {
        // �÷��̾� ���� ��ü �ʱ�ȭ
        GameManager.instance.playerState.Initialize();

        // ���Ǵ� ������Ʈ�� �̸� ã���ϴ�.
        _Movement = GetComponent<PlayerCharacterMovement>();
        _Animator = GetComponentInChildren<Animator>();

        // �ʱ� Yaw ȸ������ ����մϴ�.
        _InitialYawRotation = m_CharacterVisual.eulerAngles.y;
    }

    private void Start()
    {
        //Debug.Log(PlayerUI.GetUI<GameUI>().gameObject.name);

        // ���� ���� �ݹ� ���
        GameManager.instance.playerState.onPlayerDead += CALLBACK_OnGameOver;
    }

    private void Update()
    {

        // ���� �� �Է�
        float horizontalAxisValue = HorizontalInput();

        // ���� �� �Է��� �߰��մϴ�.
        _Movement.AddHorizontalMovementInput(horizontalAxisValue);

        // X �࿡ ����� �ӷ��� ����ϴ�.
        float currentXSpeed = _Movement.GetCurrentXSpeed();

        // �ִϸ��̼� �Ķ���͸� �����մϴ�.
        UpdateAnimationParameters(currentXSpeed);

        // Yaw ȸ�� ����
        UpdateYawRotation(currentXSpeed);
    }

    /// <summary>
    /// ���� �� �Է�
    /// Ű���� �Է��� ���� �޼���
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
    /// �ִϸ��̼� �Ķ���͸� �����մϴ�.
    /// </summary>
    private void UpdateAnimationParameters(float xSpeed)
    {
        // �̵� ���¸� ��Ÿ���� ���� ����
        bool isMove = Mathf.Abs(xSpeed) > 0.01f;

        // �ִϸ��̼� ��ȯ�� �Ķ���� �� ����
        _Animator.SetBool("_IsMove", isMove);

    }

    /// <summary>
    /// Yaw ȸ���� �����մϴ�.
    /// </summary>
    /// <param name="xSpeed"></param>
    private void UpdateYawRotation(float xSpeed)
    {
        // �߰��� Yaw ȸ�����Դϴ�.
        float addYawAngle = Mathf.Clamp(xSpeed, -1.0f, 1.0f) * -90.0f;

        // ������ų ȸ������ ����մϴ�.
        Vector3 newRotation = Vector3.up * (_InitialYawRotation + addYawAngle);

        // ���� ȸ������ �����մϴ�.
        m_CharacterVisual.eulerAngles = newRotation;


    }

    /// <summary>
    /// ���� �����Ǿ��� ��� ȣ��Ǵ� �޼����Դϴ�.
    /// </summary>
    private void CALLBACK_OnGameOver()
    {
        // GoToMainSceneTimer() �ڷ�ƾ ����
        StartCoroutine(GoToMainSceneTimer());

        // �ְ� ���� ������ ����
        UpdateBestScoreData();
    }

    /// <summary>
    /// ���ξ� ��ȯ Ÿ�̸�
    /// </summary>
    /// <returns></returns>
    private IEnumerator GoToMainSceneTimer()
    {
        // 3�� ���
        yield return new WaitForSeconds(3.0f);

        // MainScene���� ��ȯ�մϴ�.
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene_Main");

    }

    /// <summary>
    /// �ְ� ���� �����͸� �����մϴ�.
    /// </summary>
    private void UpdateBestScoreData()
    {
        GameManager gameManager = GameManager.instance;
        PlayerState playerState = gameManager.playerState;

        // �ְ� ���� ����
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
