using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Falldown ������Ʈ ������ ��� �����صα� ����
/// ScriptableObject ���� ���¸� ��Ÿ���� Ŭ�����Դϴ�.
/// ScriptableObject : ���� ���� �����͸� ����صα� ���� �����Դϴ�.
/// ���� �ǽð����� ��ȭ�ϴ� ��ü�� ������ ����ϴ� ���� �ƴ�,
/// ������ ������ �����ϱ� ���� ���˴ϴ�.
/// 
/// ���ӿ��� ���� ������ �̸� �����صΰ� �ʿ��� ��
/// �������� �ҷ��� ������ �� �ֵ��� �ϱ� ���Ͽ� ���Ǵ� �����Դϴ�.
/// 
/// ���� ĳ������ ������ �����ϱ� ���� �뵵 X
/// 
/// ĳ������ �⺻ ���� ���� O
/// ���������� �����ϴ� �� ĳ������ ���� O
/// 
/// </summary>

[CreateAssetMenu(
    fileName = "FalldownObjectInfo",
    menuName = "ScriptableObject/CreateFalldownObjectInfo",
    order = int.MinValue
    )]
public sealed class FalldownObjectScriptableObject : ScriptableObject
{
    [Header("# Falldown ������Ʈ ����")]
    public List<FalldownObjectInfo> m_FalldownObjectInfos;


    /// <summary>
    /// ������ Ÿ���� ������ ������Ʈ ������ ����ϴ�.
    /// </summary>
    /// <param name="type">����� �ϴ� ������Ʈ Ÿ���� �����մϴ�.</param>
    /// <returns></returns>
    public FalldownObjectInfo GetRandomObjectInfo(FalldownObjectType type)
    {
        // �Ű� ���� type �� ��ġ�ϴ� Ÿ���� ������Ʈ ������ ����Ʈ�� ��� �����մϴ�.
        List<FalldownObjectInfo> findedFalldownObjectInfos = 
        m_FalldownObjectInfos.FindAll(elem => elem.m_Type == type);

        // ����Ʈ ����� ������ ����� �ε����� ����ϴ�.
        int randomIndex = Random.Range(0, m_FalldownObjectInfos.Count);

        // ���� ���(������Ʈ ����)�� ��ȯ�մϴ�.
        return findedFalldownObjectInfos[randomIndex];
    }

    /// <summary>
    /// ������ Ÿ���� ������ ������Ʈ ������ ��ȯ�ϱ� ���� �ε���
    /// </summary>
    /// <param name="type">����� �ϴ� ������Ʈ Ÿ���� �����մϴ�.</param>
    /// <returns></returns>
    public FalldownObjectInfo this[FalldownObjectType type] => 
        GetRandomObjectInfo(type);

}

/// <summary>
/// �ϳ��� Falldown ������Ʈ ������ ��Ÿ���� ���� Ŭ����
/// </summary>
/// 
[System.Serializable]
/*
 * ���� ����ȭ�� ���� ��Ʈ����Ʈ
 * ����ȭ��?
 * ��ü�� ���¸� ���Ŀ� �����ϰų� ������ �� �ִ� �������� ��ȯ�ϴ� ���μ����Դϴ�.
 * ����Ƽ���� �����̳� �Ӽ��� ����ȭ ��Ű�� ��� �����Ϳ��� �����͸� �����ŵ�ϴ�.
 * 
 * Serializable : ������ Ŭ������ ����ü�� ����ȭ ��Ű�� ��Ʈ����Ʈ�Դϴ�.
 * Ư���� ������ ������ ����, �����ϱ� ���Ͽ� ���Ǹ�,
 * ����Ƽ�� �ν����� â������ �⺻������ ����ȭ�� ���ĵ鸸 ǥ�õ˴ϴ�.
 * 
 * SerializeField : ��ũ��Ʈ ����ȭ�� ���� ��Ʈ����Ʈ�Դϴ�.
 * �⺻������ public �Ӽ��� ����ȭ������, public �� ������ ������ �Ӽ��� ����ȭ ��Ű�� ���
 * �Ӽ����� �ش� ��Ʈ����Ʈ�� �ۼ��ؾ� �մϴ�.
 * private, protected �� �ν����Ϳ� ������ ��Ű�� ���� ��� ���
 */
public sealed class FalldownObjectInfo
{
    [Header("# ������Ʈ Ÿ��")]
    public FalldownObjectType m_Type;

    [Header("# ������Ʈ ������")]
    public FalldownObjectBase m_FalldownObjectPrefab;

    [Header("# ���ط�")]
    public float m_HitDamage;

    [Header("# ü�� ȸ����")]
    public float m_RecoverageHp;

    [Header("# ���� ��ȭ��")]
    public float m_AddScore;
}


