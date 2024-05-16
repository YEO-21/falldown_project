using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Falldown ������Ʈ Ÿ���� ��Ÿ���� ���� ���� �����Դϴ�.
/// </summary>
public enum FalldownObjectType : sbyte
{
    Trash,
    Fish
}


/// <summary>
/// �������� ������Ʈ�� ��Ÿ���� ���� Ŭ�����Դϴ�.
/// �� Ŭ������ ������� ����� Ŭ������ ������, ����� ���� ���ǵ��� ����Ǿ����ϴ�.
/// </summary>
public abstract class FalldownObjectBase : MonoBehaviour
{
    /// <summary>
    /// ĳ���Ϳ� �浹 �� ĳ���Ϳ��� ������ ���ط��� ��Ÿ���ϴ�.
    /// </summary>
    protected float m_HitDamage;

    /// <summary>
    /// ĳ���Ϳ� �浹 �� ĳ���Ͱ� ȸ���Ǵ� ��ġ�� ��Ÿ���ϴ�.
    /// </summary>
    protected float m_RecoveryHp;

    /// <summary>
    /// ĳ���Ϳ� �浹 �� ��ȭ��ų ������ ��Ÿ���ϴ�.
    /// </summary>
    private float _AddScore;

    /// <summary>
    /// ������ �ð��� ����� �����Դϴ�.
    /// </summary>
    private float _GeneratedTime;

    /// <summary>
    /// �� ������Ʈ�� �浹 ������ ��ü�� ����� ��Ÿ���ϴ�.
    /// </summary>
    protected IFallingObjectCollisionable collisionableObject { get; private set; }


    protected virtual void Update()
    {
        // ���� Ÿ�̸�
        DestroyTimer();
    }

    /// <summary>
    /// ������Ʈ ���� Ÿ�̸�
    /// </summary>
    private void DestroyTimer()
    {
        // ������ �� 5�ʰ� ������ �� ������Ʈ�� �����մϴ�.
        if(_GeneratedTime + 5.0f < Time.time)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // OnTriggerEnter : ��ħ�� ���۵� �� ȣ��˴ϴ�.
        // OnTriggerStay : ��ħ�� �������� �� ��� ȣ��˴ϴ�.
        // OnTriggerExit : ��ħ�� ������ �� ȣ��˴ϴ�.
        // OnCollisionExit : �������� �浹�� ���۵� �� ȣ��˴ϴ�.
        // OnCollisionExit : �������� �浹�� �������� �� ��� ȣ��˴ϴ�.
        // OnCollisionExit : �������� �浹�� ������ ��� ȣ��˴ϴ�.
        //
        // �� �浹ü�� �ϳ��� Rigidbody Component�� �߰��Ǿ� �־�� �� �̺�Ʈ �Լ��� ����˴ϴ�. 

        // Player ��� Tag �� ���� ������Ʈ�� ������ ���
        //if (other.tag == "Player") ;
        //if (other.tag.CompareTo("Player") == 0) ;
        if (other.CompareTag("Player"))
        {
            OnCollisionableObjectDetected();
        }
    }

    /// <summary>
    /// ������Ʈ ������ �ʱ�ȭ�մϴ�.
    /// </summary>
    /// <param name="collisionableObject">�浹 ���� ��ü�� �����մϴ�.</param>
    public void Initialize(IFallingObjectCollisionable collisionableObject)
    {
        this.collisionableObject = collisionableObject;

        // ���� �ð��� ����մϴ�.
        _GeneratedTime = Time.time;
    }

    /// <summary>
    /// �� ������Ʈ�� �浹 ������ ��ü�� ������ ��� ȣ��˴ϴ�.
    /// </summary>
    protected virtual void OnCollisionableObjectDetected()
    {
        // ���� ����
        collisionableObject.AddScore(_AddScore);

        // ������Ʈ ����
        Destroy(gameObject);
    }
}
