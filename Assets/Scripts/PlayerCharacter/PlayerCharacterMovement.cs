using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어 캐릭터 이동을 나타내기 위한 컴포넌트입니다.
/// </summary>
public sealed class PlayerCharacterMovement : MonoBehaviour
{
    [Header("# 이동 관련")]
    public float m_Speed = 10.0f;

    /// <summary>
    /// 캐릭터 이동 기능을 제공하는 CharacterController 컴포넌트입니다.
    /// </summary>
    private CharacterController _CharacterController;

    private void Awake()
    {
        _CharacterController = GetComponent<CharacterController>();
    }


    /// <summary>
    /// 수평 축 입력값을 기록하기 위한 필드입니다.
    /// </summary>
    private float _HorizontalAxisValue;

    private void Update()
    {
        // 이동
        Movement();
    }

    /// <summary>
    /// 이동을 수행합니다.
    /// </summary>
    // 이동
    private void Movement()
    {
        //transform.position += Vector3.right * _HorizontalAxisValue * m_Speed * Time.deltaTime;

        // 입력된 축 값만큼 이동시킵니다.
        _CharacterController.SimpleMove(Vector3.right * _HorizontalAxisValue * m_Speed);
        // SimpleMove : 점프 없는 X/Z 축으로의 간단한 이동을 수행하는 메서드입니다.
        // 내부에서 Time.deltaTime 를 연산시키기 때문에 속도만 전달하여 사용합니다.
        // 기본적으로 프로젝트에 설정된 중력값을 Y축 속도에 적용시키게 됩니다.

        // Move : 사용자가 이동을 제어하기 위하여 사용되는 메서드입니다.
        // 속도와 Time.deltaTime 을 직접 연산한 결과를 메서드 인수로 전달합니다.


        _HorizontalAxisValue = 0.0f;
    }

    /// <summary>
    /// 가로 축 이동 입력을 추가합니다.
    /// </summary>
    /// <param name="newAxisValue">입력 축 값을 전달합니다.</param>
    public void AddHorizontalMovementInput(float newAxisValue)
    {
        _HorizontalAxisValue += newAxisValue;
        _HorizontalAxisValue = Mathf.Clamp(_HorizontalAxisValue, -1.0f, 1.0f);
    }



}
