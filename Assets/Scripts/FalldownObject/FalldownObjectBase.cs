using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 떨어지는 오브젝트를 나타내기 위한 클래스입니다.
/// 이 클래스는 쓰레기와 물고기 클래스로 나뉘며, 상속을 통해 사용되도록 설계되었습니다.
/// </summary>
public class FalldownObjectBase : MonoBehaviour
{
    /// <summary>
    /// 캐릭터와 충돌 시 캐릭터에게 가해질 피해량을 나타냅니다.
    /// </summary>
    protected float m_HitDamage;

    /// <summary>
    /// 캐릭터와 충돌 시 캐릭터가 회복되는 수치를 나타냅니다.
    /// </summary>
    protected float m_RecoveryHp;

    /// <summary>
    /// 캐릭터와 충돌 시 변화시킬 점수를 나타냅니다.
    /// </summary>
    protected float m_AddScore;

    /// <summary>
    /// 생성된 시간을 기록할 변수입니다.
    /// </summary>
    private float _GeneratedTime;


    private void Update()
    {
        // 제거 타이머
        DestroyTimer();
    }

    /// <summary>
    /// 오브젝트 제거 타이머
    /// </summary>
    private void DestroyTimer()
    {
        // 생성된 후 5초가 지나면 이 오브젝트를 제거합니다.
        if(_GeneratedTime + 5.0f < Time.time)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // OnTriggerEnter : 겹침이 시작될 때 호출됩니다.
        // OnTriggerStay : 겹침이 진행중일 때 계속 호출됩니다.
        // OnTriggerExit : 겹침이 끝났을 때 호출됩니다.
        // OnCollisionExit : 물리적인 충돌이 시작될 때 호출됩니다.
        // OnCollisionExit : 물리적인 충돌이 진행중일 때 계속 호출됩니다.
        // OnCollisionExit : 물리적인 충돌이 끝나는 경우 호출됩니다.
        //
        // 두 충돌체중 하나에 Rigidbody Component가 추가되어 있어야 위 이벤트 함수가 실행됩니다. 

        // Player 라는 Tag 를 가진 오브젝트가 감지된 경우
        //if (other.tag == "Player") ;
        //if (other.tag.CompareTo("Player") == 0) ;
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어 캐릭터 감지!");

        }
    }

    /// <summary>
    /// 오브젝트 내용을 초기화합니다.
    /// </summary>
    public void Initialize()
    {
        // 생성 시간을 기록합니다.
        _GeneratedTime = Time.time;
    }
}
