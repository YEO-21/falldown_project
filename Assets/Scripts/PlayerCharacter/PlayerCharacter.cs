using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  플레이어 캐릭터 객체를 나타내는 컴포넌트
/// </summary>
public sealed class PlayerCharacter : MonoBehaviour
{
    /// <summary>
    /// 이동 컴포넌트를 나타냅니다.
    /// </summary>
    private PlayerCharacterMovement _Movement;

    private void Awake()
    {
        // 사용되는 컴포넌트를 미리 찾습니다.
        _Movement = GetComponent<PlayerCharacterMovement>();
    }


    private void Update()
    {
        // 수평 축 입력
        float horizontalAxisValue = HorizontalInput();

        // 수평 축 입력을 추가합니다.
        _Movement.AddHorizontalMovementInput(horizontalAxisValue);
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
}
