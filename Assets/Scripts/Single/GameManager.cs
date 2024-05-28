using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 게임 전체를 관리하게 될 클래스입니다.
/// 게임 실행부터 끝까지 단 하나만 존재하게 될 객체이며, Singleton 패턴을 이용합니다.
/// 
/// Singleton Pattern
/// 객체 지향 프로그래밍에서 클래스의 객체가 유일하도록 하여 객체의 일관된 상태를 유지하고
/// 전역에서 이 객체에게 접근할 수 있도록 하는 프로그래밍 패턴입니다.
/// 생성자를 여러 번 호출하더라도 새로운 객체를 할당하지 않도록 하여
/// 메모리에 대한 이점을 얻을 수 있습니다.
/// 
/// 하지만 전역에서 접근을 허용하기 때문에 무분별한 사용을 막기 힘들며,
/// 관련 클래스로 인해 버그가 발생하는 경우 디버깅이 어려울 수 있습니다.
/// 
/// 기본적인 싱글톤 작성 방식은 생성자에서 진행되지만, 유니티에서는 보통
/// GameManager 컴포넌트를 생성하고 Awake 문에서 작성되며
/// DontDestroyOnLoad() 메서드를 함께 사용합니다.
/// </summary>
public sealed class GameManager : MonoBehaviour
{
    /// <summary>
    /// GameManager 객체를 참조하게 될 정적 필드입니다.
    /// </summary>
    private static GameManager _Instance;

    /// <summary>
    /// 단 하나의 GameManager 객체를 얻기위한 프로퍼티입니다.
    /// </summary>
    public static GameManager instance => _Instance ?? Initialize();

    /// <summary>
    /// 플레이어 상태를 나타냅니다.
    /// </summary>
    public PlayerState playerState { get; } = new();

    /// <summary>
    /// 점수 파일 읽기/쓰기 객체를 나타냅니다.
    /// </summary>
    public ScoreFileReadWriter scoreFilerReadWriter { get; } = new();

    /// <summary>
    /// GameManager 객체를 초기화하고, 반환합니다.
    /// </summary>
    /// <returns></returns>
    /// 
    private static GameManager Initialize()
    {
        if(_Instance == null)
        {
            _Instance = FindObjectOfType<GameManager>();

            // 이 게임 오브젝트가 씬이 변경되어도 제거되지 않도록 합니다.
            DontDestroyOnLoad(_Instance.gameObject);
        }

        // 점수 파일 읽기/쓰기 객체 초기화
        _Instance.scoreFilerReadWriter.Initialize();

        // 목표 프레임 설정
        Application.targetFrameRate = 120;

        return _Instance;
    }

    private void Awake()
    {
        // 이미 GameManager 객체가 할당되어있으며, 자신이 아닌 경우
        if(instance != this)
        {
            // 이 오브젝트를 제거합니다.
            Destroy(gameObject);
        }
    }

}

