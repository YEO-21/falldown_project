using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  떨어지는 오브젝트 생성기입니다.
/// </summary>
public sealed class FalldownObjectGenerator : MonoBehaviour
{
    [Header("# 생성 영역")]
    public Vector3 m_AreaMin;
    public Vector3 m_AreaMax;



    /// <summary>
    /// 프리팹
    /// 오브젝트의 형태를 저장해둔 에셋을 의미합니다.
    /// 지정해둔 형태를 복사 생성하여 월드에 오브젝트를 생성시킬 수 있으며,
    /// 프리팹을 사용하는 경우 편하게 같은 형태의 오브젝트를 여러 개 생성할 수 있습니다.
    /// </summary>
    public FalldownObjectBase m_FalldownObjectPrefab;

    /// <summary>
    /// 마지막으로 생성한 시간을 기록합니다.
    /// </summary>
    private float _LastGenerateTime;

    /// <summary>
    /// 랜덤한 생성 위치를 반환합니다.
    /// </summary>
    public Vector3 randomGenPosition => new Vector3(
                Random.Range(m_AreaMin.x, m_AreaMax.x), m_AreaMax.y, 0.0f);

    private void Start()
    {
        // 매번 동일한 결과를 얻을 수 있도록 랜덤 시드를 설정합니다.
        Random.InitState(17);
    }

    private void Update()
    {
        // 마지막으로 생성한 시간에서 1초가 지난 경우
        if(_LastGenerateTime + 1 < Time.time)
        {
            


            // 오브젝트를 복사 생성합니다.
            FalldownObjectBase generatedFalldownObject = Instantiate(m_FalldownObjectPrefab);
            // 오브젝트를 복사 생성하여 반환합니다.
            // 반환되는 데이터의 형태는 매개 변수의 형태와 동일합니다.
            // 만약 컴포넌트를 전달하여 복사 생성을 진행하는 경우
            // 해당 컴포넌트를 소유하는 오브젝트를 복사 생성하고, 추가되어있는 컴포넌트를 반환합니다.

            //생성된 오브젝트의 내용을 초기화합니다.
            generatedFalldownObject.Initialize();

            // 생성된 오브젝트의 위치를 랜덤하게 설정합니다.
            generatedFalldownObject.transform.position = randomGenPosition;

            // 마지막으로 생성한 시간을 갱신합니다.
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
