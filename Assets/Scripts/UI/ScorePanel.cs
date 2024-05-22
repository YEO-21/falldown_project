using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 점수를 나타내기 위한 패널
/// </summary>
public sealed class ScorePanel : MonoBehaviour
{
    [Header("# 점수 텍스트")]
    public TMP_Text m_ScoreText;

    /// <summary>
    /// 현재 표시되는 점수를 나타냅니다.
    /// </summary>
    private float _CurrentScore;

    /// <summary>
    /// 표시될 점수를 나타냅니다.
    /// </summary>
    private float _TargetScore;

    private void Start()
    {
        // 점수 변경 콜백 등록
        GameManager.instance.playerState.onScoreChanged += CALLBACK_OnScoreChanged;
    }

    private void Update() => UpdateScore();
  

    /// <summary>
    /// 표시되는 점수를 갱신합니다.
    /// </summary>
    private void UpdateScore()
    {
        _CurrentScore = Mathf.MoveTowards(_CurrentScore, _TargetScore, 0.2f);

        m_ScoreText.text = $"{(int)_CurrentScore}";
    }

    /// <summary>
    /// 점수 변경 시 호출되는 메서드입니다.
    /// PlayerState 클래스의 onScoreChanged 이벤트에 바인딩됩니다.
    /// </summary>
    /// <param name="currentScore">현재 점수가 전달됩니다.</param>
    private void CALLBACK_OnScoreChanged(float currentScore)
    {
        // 화면에 표시되는 점수가 이전 목표 점수가 되도록 하고,
        // 새로운 점수를 목표 점수로 설정합니다.
        _CurrentScore = _TargetScore;
        _TargetScore = currentScore;
    }


}
