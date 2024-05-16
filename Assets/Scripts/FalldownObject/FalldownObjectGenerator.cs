using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  떨어지는 오브젝트 생성기입니다.
/// </summary>
public sealed class FalldownObjectGenerator : MonoBehaviour
{
    [Header("# 오브젝트 정보")]
    public FalldownObjectScriptableObject m_FalldownObjectScriptableObject;

    [Header("# 플레이어 캐릭터 객체")]
    public PlayerCharacter m_PlayerCharacter;
    
    [Header("# 생성 영역")]
    public Vector3 m_AreaMin;
    public Vector3 m_AreaMax;


   

    /// <summary>
    /// 랜덤한 생성 위치를 반환합니다.
    /// </summary>
    public Vector3 randomGenPosition => new Vector3(
                Random.Range(m_AreaMin.x, m_AreaMax.x), m_AreaMax.y, 0.0f);

    private void Start()
    {
        // 매번 동일한 결과를 얻을 수 있도록 랜덤 시드를 설정합니다.
        Random.InitState(17);

        // Falldown 오브젝트 생성 루틴을 시작합니다.
        StartCoroutine(GenerateFalldownObject());
    }


    /// <summary>
    /// Falldown 오브젝트를 생성합니다.
    /// </summary>
    private IEnumerator GenerateFalldownObject()
    {
        while(true)
        {
            // 1초 대기
            yield return new WaitForSeconds(1.0f);

            // 물고기를 생성시킬 확률을 나타냅니다.
            int fishGenPercentage = 50;

            // fishGenPercentage 에 정의된 확률에 따라 생성시킬 오브젝트 타입을 설정합니다.
            FalldownObjectType genObjectType = (Random.Range(1, 101) < fishGenPercentage) ?
                FalldownObjectType.Fish :
                FalldownObjectType.Trash;

            // 생성시킬 랜덤한 오브젝트 정보를 얻습니다.
            FalldownObjectInfo info = m_FalldownObjectScriptableObject[genObjectType];
            Debug.Log(info.m_FalldownObjectPrefab);

            SpawnFalldownObjectFromInfo(info);

        }
        
    }

    /// <summary>
    /// 얻은 정보를 기반으로 오브젝트를 생성합니다.
    /// </summary>
    /// <param name="info">생성시킬 오브젝트 정보를 전달합니다.</param>
    private void SpawnFalldownObjectFromInfo(FalldownObjectInfo info)
    {
        // 오브젝트를 복사 생성합니다.
        FalldownObjectBase generatedFalldownObject = Instantiate(info.m_FalldownObjectPrefab);

        // 오브젝트를 복사 생성하여 반환합니다.
        // 반환되는 데이터의 형태는 매개 변수의 형태와 동일합니다.
        // 만약 컴포넌트를 전달하여 복사 생성을 진행하는 경우
        // 해당 컴포넌트를 소유하는 오브젝트를 복사 생성하고, 추가되어있는 컴포넌트를 반환합니다.

        //생성된 오브젝트의 내용을 초기화합니다.
        generatedFalldownObject.Initialize(m_PlayerCharacter);

        // 생성된 오브젝트의 위치를 랜덤하게 설정합니다.
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
