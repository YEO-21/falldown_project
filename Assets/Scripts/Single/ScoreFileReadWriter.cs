using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// 점수 파일을 읽고 쓰는 객체를 나타내기 위한 클래스
/// 
/// </summary>
public sealed partial class ScoreFileReadWriter
{
    /// <summary>
    /// 이전 점수 정보 존재 여부
    /// </summary>
    private bool _PrevScoreDataExist;

    /// <summary>
    /// 최고 점수
    /// </summary>
    private float _BestScore = 1.0f;

    /// <summary>
    /// 최고 점수 파일 경로
    /// </summary>
    private string WINDOWS_BESTSCORE_DIRECTORY => $"{Application.dataPath}/PlayerData/";

    /// <summary>
    /// 최고 점수 파일명
    /// </summary>
    private string WINDOWS_BESTSCORE_FILENAME => $"BestScore.txt";

    /// <summary>
    /// 최고 점수를 저장/로드하기 위한 키
    /// </summary>
    private string ANDROID_BESTSCORE_KEY => "bstScr";

    public void Initialize()
    {
        // 이전 정보 읽기
        ReadPrevScoreData();
    }

    /// <summary>
    /// 최고 점수를 갱신합니다.
    /// </summary>
    /// <param name=""></param>
    /// <param name="score">갱신시킬 점수를 전달합니다.</param>
    public void UpdateBestScore(in float score)
    {
        // 이전 기록 존재함 상태로 설정
        _PrevScoreDataExist = true;

#if UNITY_EDITOR || UNITY_STANDALONE // 에디터 / Win

        // 최고 점수 갱신
        UpdateBestScore_Windows(score);


#elif UNITY_ANDROID // Android

        // 최고 점수 갱신
        UpdateBestScore_Android(score);

#endif
    }

    /// <summary>
    /// 최고 점수 가져오기 시도
    /// </summary>
    /// <param name="bestScore">점수 데이터를 반환받을 변수를 전달합니다.</param>
    /// <returns>기록 존재 여부를 반환합니다.</returns>
    public bool TryGetBestScore(out float bestScore)
    {
        // 기록이 존재하지 않는 경우
        if(!_PrevScoreDataExist)
        {
            bestScore = 0.0f;
            return false;
        }

        // 기록이 존재하는 경우
        bestScore = _BestScore;
        return true;
    }




    /// <summary>
    /// 이전 점수 정보를 읽어옵니다.
    /// </summary>
    private void ReadPrevScoreData()
    {

#if UNITY_EDITOR || UNITY_STANDALONE  // PC (에디터 / 스탠드얼론)

        // 최고 점수 갱신
        ReadPrevScoreData_Windows();


#elif UNITY_ANDROID // ANDROID

        // 최고 점수 갱신
        ReadPrevScoreData_Android();

#endif


    }


}

#region STANDALONE (EDITOR / WIN)
public sealed partial class ScoreFileReadWriter
{
    // 이전 점수 데이터를 읽어옵니다.
    private void ReadPrevScoreData_Windows()
    {
        // 최고 점수 파일을 저장할 경로가 존재하지 않는 경우
        if (!Directory.Exists(WINDOWS_BESTSCORE_DIRECTORY))
        {
            // 경로 생성
            Directory.CreateDirectory(WINDOWS_BESTSCORE_DIRECTORY);
        }

        // 파일 경로
        string filePath = $"{WINDOWS_BESTSCORE_DIRECTORY}{WINDOWS_BESTSCORE_FILENAME}";
       
        // 최고 점수 파일을 저장할 파일이 존재하지 않는 경우
        if (!File.Exists(filePath))
        {
            // 파일 생성
            StreamWriter streamWriter = File.CreateText(filePath);
            // StreamWriter : 파일 읽기/쓰기 기능을 제공하는 클래스입니다.

            // 객체 메모리 정리
            streamWriter.Dispose();

            //using (StreamWriter streamWriter1 = File.CreateText(filePath))
            //{
            //    streamWriter1.Dispose();
            //}

           
            // 파일을 읽지 못했기 때문에 함수 호출 종료
            return;
        }

        
        // 최고 점수를 저장하기 위한 변수
        float bestScore = default;
        
        // 파일을 열어 내용을 확인합니다.
        foreach (string line in File.ReadAllLines(filePath))
        {
            
            if (float.TryParse(line, out bestScore))
            {
                
                // 이전 최고점수 기록이 존재함
                _PrevScoreDataExist = true;

                // 최고 점수를 얻습니다.
                _BestScore = bestScore;
                
                break;
            }
            


        }
        
    }
    // 최고 점수 데이터를 갱신합니다.
    private void UpdateBestScore_Windows(in float score)
    {
        // 이전 기록보다 낮은 점수인 경우 함수 호출 종료
        if (_BestScore >= score) return;

        // 파일 경로
        string filePath = $"{WINDOWS_BESTSCORE_DIRECTORY}{WINDOWS_BESTSCORE_FILENAME}";


        using (FileStream fileStream = File.Open(filePath, FileMode.Truncate, FileAccess.Write))
        {
            // 파일에 쓰기 위하여 StreamWriter 객체를 생성합니다.
            using (StreamWriter streamWriter = new(fileStream))
            {
                // 파일에 내용을 기록합니다.
                streamWriter.WriteLine(_BestScore = score);
            }
        }
       


    }


}
#endregion

#region Android
public sealed partial class ScoreFileReadWriter
{
    // 이전 점수 데이터를 읽어옵니다.
    private void ReadPrevScoreData_Android()
    {
        if(PlayerPrefs.HasKey(ANDROID_BESTSCORE_KEY))
        {
            // 기록 존재 여부 확인됨
            _PrevScoreDataExist = true;

            // 최고 점수 불러오기
            _BestScore = PlayerPrefs.GetFloat(ANDROID_BESTSCORE_KEY);
        }

    }

    // 최고 점수 데이터를 갱신합니다.
    private void UpdateBestScore_Android(in float score)
    {
        // 이전 기록보다 낮은 점수인 경우 함수 호출 종료
        if (_BestScore >= score) return;

        // 높은 점수인 경우
        // Key   ANDROID_BESTSCORE_KEY
        // Value  score
        PlayerPrefs.SetFloat(ANDROID_BESTSCORE_KEY, _BestScore = score);


    }


}
#endregion