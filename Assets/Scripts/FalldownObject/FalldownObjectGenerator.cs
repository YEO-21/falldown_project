using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  �������� ������Ʈ �������Դϴ�.
/// </summary>
public sealed class FalldownObjectGenerator : MonoBehaviour
{
    [Header("# ������Ʈ ����")]
    public FalldownObjectScriptableObject m_FalldownObjectScriptableObject;

    [Header("# �÷��̾� ĳ���� ��ü")]
    public PlayerCharacter m_PlayerCharacter;
    
    [Header("# ���� ����")]
    public Vector3 m_AreaMin;
    public Vector3 m_AreaMax;


   

    /// <summary>
    /// ������ ���� ��ġ�� ��ȯ�մϴ�.
    /// </summary>
    public Vector3 randomGenPosition => new Vector3(
                Random.Range(m_AreaMin.x, m_AreaMax.x), m_AreaMax.y, 0.0f);

    private void Start()
    {
        // �Ź� ������ ����� ���� �� �ֵ��� ���� �õ带 �����մϴ�.
        Random.InitState(17);

        // Falldown ������Ʈ ���� ��ƾ�� �����մϴ�.
        StartCoroutine(GenerateFalldownObject());
    }


    /// <summary>
    /// Falldown ������Ʈ�� �����մϴ�.
    /// </summary>
    private IEnumerator GenerateFalldownObject()
    {
        while(true)
        {
            // 1�� ���
            yield return new WaitForSeconds(1.0f);

            // ����⸦ ������ų Ȯ���� ��Ÿ���ϴ�.
            int fishGenPercentage = 50;

            // fishGenPercentage �� ���ǵ� Ȯ���� ���� ������ų ������Ʈ Ÿ���� �����մϴ�.
            FalldownObjectType genObjectType = (Random.Range(1, 101) < fishGenPercentage) ?
                FalldownObjectType.Fish :
                FalldownObjectType.Trash;

            // ������ų ������ ������Ʈ ������ ����ϴ�.
            FalldownObjectInfo info = m_FalldownObjectScriptableObject[genObjectType];
            Debug.Log(info.m_FalldownObjectPrefab);

            SpawnFalldownObjectFromInfo(info);

        }
        
    }

    /// <summary>
    /// ���� ������ ������� ������Ʈ�� �����մϴ�.
    /// </summary>
    /// <param name="info">������ų ������Ʈ ������ �����մϴ�.</param>
    private void SpawnFalldownObjectFromInfo(FalldownObjectInfo info)
    {
        // ������Ʈ�� ���� �����մϴ�.
        FalldownObjectBase generatedFalldownObject = Instantiate(info.m_FalldownObjectPrefab);

        // ������Ʈ�� ���� �����Ͽ� ��ȯ�մϴ�.
        // ��ȯ�Ǵ� �������� ���´� �Ű� ������ ���¿� �����մϴ�.
        // ���� ������Ʈ�� �����Ͽ� ���� ������ �����ϴ� ���
        // �ش� ������Ʈ�� �����ϴ� ������Ʈ�� ���� �����ϰ�, �߰��Ǿ��ִ� ������Ʈ�� ��ȯ�մϴ�.

        //������ ������Ʈ�� ������ �ʱ�ȭ�մϴ�.
        generatedFalldownObject.Initialize(m_PlayerCharacter);

        // ������ ������Ʈ�� ��ġ�� �����ϰ� �����մϴ�.
        generatedFalldownObject.transform.position = randomGenPosition;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 areaSize = m_AreaMax - m_AreaMin;
        Vector3 areaCenter = m_AreaMin + (areaSize * 0.5f);

        Gizmos.DrawWireCube(areaCenter, areaSize);  
    

    }
#endif

}
