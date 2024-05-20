using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ī�޶� �� �ƿ� ����� �����ϱ� ���� ������Ʈ�Դϴ�.
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
        // ���� ����� FOV ���� _TargetFOV �� �ٸ� ���� ��� ����
        while(_Camera.fieldOfView != _TargetFOV)
        {
            _Camera.fieldOfView = Mathf.MoveTowards(
           _Camera.fieldOfView,
           _TargetFOV,
           120.0f * Time.deltaTime);

            // ���� Update ȣ����� ���
            yield return null;
        }

    }

    // �ڷ�ƾ
    // ������� ����ϰ� ���ÿ� ��� ������ ó���ؾ� �ϴ� ��� ����� �� �ִ� ����Դϴ�.
    // ���� �񵿱� ó���� ���Ͽ� ���Ǹ�, ���ο� �����带 �����Ͽ�
    // ���ο� ��ƾ�� �����Ű�� ���� �ƴ� ���� �����忡�� �����층�� ���� ��ƾ�� ����˴ϴ�.
    // ����Ƽ������ IEnumerator �� ��ȯ�ϵ��� �Ͽ� �ڷ�ƾ�� ����� �� ������,
    // �̸� ���� yield ������ �帧�� �Լ� ���η� �����Ӱ� �峪�� �� �ֵ��� �ϰ�,
    // ���ϴ� ������ ��� ȣ���� �ߴ��ϵ��� �� �� �ֽ��ϴ�.
    // Ÿ �����带 ����ϴ� ���� �ƴϱ� �빮��, ����Ƽ ������Ʈ�� ���� ������ �����ӽ��ϴ�.
    // (����Ƽ������ Main Thread �� �ƴ�, ���� �����忡���� ����Ƽ ������Ʈ�� ���� ������ ������� �ʽ��ϴ�.)

    // yield null
    // ���� Update() ȣ����� ��ƾ�� ����ŵ�ϴ�.
    //
    // yield break
    // �ش� ��ġ���� ��ƾ�� �����մϴ�.
    //
    // yield return new WaitForFixedUpdate()
    // FixedUpdate() ȣ����� ��ƾ�� ����ŵ�ϴ�.
    //
    // yield return new WaitForSeconds()
    // ������ �ð�(��)��ŭ ��ƾ�� ����ŵ�ϴ�.(TimeScale �� ������ �޽��ϴ�.)
    //
    // yield return new WaitForSecondsRealTime()
    // ������ �ð�(��)��ŭ ��ƾ�� ����ŵ�ϴ�. (TimeScale �� ������ ���� �ʽ��ϴ�.)
    //
    // yield return new WaitUntil()
    // ������ ������ ���̵� �� ���� ��ƾ�� ����ŵ�ϴ�.
    //
    // yield return new WaitWhile()
    // ������ ������ ������ �� ������ ��ƾ�� ����ŵ�ϴ�.



}
