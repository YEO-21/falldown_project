using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어 상태를 나타내기 위한 클래스입니다.
/// </summary>
public sealed class PlayerState
{
    /// <summary>
    /// 플레이어 HP를 나타냅니다.
    /// </summary>
    public float PlayerHp { get; private set; }

    /// <summary>
    /// 점수를 나타냅니다.
    /// </summary>
    public float score { get; private set; }

    /// <summary>
    /// 체력 수치 변경 시 발생하는 이벤트입니다.
    /// </summary>
    public event System.Action<float> onHpChanged;

    /// <summary>
    /// 점수 변경 시 발생하는 이벤트입니다.
    /// </summary>
    public event System.Action<float> onScoreChanged;

    /// <summary>
    /// 플레이어 사망 시 발생하는 이벤트입니다.
    /// </summary>
    public event System.Action onPlayerDead;

    /// <summary>
    /// 플레이어 상태를 초기화합니다.
    /// </summary>
    public void Initialize()
    {
        PlayerHp = 50.0f;
        score = 0.0f;

        // 바인딩된 이벤트 초기화
        onScoreChanged = null;
        onHpChanged = null;
        onPlayerDead = null;
        
    }

    /// <summary>
    /// 점수를 추가합니다.
    /// </summary>
    /// <param name="addScore">추가시킬 점수를 전달합니다.</param>
    public void AddScore(float addScore)
    {
        score += addScore;
        if (score < 0.0f) score = 0.0f;

        onScoreChanged?.Invoke(score);
    }

    /// <summary>
    /// 체력을 추가합니다.
    /// </summary>
    /// <param name="addHp">추가시킬 체력을 전달합니다.</param>
    public void AddHp(float addHp)
    {

        PlayerHp = Mathf.Clamp(PlayerHp + addHp, 0.0f, 100.0f);

        // 체력 변경 이벤트 발생
        onHpChanged?.Invoke(PlayerHp);

        // 체력이 0이 되는 경우 사망
        if(PlayerHp == 0.0f)
        {
            // 사망 이벤트 발생
            onPlayerDead?.Invoke();
        }
    }
}
