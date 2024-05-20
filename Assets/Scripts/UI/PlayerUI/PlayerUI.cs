using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �÷��̾� ��ũ���� ��Ÿ���� ���Ͽ� ���Ǵ� ������Ʈ�Դϴ�.
/// ����Ͽ� ����ϵ��� �߻�Ŭ����ȭ ��ŵ�ϴ�.
/// </summary>
public abstract class PlayerUI : MonoBehaviour
{
    /// <summary>
    /// T ������ PlayerUI ������Ʈ ��ü�� ã�� ��ȯ�մϴ�.
    /// </summary>
    /// <typeparam name="T">PlayerUI �� �Ļ� Ŭ������ �����մϴ�.</typeparam>
    /// <returns> T ������ ������Ʈ ��ü�� ��ȯ�մϴ�.</returns>
   public static T GetUI<T>() where T : PlayerUI
    {
        return FindObjectOfType<T>();
    }





}
