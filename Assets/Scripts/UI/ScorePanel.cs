using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// ������ ��Ÿ���� ���� �г�
/// </summary>
public sealed class ScorePanel : MonoBehaviour
{
    [Header("# ���� �ؽ�Ʈ")]
    public TMP_Text m_ScoreText;

    /// <summary>
    /// ���� ǥ�õǴ� ������ ��Ÿ���ϴ�.
    /// </summary>
    private float _CurrentScore;

    /// <summary>
    /// ǥ�õ� ������ ��Ÿ���ϴ�.
    /// </summary>
    private float _TargetScore;

    private void Start()
    {
        // ���� ���� �ݹ� ���
        GameManager.instance.playerState.onScoreChanged += CALLBACK_OnScoreChanged;
    }

    private void Update() => UpdateScore();
  

    /// <summary>
    /// ǥ�õǴ� ������ �����մϴ�.
    /// </summary>
    private void UpdateScore()
    {
        _CurrentScore = Mathf.MoveTowards(_CurrentScore, _TargetScore, 0.2f);

        m_ScoreText.text = $"{(int)_CurrentScore}";
    }

    /// <summary>
    /// ���� ���� �� ȣ��Ǵ� �޼����Դϴ�.
    /// PlayerState Ŭ������ onScoreChanged �̺�Ʈ�� ���ε��˴ϴ�.
    /// </summary>
    /// <param name="currentScore">���� ������ ���޵˴ϴ�.</param>
    private void CALLBACK_OnScoreChanged(float currentScore)
    {
        // ȭ�鿡 ǥ�õǴ� ������ ���� ��ǥ ������ �ǵ��� �ϰ�,
        // ���ο� ������ ��ǥ ������ �����մϴ�.
        _CurrentScore = _TargetScore;
        _TargetScore = currentScore;
    }


}
