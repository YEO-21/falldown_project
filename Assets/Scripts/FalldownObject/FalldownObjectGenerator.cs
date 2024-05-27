using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  �������� ������Ʈ �������Դϴ�.
/// </summary>
public sealed class FalldownObjectGenerator : MonoBehaviour
{
    [Header("# ������ ���� ���� ����")]
    public GeneratorSectionInfoScriptableObject m_GeneratorDelayScriptableObject;


    [Header("# ������Ʈ ����")]
    public FalldownObjectScriptableObject m_FalldownObjectScriptableObject;

    [Header("# �÷��̾� ĳ���� ��ü")]
    public PlayerCharacter m_PlayerCharacter;
    
    [Header("# ���� ����")]
    public Vector3 m_AreaMin;
    public Vector3 m_AreaMax;

    /// <summary>
    /// ������Ʈ ���� ��ƾ
    /// </summary>
    private Coroutine _GeneratorRoutine;

    /// <summary>
    /// ���� ���� �������� �����ص� ����Ʈ
    /// </summary>
    private List<int> _SectionStartScores;


    /// <summary>
    /// ���� ����� ���� �ε����Դϴ�.
    /// </summary>
    private int _SectionIndex;



    /// <summary>
    /// ������ ���� ��ġ�� ��ȯ�մϴ�.
    /// </summary>
    public Vector3 randomGenPosition => new Vector3(
                Random.Range(m_AreaMin.x, m_AreaMax.x), m_AreaMax.y, 0.0f);

    private void Awake()
    {
        // ���� ���� �ε����� �ʱ�ȭ�մϴ�.
        _SectionIndex = 0;

        // ���� ���� �������� ����ϴ�.
        _SectionStartScores = m_GeneratorDelayScriptableObject.GetSectionStartScores();
    }

    private void Start()
    {
        // ���� ���� �ݹ� ���
        GameManager.instance.playerState.onScoreChanged += CALLBACK_OnScoreChanged;

        // ���� ���� �ݹ� ���
        GameManager.instance.playerState.onPlayerDead += CALLBACK_OnGameOver;


        // �Ź� ������ ����� ���� �� �ֵ��� ���� �õ带 �����մϴ�.
        Random.InitState(17);

        // Falldown ������Ʈ ���� ��ƾ�� �����մϴ�.
        _GeneratorRoutine = StartCoroutine(GenerateFalldownObject());
    }

  

    /// <summary>
    /// Falldown ������Ʈ�� �����մϴ�.
    /// </summary>
    private IEnumerator GenerateFalldownObject()
    {
        while(true)
        {
            // ���� ���� ������ ����ϴ�.
            GeneratorSectionInfo currentSectionInfo =
                m_GeneratorDelayScriptableObject[_SectionIndex];

            // ���� ������ �����̸� ����ϴ�.
            float currentSectionDelay = currentSectionInfo.m_GeneratingDelay;

            // ���� ������ �����̸�ŭ ���
            yield return new WaitForSeconds(currentSectionDelay);

            // ����⸦ ������ų Ȯ���� ��Ÿ���ϴ�.
            int fishGenPercentage = currentSectionInfo.m_FishGeneratorPercentage;

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
        generatedFalldownObject.Initialize(m_PlayerCharacter,
            info.m_HitDamage, info.m_RecoverageHp, info.m_AddScore);

        // ������ ������Ʈ�� ��ġ�� �����ϰ� �����մϴ�.
        generatedFalldownObject.transform.position = randomGenPosition;
    }

    /// <summary>
    /// ���� ���� �� ȣ��Ǵ� �޼����Դϴ�.
    /// PlayerState ��ü�� onScoreChanged �̺�Ʈ�� ���ε��˴ϴ�.
    /// </summary>
    /// <param name="score"></param>
    private void CALLBACK_OnScoreChanged(float score)
    {
        // ���� ������ �����ϴ� ��쿡�� Ȯ���մϴ�.
        if(_SectionStartScores.Count > _SectionIndex + 1)
        {
            // ���� ���� ���� ������ ����ϴ�.
            int nextSectionStartScore = _SectionStartScores[_SectionIndex + 1];

            // ���� ���� ������ ���� ���
            if(nextSectionStartScore <= score)
            {
                // ���� �������� �����մϴ�.
                ++_SectionIndex;
            }
            Debug.Log("_SectionInde = " + _SectionIndex);
        }

    }

    /// <summary>
    ///  ���� ���� �� ȣ��Ǵ� �޼����Դϴ�.
    ///  PlayerState ��ü�� onPlayerDead �̺�Ʈ�� ���ε��˴ϴ�.
    /// </summary>
    private void CALLBACK_OnGameOver()
    {
        // ���� ��ƾ ����
        if(_GeneratorRoutine != null)
        {
            StopCoroutine(_GeneratorRoutine);
            _GeneratorRoutine = null;
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
