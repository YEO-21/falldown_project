using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾� ĳ���� �̵��� ��Ÿ���� ���� ������Ʈ�Դϴ�.
/// </summary>
public sealed class PlayerCharacterMovement : MonoBehaviour
{
    [Header("# �̵� ����")]
    public float m_Speed = 10.0f;

    /// <summary>
    /// ĳ���� �̵� ����� �����ϴ� CharacterController ������Ʈ�Դϴ�.
    /// </summary>
    private CharacterController _CharacterController;

    private void Awake()
    {
        _CharacterController = GetComponent<CharacterController>();
    }


    /// <summary>
    /// ���� �� �Է°��� ����ϱ� ���� �ʵ��Դϴ�.
    /// </summary>
    private float _HorizontalAxisValue;

    private void Update()
    {
        // �̵�
        Movement();
    }

    /// <summary>
    /// �̵��� �����մϴ�.
    /// </summary>
    // �̵�
    private void Movement()
    {
        //transform.position += Vector3.right * _HorizontalAxisValue * m_Speed * Time.deltaTime;

        // �Էµ� �� ����ŭ �̵���ŵ�ϴ�.
        _CharacterController.SimpleMove(Vector3.right * _HorizontalAxisValue * m_Speed);
        // SimpleMove : ���� ���� X/Z �������� ������ �̵��� �����ϴ� �޼����Դϴ�.
        // ���ο��� Time.deltaTime �� �����Ű�� ������ �ӵ��� �����Ͽ� ����մϴ�.
        // �⺻������ ������Ʈ�� ������ �߷°��� Y�� �ӵ��� �����Ű�� �˴ϴ�.

        // Move : ����ڰ� �̵��� �����ϱ� ���Ͽ� ���Ǵ� �޼����Դϴ�.
        // �ӵ��� Time.deltaTime �� ���� ������ ����� �޼��� �μ��� �����մϴ�.


        _HorizontalAxisValue = 0.0f;
    }

    /// <summary>
    /// ���� �� �̵� �Է��� �߰��մϴ�.
    /// </summary>
    /// <param name="newAxisValue">�Է� �� ���� �����մϴ�.</param>
    public void AddHorizontalMovementInput(float newAxisValue)
    {
        _HorizontalAxisValue += newAxisValue;
        _HorizontalAxisValue = Mathf.Clamp(_HorizontalAxisValue, -1.0f, 1.0f);
    }



}
