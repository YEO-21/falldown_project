using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(
    fileName = "GeneratorSectionInfo",
    menuName = "ScriptableObject/Create GeneratorSectionInfo",
    order = int.MinValue
    )]
public class GeneratorSectionInfoScriptableObject : ScriptableObject
{
    [Header("# 생성기 구간 정보")]
    public List<GeneratorSectionInfo> m_SectionInfo;

    /// <summary>
    /// 구간 시작 점수들을 배열로 얻습니다.
    /// </summary>
    /// <returns></returns>
    public List<int> GetSectionStartScores()
    {
        // 구간 시작 점수들을 저장하기 위한 리스트
        List<int> sectionStartScores = new();

        // 모든 정보들을 순회하며 구간 시작 점수들을 리스트에 추가합니다.
        foreach(GeneratorSectionInfo generatorSectionInfo in m_SectionInfo)
        {
            // 구간 시작 점수
            int sectionStartScore = generatorSectionInfo.m_SectionStartScore;

            // 구간 시작 점수를 리스트에 추가합니다.
            sectionStartScores.Add(sectionStartScore);
        }
        return sectionStartScores;
    }

    /// <summary>
    /// 구간 정보에 대한 인덱서입니다.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public GeneratorSectionInfo this[int index] => m_SectionInfo[index];
}

/// <summary>
/// 구간을 나타내기 위한 클래스입니다.
/// 점수를 기준으로 구간을 결정하게 됩니다.
/// </summary>

[System.Serializable]
public sealed class GeneratorSectionInfo
{
    [Header("# 구간이 시작되는 점수")]
    public int m_SectionStartScore;

    [Header("# 적용될 생성 딜레이")]
    public float m_GeneratingDelay;

    [Header("# 물고기 생성 확률")]
    [Range(0, 100)]
    public int m_FishGeneratorPercentage;

}


// 구간 정보
//  구간 시작 점수
//  이 구간에 적용될 생성 딜레이
//  물고기 생성 확률 0% ~ 100%

// 100
// 200
// 500 
// 1000