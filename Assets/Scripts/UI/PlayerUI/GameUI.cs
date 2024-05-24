using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// GameScene UI 를 나타내는 컴포넌트입니다.
/// </summary>
public sealed class GameUI : PlayerUI
{
    [Header("# GameOver Panel")]
    public RectTransform m_GameOverPanel;

    [Header("# Pause Button")]
    public Button m_PauseButton;

    [Header("# GoToMain Button")]
    public Button m_GoToMainButton;




    private void Start()
    {
        // 게임 오버 패널 비활성화
        m_GameOverPanel.gameObject.SetActive(false);

        // 게임 오버 콜백 등록
        GameManager.instance.playerState.onPlayerDead += CALLBACK_OnGameOver;

        // 메인으로 이동 버튼 비활성화
        m_GoToMainButton.gameObject.SetActive(false);   

        // 버튼 이벤트 등록
        m_PauseButton.onClick.AddListener(CALLBACK_OnPauseButtonClicked);
        m_GoToMainButton.onClick.AddListener(CALLBACK_OnGoToMainButtonClicked);
    }

    /// <summary>
    /// 게임 오버 시 호출되는 메서드
    /// </summary>
    private void CALLBACK_OnGameOver()
    {
        // 게임 오버 패널 활성화
        m_GameOverPanel.gameObject.SetActive(true);
    }

    /// <summary>
    /// 일시정지 버튼 클릭 메서드
    /// </summary>
    private void CALLBACK_OnPauseButtonClicked()
    {
        // 플레이어 상태 객체
        PlayerState playerState = GameManager.instance.playerState;

        // 일시 정지 토글
        bool toggleState = playerState.TogglePause();

        // 메인으로 이동 버튼 활성화
        m_GoToMainButton.gameObject.SetActive(toggleState);

    }

    /// <summary>
    /// 메인으로 이동 버튼 클릭 메서드
    /// </summary>
    private void CALLBACK_OnGoToMainButtonClicked()
    {
        PlayerState playerState = GameManager.instance.playerState;

        if (playerState.isPaused) playerState.TogglePause();

        // 메인 씬으로 이동
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene_Main");
    }

}
