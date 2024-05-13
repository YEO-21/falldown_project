using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Falldown 오브젝트 정보를 모두 정의해두기 위한
/// ScriptableObject 에셋 형태를 나타내는 클래스입니다.
/// ScriptableObject : 여러 개의 데이터를 기록해두기 위한 에셋입니다.
/// 보통 실시간으로 변화하는 객체의 정보를 기록하는 것이 아닌,
/// 고정된 정보를 저장하기 위해 사용됩니다.
/// 
/// 게임에서 사용될 정보를 미리 정의해두고 필요할 때
/// 언제든지 불러와 적용할 수 있도록 하기 위하여 사용되는 에셋입니다.
/// 
/// 현재 캐릭터의 정보를 저장하기 위한 용도 X
/// 
/// 캐릭터의 기본 스탯 정보 O
/// 스테이지에 출현하는 적 캐릭터의 정보 O
/// 
/// </summary>

[CreateAssetMenu(
    fileName = "FalldownObjectInfo",
    menuName = "ScriptableObject/CreateFalldownObjectInfo",
    order = int.MinValue
    )]
public sealed class FalldownObjectScriptableObject : ScriptableObject
{
    [Header("# Falldown 오브젝트 정보")]
    public List<FalldownObjectInfo> m_FalldownObjectInfos;


    /// <summary>
    /// 지정한 타입의 랜덤한 오브젝트 정보를 얻습니다.
    /// </summary>
    /// <param name="type">얻고자 하는 오브젝트 타입을 전달합니다.</param>
    /// <returns></returns>
    public FalldownObjectInfo GetRandomObjectInfo(FalldownObjectType type)
    {
        // 매개 변수 type 과 일치하는 타입의 오브젝트 정보를 리스트에 잠시 보관합니다.
        List<FalldownObjectInfo> findedFalldownObjectInfos = 
        m_FalldownObjectInfos.FindAll(elem => elem.m_Type == type);

        // 리스트 요소중 랜덤한 요소의 인덱스를 얻습니다.
        int randomIndex = Random.Range(0, m_FalldownObjectInfos.Count);

        // 뽑은 요소(오브젝트 정보)를 반환합니다.
        return findedFalldownObjectInfos[randomIndex];
    }

    /// <summary>
    /// 지정한 타입의 랜덤한 오브젝트 정보를 반환하기 위한 인덱서
    /// </summary>
    /// <param name="type">얻고자 하는 오브젝트 타입을 전달합니다.</param>
    /// <returns></returns>
    public FalldownObjectInfo this[FalldownObjectType type] => 
        GetRandomObjectInfo(type);

}

/// <summary>
/// 하나의 Falldown 오브젝트 정보를 나타내기 위한 클래스
/// </summary>
/// 
[System.Serializable]
/*
 * 형식 직렬화를 위한 어트리뷰트
 * 직렬화란?
 * 객체의 상태를 추후에 저장하거나 전송할 수 있는 형식으로 변환하는 프로세스입니다.
 * 유니티에서 형식이나 속성을 직렬화 시키는 경우 에디터에서 데이터를 노출시킵니다.
 * 
 * Serializable : 지정한 클래스나 구조체를 직렬화 시키는 어트리뷰트입니다.
 * 특정한 형식의 내용을 저장, 전송하기 위하여 사용되며,
 * 유니티의 인스펙터 창에서는 기본적으로 직렬화된 형식들만 표시됩니다.
 * 
 * SerializeField : 스크립트 직렬화를 위한 어트리뷰트입니다.
 * 기본적으로 public 속성만 직렬화되지만, public 을 제외한 나머지 속성을 직렬화 시키는 경우
 * 속성마다 해당 어트리뷰트를 작성해야 합니다.
 * private, protected 를 인스펙터에 노출을 시키고 싶은 경우 사용
 */
public sealed class FalldownObjectInfo
{
    [Header("# 오브젝트 타입")]
    public FalldownObjectType m_Type;

    [Header("# 오브젝트 프리팹")]
    public FalldownObjectBase m_FalldownObjectPrefab;

    [Header("# 피해량")]
    public float m_HitDamage;

    [Header("# 체력 회복량")]
    public float m_RecoverageHp;

    [Header("# 점수 변화량")]
    public float m_AddScore;
}


