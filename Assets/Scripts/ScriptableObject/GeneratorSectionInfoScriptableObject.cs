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
    [Header("# ������ ���� ����")]
    public List<GeneratorSectionInfo> m_SectionInfo;

    /// <summary>
    /// ���� ���� �������� �迭�� ����ϴ�.
    /// </summary>
    /// <returns></returns>
    public List<int> GetSectionStartScores()
    {
        // ���� ���� �������� �����ϱ� ���� ����Ʈ
        List<int> sectionStartScores = new();

        // ��� �������� ��ȸ�ϸ� ���� ���� �������� ����Ʈ�� �߰��մϴ�.
        foreach(GeneratorSectionInfo generatorSectionInfo in m_SectionInfo)
        {
            // ���� ���� ����
            int sectionStartScore = generatorSectionInfo.m_SectionStartScore;

            // ���� ���� ������ ����Ʈ�� �߰��մϴ�.
            sectionStartScores.Add(sectionStartScore);
        }
        return sectionStartScores;
    }

    /// <summary>
    /// ���� ������ ���� �ε����Դϴ�.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public GeneratorSectionInfo this[int index] => m_SectionInfo[index];
}

/// <summary>
/// ������ ��Ÿ���� ���� Ŭ�����Դϴ�.
/// ������ �������� ������ �����ϰ� �˴ϴ�.
/// </summary>

[System.Serializable]
public sealed class GeneratorSectionInfo
{
    [Header("# ������ ���۵Ǵ� ����")]
    public int m_SectionStartScore;

    [Header("# ����� ���� ������")]
    public float m_GeneratingDelay;

    [Header("# ����� ���� Ȯ��")]
    [Range(0, 100)]
    public int m_FishGeneratorPercentage;

}


// ���� ����
//  ���� ���� ����
//  �� ������ ����� ���� ������
//  ����� ���� Ȯ�� 0% ~ 100%

// 100
// 200
// 500 
// 1000