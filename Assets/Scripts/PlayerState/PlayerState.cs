using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾� ���¸� ��Ÿ���� ���� Ŭ�����Դϴ�.
/// </summary>
public sealed class PlayerState
{
    /// <summary>
    /// �÷��̾� HP�� ��Ÿ���ϴ�.
    /// </summary>
    public float PlayerHp { get; private set; }

    /// <summary>
    /// ������ ��Ÿ���ϴ�.
    /// </summary>
    public float score { get; private set; }

    /// <summary>
    /// �÷��̾� ���¸� �ʱ�ȭ�մϴ�.
    /// </summary>
    public void Initialize()
    {
        PlayerHp = 50.0f;
        score = 0.0f;
    }

    /// <summary>
    /// ������ �߰��մϴ�.
    /// </summary>
    /// <param name="addScore">�߰���ų ������ �����մϴ�.</param>
    public void AddScore(float addScore)
    {
        score += addScore;
        if (score < 0.0f) score = 0.0f;

        Debug.Log("score = " + score);
    }

    /// <summary>
    /// ü���� �߰��մϴ�.
    /// </summary>
    /// <param name="addHp">�߰���ų ü���� �����մϴ�.</param>
    public void AddHp(float addHp)
    {

        PlayerHp = Mathf.Clamp(PlayerHp + addHp, 0.0f, 100.0f);

        Debug.Log("PlayerHp = " + PlayerHp);
    }
}
