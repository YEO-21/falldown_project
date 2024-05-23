using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// GameScene UI �� ��Ÿ���� ������Ʈ�Դϴ�.
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
        // ���� ���� �г� ��Ȱ��ȭ
        m_GameOverPanel.gameObject.SetActive(false);

        // ���� ���� �ݹ� ���
        GameManager.instance.playerState.onPlayerDead += CALLBACK_OnGameOver;

        // �������� �̵� ��ư ��Ȱ��ȭ
        m_GoToMainButton.gameObject.SetActive(false);   

        // ��ư �̺�Ʈ ���
        m_PauseButton.onClick.AddListener(CALLBACK_OnPauseButtonClicked);
        m_GoToMainButton.onClick.AddListener(CALLBACK_OnGoToMainButtonClicked);
    }

    /// <summary>
    /// ���� ���� �� ȣ��Ǵ� �޼���
    /// </summary>
    private void CALLBACK_OnGameOver()
    {
        // ���� ���� �г� Ȱ��ȭ
        m_GameOverPanel.gameObject.SetActive(true);
    }

    /// <summary>
    /// �Ͻ����� ��ư Ŭ�� �޼���
    /// </summary>
    private void CALLBACK_OnPauseButtonClicked()
    {
        // �÷��̾� ���� ��ü
        PlayerState playerState = GameManager.instance.playerState;

        // �Ͻ� ���� ���
        bool toggleState = playerState.TogglePause();

        // �������� �̵� ��ư Ȱ��ȭ
        m_GoToMainButton.gameObject.SetActive(toggleState);

    }

    /// <summary>
    /// �������� �̵� ��ư Ŭ�� �޼���
    /// </summary>
    private void CALLBACK_OnGoToMainButtonClicked()
    {
        PlayerState playerState = GameManager.instance.playerState;

        if (playerState.isPaused) playerState.TogglePause();

        // ���� ������ �̵�
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene_Main");
    }

}
