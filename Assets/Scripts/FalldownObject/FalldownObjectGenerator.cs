using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  �������� ������Ʈ �������Դϴ�.
/// </summary>
public sealed class FalldownObjectGenerator : MonoBehaviour
{
    [Header("# ���� ����")]
    public Vector3 m_AreaMin;
    public Vector3 m_AreaMax;



    /// <summary>
    /// ������
    /// ������Ʈ�� ���¸� �����ص� ������ �ǹ��մϴ�.
    /// �����ص� ���¸� ���� �����Ͽ� ���忡 ������Ʈ�� ������ų �� ������,
    /// �������� ����ϴ� ��� ���ϰ� ���� ������ ������Ʈ�� ���� �� ������ �� �ֽ��ϴ�.
    /// </summary>
    public FalldownObjectBase m_FalldownObjectPrefab;

    /// <summary>
    /// ���������� ������ �ð��� ����մϴ�.
    /// </summary>
    private float _LastGenerateTime;

    /// <summary>
    /// ������ ���� ��ġ�� ��ȯ�մϴ�.
    /// </summary>
    public Vector3 randomGenPosition => new Vector3(
                Random.Range(m_AreaMin.x, m_AreaMax.x), m_AreaMax.y, 0.0f);

    private void Start()
    {
        // �Ź� ������ ����� ���� �� �ֵ��� ���� �õ带 �����մϴ�.
        Random.InitState(17);
    }

    private void Update()
    {
        // ���������� ������ �ð����� 1�ʰ� ���� ���
        if(_LastGenerateTime + 1 < Time.time)
        {
            


            // ������Ʈ�� ���� �����մϴ�.
            FalldownObjectBase generatedFalldownObject = Instantiate(m_FalldownObjectPrefab);
            // ������Ʈ�� ���� �����Ͽ� ��ȯ�մϴ�.
            // ��ȯ�Ǵ� �������� ���´� �Ű� ������ ���¿� �����մϴ�.
            // ���� ������Ʈ�� �����Ͽ� ���� ������ �����ϴ� ���
            // �ش� ������Ʈ�� �����ϴ� ������Ʈ�� ���� �����ϰ�, �߰��Ǿ��ִ� ������Ʈ�� ��ȯ�մϴ�.

            //������ ������Ʈ�� ������ �ʱ�ȭ�մϴ�.
            generatedFalldownObject.Initialize();

            // ������ ������Ʈ�� ��ġ�� �����ϰ� �����մϴ�.
            generatedFalldownObject.transform.position = randomGenPosition;

            // ���������� ������ �ð��� �����մϴ�.
            _LastGenerateTime = Time.time;
        }

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
