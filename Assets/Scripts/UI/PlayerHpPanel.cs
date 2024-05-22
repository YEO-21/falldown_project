using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 플레이어 HP를 표시하기 위한 컴포넌트입니다.
/// </summary>
public sealed class PlayerHpPanel : MonoBehaviour
{
    [Header("# 플레이어 Hp 이동 가능 영역")]
    public RectTransform m_ImageMoveableArea;

    [Header("# 플레이어 Hp 표시용 이미지")]
    public Image m_PlayerHpImage;

    /// <summary>
    /// 현재 표시중인 Hp 수치를 나타냅니다.
    /// </summary>
    private float _CurrentHpValue;

    /// <summary>
    ///  목표 Hp 수치를 나타냅니다.
    /// </summary>
    private float _TargetHpValue;

    private void Start()
    {
        // 플레이어 상태 객체를 얻습니다.
        PlayerState playerState = GameManager.instance.playerState;

        // 체력 변경 콜백 바인딩 
        playerState.onHpChanged += CALLBACK_OnHpValueChanged;

        // 초기값을 설정합니다.
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
        

        // 이동 가능 영역의 가로 크기를 얻습니다.
        float areaWidth = m_ImageMoveableArea.rect.width;
        // Rect : 특정한 사각 영역을 나타내기 위한 구조체입니다.

        // HP 이미지에 설정될 위치를 계산합니다.
        Vector2 hpImagePosition = Vector2.right * (_CurrentHpValue * 0.01f) * areaWidth;

        // 앵커가 적용된 위치를 설정합니다.
        m_PlayerHpImage.rectTransform.anchoredPosition = hpImagePosition;
    }

    /// <summary>
    ///  플레이어의 체력이 변경될 때 호출되는 메서드입니다.
    ///  PlayerState 클래스의 onHpChanged 이벤트에 바인딩됩니다.
    /// </summary>
    /// <param name="currentHp"></param>
    private void CALLBACK_OnHpValueChanged(float currentHp)
    {

        _TargetHpValue = currentHp;
    }
}
