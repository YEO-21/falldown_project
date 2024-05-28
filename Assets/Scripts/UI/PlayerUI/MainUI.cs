using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class MainUI : PlayerUI
{
    [Header("# ���� ���� ��ư")]
    public Button m_StartButton;

    [Header("# ���� ���� ��ư")]
    public Button m_QuitButton;

    [Header("# �ְ� ���� �ؽ�Ʈ")]
    public TMP_Text m_BestScoreText;


    private void Start()
    {
        // ��ư �̺�Ʈ ���ε�
        m_StartButton.onClick.AddListener(CALLBACK_OnStartButtonClicked);
        m_QuitButton.onClick.AddListener(CALLBACK_OnQuitButtonClicked);

        // �ְ� ���� �ؽ�Ʈ  ����
        UpdatebestScoreText();
    }

    /// <summary>
    /// �ְ� ���� �ؽ�Ʈ�� �����մϴ�.
    /// </summary>
    private void UpdatebestScoreText()
    {
        // ��ϵ� ������ �����ϴ� ���
        if(GameManager.instance.scoreFilerReadWriter.TryGetBestScore(out float bestScore))
        {
            m_BestScoreText.text = ((int)bestScore).ToString();
        }
        // ��ϵ� ������ �������� �ʴ� ���
        else
        {
            m_BestScoreText.text = "-";
        }
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


#elif UNITY_STANDALONE // ���ĵ��� �÷���(Mac, Windows, Linux)

        // ���ø����̼� ����
        Application.Quit();

#elif UNITY_ANDROID // Android �÷���

        // ���ø����̼� ����
        Application.Quit();
#endif



    }


}
