using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class MainUI : PlayerUI
{
    [Header("# 게임 시작 버튼")]
    public Button m_StartButton;

    [Header("# 게임 종료 버튼")]
    public Button m_QuitButton;

    private void Start()
    {
        // 버튼 이벤트 바인딩
        m_StartButton.onClick.AddListener(CALLBACK_OnStartButtonClicked);
        m_QuitButton.onClick.AddListener(CALLBACK_OnQuitButtonClicked);

    }

    /// <summary>
    /// 시작 버튼 클릭 시 호출되는 메서드
    /// </summary>
    private void CALLBACK_OnStartButtonClicked()
    {
        // GameScene 으로 전환
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene_Game");
    }

    /// <summary>
    /// 종료 버튼 클릭 시 호출되는 메서드
    /// </summary>
    private void CALLBACK_OnQuitButtonClicked()
    {
#if UNITY_EDITOR //  유니티 에디터

        // 플레이 모드 종료
        UnityEditor.EditorApplication.isPlaying = false;


#elif UINITY_STANDALONE // 스탠드얼론 플랫폼(Mac, Windows, Linux)

        // 어플리케이션 종료
        Application.Quit();

#elif UNITY_ANDROID // Android 플랫폼

        // 어플리케이션 종료
        Application.Quit();
#endif



    }


}
