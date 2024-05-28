using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ���� ��ü�� �����ϰ� �� Ŭ�����Դϴ�.
/// ���� ������� ������ �� �ϳ��� �����ϰ� �� ��ü�̸�, Singleton ������ �̿��մϴ�.
/// 
/// Singleton Pattern
/// ��ü ���� ���α׷��ֿ��� Ŭ������ ��ü�� �����ϵ��� �Ͽ� ��ü�� �ϰ��� ���¸� �����ϰ�
/// �������� �� ��ü���� ������ �� �ֵ��� �ϴ� ���α׷��� �����Դϴ�.
/// �����ڸ� ���� �� ȣ���ϴ��� ���ο� ��ü�� �Ҵ����� �ʵ��� �Ͽ�
/// �޸𸮿� ���� ������ ���� �� �ֽ��ϴ�.
/// 
/// ������ �������� ������ ����ϱ� ������ ���к��� ����� ���� �����,
/// ���� Ŭ������ ���� ���װ� �߻��ϴ� ��� ������� ����� �� �ֽ��ϴ�.
/// 
/// �⺻���� �̱��� �ۼ� ����� �����ڿ��� ���������, ����Ƽ������ ����
/// GameManager ������Ʈ�� �����ϰ� Awake ������ �ۼ��Ǹ�
/// DontDestroyOnLoad() �޼��带 �Բ� ����մϴ�.
/// </summary>
public sealed class GameManager : MonoBehaviour
{
    /// <summary>
    /// GameManager ��ü�� �����ϰ� �� ���� �ʵ��Դϴ�.
    /// </summary>
    private static GameManager _Instance;

    /// <summary>
    /// �� �ϳ��� GameManager ��ü�� ������� ������Ƽ�Դϴ�.
    /// </summary>
    public static GameManager instance => _Instance ?? Initialize();

    /// <summary>
    /// �÷��̾� ���¸� ��Ÿ���ϴ�.
    /// </summary>
    public PlayerState playerState { get; } = new();

    /// <summary>
    /// ���� ���� �б�/���� ��ü�� ��Ÿ���ϴ�.
    /// </summary>
    public ScoreFileReadWriter scoreFilerReadWriter { get; } = new();

    /// <summary>
    /// GameManager ��ü�� �ʱ�ȭ�ϰ�, ��ȯ�մϴ�.
    /// </summary>
    /// <returns></returns>
    /// 
    private static GameManager Initialize()
    {
        if(_Instance == null)
        {
            _Instance = FindObjectOfType<GameManager>();

            // �� ���� ������Ʈ�� ���� ����Ǿ ���ŵ��� �ʵ��� �մϴ�.
            DontDestroyOnLoad(_Instance.gameObject);
        }

        // ���� ���� �б�/���� ��ü �ʱ�ȭ
        _Instance.scoreFilerReadWriter.Initialize();

        // ��ǥ ������ ����
        Application.targetFrameRate = 120;

        return _Instance;
    }

    private void Awake()
    {
        // �̹� GameManager ��ü�� �Ҵ�Ǿ�������, �ڽ��� �ƴ� ���
        if(instance != this)
        {
            // �� ������Ʈ�� �����մϴ�.
            Destroy(gameObject);
        }
    }

}

