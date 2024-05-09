using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  �÷��̾� ĳ���� ��ü�� ��Ÿ���� ������Ʈ
/// </summary>
public sealed class PlayerCharacter : MonoBehaviour
{
    /// <summary>
    /// �̵� ������Ʈ�� ��Ÿ���ϴ�.
    /// </summary>
    private PlayerCharacterMovement _Movement;

    private void Awake()
    {
        // ���Ǵ� ������Ʈ�� �̸� ã���ϴ�.
        _Movement = GetComponent<PlayerCharacterMovement>();
    }


    private void Update()
    {
        // ���� �� �Է�
        float horizontalAxisValue = HorizontalInput();

        // ���� �� �Է��� �߰��մϴ�.
        _Movement.AddHorizontalMovementInput(horizontalAxisValue);
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
}
