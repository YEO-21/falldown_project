using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 카메라 줌 아웃 기능을 구현하기 위한 컴포넌트입니다.
/// </summary>
public sealed class GameCamera : MonoBehaviour
{
    private Camera _Camera;
    private float _TargetFOV = 60.0f;

    private void Awake()
    {
        _Camera = GetComponent<Camera>();
    }


    private void Start()
    {
        _Camera.fieldOfView = 5.0f;
        StartCoroutine(ChangeFOV());
    }


    private IEnumerator ChangeFOV()
    {
        // 현재 적용된 FOV 값이 _TargetFOV 와 다른 값일 경우 실행
        while(_Camera.fieldOfView != _TargetFOV)
        {
            _Camera.fieldOfView = Mathf.MoveTowards(
           _Camera.fieldOfView,
           _TargetFOV,
           120.0f * Time.deltaTime);

            // 다음 Update 호출까지 대기
            yield return null;
        }

    }

    // 코루틴
    // 쓰레드와 비슷하게 동시에 어떠한 구문을 처리해야 하는 경우 사용할 수 있는 기능입니다.
    // 보통 비동기 처리를 위하여 사용되며, 새로운 쓰레드를 생성하여
    // 새로운 루틴을 실행시키는 것이 아닌 단일 쓰레드에서 스케쥴링을 통해 루틴이 실행됩니다.
    // 유니티에서는 IEnumerator 를 반환하도록 하여 코루틴을 사용할 수 있으며,
    // 이를 통해 yield 문으로 흐름이 함수 내부로 자유롭게 드나들 수 있도록 하고,
    // 원하는 시점에 잠시 호출을 중단하도록 할 수 있습니다.
    // 타 쓰레드를 사용하는 것이 아니기 대문에, 유니티 오브젝트에 대한 접근이 자유롭습니다.
    // (유니티에서는 Main Thread 가 아닌, 서브 쓰레드에서의 유니티 오브젝트에 대한 접근을 허용하지 않습니다.)

    // yield null
    // 다음 Update() 호출까지 루틴을 대기시킵니다.
    //
    // yield break
    // 해당 위치에서 루틴을 종료합니다.
    //
    // yield return new WaitForFixedUpdate()
    // FixedUpdate() 호출까지 루틴을 대기시킵니다.
    //
    // yield return new WaitForSeconds()
    // 지정한 시간(초)만큼 루틴을 대기시킵니다.(TimeScale 의 영향을 받습니다.)
    //
    // yield return new WaitForSecondsRealTime()
    // 지정한 시간(초)만큼 루틴을 대기시킵니다. (TimeScale 의 영향을 받지 않습니다.)
    //
    // yield return new WaitUntil()
    // 지정한 조건이 참이될 때 까지 루틴을 대기시킵니다.
    //
    // yield return new WaitWhile()
    // 지정한 조건이 거짓이 될 때까지 루틴을 대기시킵니다.



}
