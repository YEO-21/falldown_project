using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �÷��̾� HP�� ǥ���ϱ� ���� ������Ʈ�Դϴ�.
/// </summary>
public sealed class PlayerHpPanel : MonoBehaviour
{
    [Header("# �÷��̾� Hp �̵� ���� ����")]
    public RectTransform m_ImageMoveableArea;

    [Header("# �÷��̾� Hp ǥ�ÿ� �̹���")]
    public Image m_PlayerHpImage;

    /// <summary>
    /// ���� ǥ������ Hp ��ġ�� ��Ÿ���ϴ�.
    /// </summary>
    private float _CurrentHpValue;

    /// <summary>
    ///  ��ǥ Hp ��ġ�� ��Ÿ���ϴ�.
    /// </summary>
    private float _TargetHpValue;

    private void Start()
    {
        // �÷��̾� ���� ��ü�� ����ϴ�.
        PlayerState playerState = GameManager.instance.playerState;

        // ü�� ���� �ݹ� ���ε� 
        playerState.onHpChanged += CALLBACK_OnHpValueChanged;

        // �ʱⰪ�� �����մϴ�.
        _TargetHpValue = playerState.PlayerHp;
        UpdateHp(false);
    }

    private void Update() => UpdateHp();
    

    private void UpdateHp(bool smoothFill = true)
    {
        if(smoothFill)
        {
            _CurrentHpValue = Mathf.MoveTowards(
                        _CurrentHpValue,
                        _TargetHpValue,
                        50.0f * Time.deltaTime);
        }
        else
        {
            _CurrentHpValue = _TargetHpValue;
        }
        

        // �̵� ���� ������ ���� ũ�⸦ ����ϴ�.
        float areaWidth = m_ImageMoveableArea.rect.width;
        // Rect : Ư���� �簢 ������ ��Ÿ���� ���� ����ü�Դϴ�.

        // HP �̹����� ������ ��ġ�� ����մϴ�.
        Vector2 hpImagePosition = Vector2.right * (_CurrentHpValue * 0.01f) * areaWidth;

        // ��Ŀ�� ����� ��ġ�� �����մϴ�.
        m_PlayerHpImage.rectTransform.anchoredPosition = hpImagePosition;
    }

    /// <summary>
    ///  �÷��̾��� ü���� ����� �� ȣ��Ǵ� �޼����Դϴ�.
    ///  PlayerState Ŭ������ onHpChanged �̺�Ʈ�� ���ε��˴ϴ�.
    /// </summary>
    /// <param name="currentHp"></param>
    private void CALLBACK_OnHpValueChanged(float currentHp)
    {

        _TargetHpValue = currentHp;
    }
}
