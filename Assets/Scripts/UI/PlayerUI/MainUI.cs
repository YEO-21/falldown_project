using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class MainUI : PlayerUI
{
    [Header("# ���� ���� ��ư")]
    public Button m_StartButton;

    [Header("# ���� ���� ��ư")]
    public Button m_QuitButton;

    private void Start()
    {
        // ��ư �̺�Ʈ ���ε�
        m_StartButton.onClick.AddListener(CALLBACK_OnStartButtonClicked);
        m_QuitButton.onClick.AddListener(CALLBACK_OnQuitButtonClicked);

    }

    /// <summary>
    /// ���� ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    /// </summary>
    private void CALLBACK_OnStartButtonClicked()
    {
        // GameScene ���� ��ȯ
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene_Game");
    }

    /// <summary>
    /// ���� ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    /// </summary>
    private void CALLBACK_OnQuitButtonClicked()
    {
#if UNITY_EDITOR //  ����Ƽ ������

        // �÷��� ��� ����
        UnityEditor.EditorApplication.isPlaying = false;


#elif UINITY_STANDALONE // ���ĵ��� �÷���(Mac, Windows, Linux)

        // ���ø����̼� ����
        Application.Quit();

#elif UNITY_ANDROID // Android �÷���

        // ���ø����̼� ����
        Application.Quit();
#endif



    }


}
