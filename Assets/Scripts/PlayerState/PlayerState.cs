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
    /// 플레이어 상태를 초기화합니다.
    /// </summary>
    public void Initialize()
    {
        PlayerHp = 50.0f;
        score = 0.0f;
    }

    /// <summary>
    /// 점수를 추가합니다.
    /// </summary>
    /// <param name="addScore">추가시킬 점수를 전달합니다.</param>
    public void AddScore(float addScore)
    {
        score += addScore;
        if (score < 0.0f) score = 0.0f;

        Debug.Log("score = " + score);
    }

    /// <summary>
    /// 체력을 추가합니다.
    /// </summary>
    /// <param name="addHp">추가시킬 체력을 전달합니다.</param>
    public void AddHp(float addHp)
    {

        PlayerHp = Mathf.Clamp(PlayerHp + addHp, 0.0f, 100.0f);

        Debug.Log("PlayerHp = " + PlayerHp);
    }
}
