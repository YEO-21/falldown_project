using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// ���� ������ �а� ���� ��ü�� ��Ÿ���� ���� Ŭ����
/// 
/// </summary>
public sealed partial class ScoreFileReadWriter
{
    /// <summary>
    /// ���� ���� ���� ���� ����
    /// </summary>
    private bool _PrevScoreDataExist;

    /// <summary>
    /// �ְ� ����
    /// </summary>
    private float _BestScore = 1.0f;

    /// <summary>
    /// �ְ� ���� ���� ���
    /// </summary>
    private string WINDOWS_BESTSCORE_DIRECTORY => $"{Application.dataPath}/PlayerData/";

    /// <summary>
    /// �ְ� ���� ���ϸ�
    /// </summary>
    private string WINDOWS_BESTSCORE_FILENAME => $"BestScore.txt";

    /// <summary>
    /// �ְ� ������ ����/�ε��ϱ� ���� Ű
    /// </summary>
    private string ANDROID_BESTSCORE_KEY => "bstScr";

    public void Initialize()
    {
        // ���� ���� �б�
        ReadPrevScoreData();
    }

    /// <summary>
    /// �ְ� ������ �����մϴ�.
    /// </summary>
    /// <param name=""></param>
    /// <param name="score">���Ž�ų ������ �����մϴ�.</param>
    public void UpdateBestScore(in float score)
    {
        // ���� ��� ������ ���·� ����
        _PrevScoreDataExist = true;

#if UNITY_EDITOR || UNITY_STANDALONE // ������ / Win

        // �ְ� ���� ����
        UpdateBestScore_Windows(score);


#elif UNITY_ANDROID // Android

        // �ְ� ���� ����
        UpdateBestScore_Android(score);

#endif
    }

    /// <summary>
    /// �ְ� ���� �������� �õ�
    /// </summary>
    /// <param name="bestScore">���� �����͸� ��ȯ���� ������ �����մϴ�.</param>
    /// <returns>��� ���� ���θ� ��ȯ�մϴ�.</returns>
    public bool TryGetBestScore(out float bestScore)
    {
        // ����� �������� �ʴ� ���
        if(!_PrevScoreDataExist)
        {
            bestScore = 0.0f;
            return false;
        }

        // ����� �����ϴ� ���
        bestScore = _BestScore;
        return true;
    }




    /// <summary>
    /// ���� ���� ������ �о�ɴϴ�.
    /// </summary>
    private void ReadPrevScoreData()
    {

#if UNITY_EDITOR || UNITY_STANDALONE  // PC (������ / ���ĵ���)

        // �ְ� ���� ����
        ReadPrevScoreData_Windows();


#elif UNITY_ANDROID // ANDROID

        // �ְ� ���� ����
        ReadPrevScoreData_Android();

#endif


    }


}

#region STANDALONE (EDITOR / WIN)
public sealed partial class ScoreFileReadWriter
{
    // ���� ���� �����͸� �о�ɴϴ�.
    private void ReadPrevScoreData_Windows()
    {
        // �ְ� ���� ������ ������ ��ΰ� �������� �ʴ� ���
        if (!Directory.Exists(WINDOWS_BESTSCORE_DIRECTORY))
        {
            // ��� ����
            Directory.CreateDirectory(WINDOWS_BESTSCORE_DIRECTORY);
        }

        // ���� ���
        string filePath = $"{WINDOWS_BESTSCORE_DIRECTORY}{WINDOWS_BESTSCORE_FILENAME}";
       
        // �ְ� ���� ������ ������ ������ �������� �ʴ� ���
        if (!File.Exists(filePath))
        {
            // ���� ����
            StreamWriter streamWriter = File.CreateText(filePath);
            // StreamWriter : ���� �б�/���� ����� �����ϴ� Ŭ�����Դϴ�.

            // ��ü �޸� ����
            streamWriter.Dispose();

            //using (StreamWriter streamWriter1 = File.CreateText(filePath))
            //{
            //    streamWriter1.Dispose();
            //}

           
            // ������ ���� ���߱� ������ �Լ� ȣ�� ����
            return;
        }

        
        // �ְ� ������ �����ϱ� ���� ����
        float bestScore = default;
        
        // ������ ���� ������ Ȯ���մϴ�.
        foreach (string line in File.ReadAllLines(filePath))
        {
            
            if (float.TryParse(line, out bestScore))
            {
                
                // ���� �ְ����� ����� ������
                _PrevScoreDataExist = true;

                // �ְ� ������ ����ϴ�.
                _BestScore = bestScore;
                
                break;
            }
            


        }
        
    }
    // �ְ� ���� �����͸� �����մϴ�.
    private void UpdateBestScore_Windows(in float score)
    {
        // ���� ��Ϻ��� ���� ������ ��� �Լ� ȣ�� ����
        if (_BestScore >= score) return;

        // ���� ���
        string filePath = $"{WINDOWS_BESTSCORE_DIRECTORY}{WINDOWS_BESTSCORE_FILENAME}";


        using (FileStream fileStream = File.Open(filePath, FileMode.Truncate, FileAccess.Write))
        {
            // ���Ͽ� ���� ���Ͽ� StreamWriter ��ü�� �����մϴ�.
            using (StreamWriter streamWriter = new(fileStream))
            {
                // ���Ͽ� ������ ����մϴ�.
                streamWriter.WriteLine(_BestScore = score);
            }
        }
       


    }


}
#endregion

#region Android
public sealed partial class ScoreFileReadWriter
{
    // ���� ���� �����͸� �о�ɴϴ�.
    private void ReadPrevScoreData_Android()
    {
        if(PlayerPrefs.HasKey(ANDROID_BESTSCORE_KEY))
        {
            // ��� ���� ���� Ȯ�ε�
            _PrevScoreDataExist = true;

            // �ְ� ���� �ҷ�����
            _BestScore = PlayerPrefs.GetFloat(ANDROID_BESTSCORE_KEY);
        }

    }

    // �ְ� ���� �����͸� �����մϴ�.
    private void UpdateBestScore_Android(in float score)
    {
        // ���� ��Ϻ��� ���� ������ ��� �Լ� ȣ�� ����
        if (_BestScore >= score) return;

        // ���� ������ ���
        // Key   ANDROID_BESTSCORE_KEY
        // Value  score
        PlayerPrefs.SetFloat(ANDROID_BESTSCORE_KEY, _BestScore = score);


    }


}
#endregion