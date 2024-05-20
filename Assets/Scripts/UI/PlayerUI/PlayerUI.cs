using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 플레이어 스크린을 나타내기 위하여 사용되는 컴포넌트입니다.
/// 상속하여 사용하도록 추상클래스화 시킵니다.
/// </summary>
public abstract class PlayerUI : MonoBehaviour
{
    /// <summary>
    /// T 형식의 PlayerUI 컴폰넌트 객체를 찾아 반환합니다.
    /// </summary>
    /// <typeparam name="T">PlayerUI 의 파생 클래스를 전달합니다.</typeparam>
    /// <returns> T 형식의 컴포넌트 객체를 반환합니다.</returns>
   public static T GetUI<T>() where T : PlayerUI
    {
        return FindObjectOfType<T>();
    }





}
