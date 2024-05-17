using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  �÷��̾� ĳ���� ��ü�� ��Ÿ���� ������Ʈ
/// </summary>
public sealed class PlayerCharacter : MonoBehaviour, IFallingObjectCollisionable
{
    /// <summary>
    /// �̵� ������Ʈ�� ��Ÿ���ϴ�.
    /// </summary>
    private PlayerCharacterMovement _Movement;

    private void Awake()
    {
        // �÷��̾� ���� ��ü �ʱ�ȭ
        GameManager.instance.playerState.Initialize();

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
