using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모바일에서 터치 입력으로 캐릭터를 이동시키기 위해 사용되는 컴포넌트입니다.
/// </summary>
public sealed class InputPanel : MonoBehaviour
{
    /// <summary>
    /// 왼쪽, 오른쪽 입력 여부를 나타냅니다.
    /// </summary>
    private bool _LeftPressed, _RightPressed;

    /// <summary>
    /// 수평축 입력 값입니다.
    /// </summary>
    private float _HorizontalAxisValue;

    /// <summary>
    /// 수평 축 입력값 갱신 시 발생하는 이벤트입니다.
    /// </summary>
    public event System.Action<float /* horizontalAxisValue*/> onHorizontalAxisValueUpdated;

    private void Update() => UpdateHorizontalInputValue();

    /// <summary>
    /// 수평 축 입력 값을 갱신합니다.
    /// </summary>
    private void UpdateHorizontalInputValue()
    {
        _HorizontalAxisValue = 0.0f;
        if (_LeftPressed) _HorizontalAxisValue -= 1.0f;
        if (_RightPressed) _HorizontalAxisValue += 1.0f;
        // _HorizontalAxisValue = -1, 0, 1

        onHorizontalAxisValueUpdated?.Invoke(_HorizontalAxisValue);
    }

    public void InputEvent_LeftTouchStarted() => _LeftPressed = true;

    public void InputEvent_LeftTouchFinished() => _LeftPressed = false;

    public void InputEvent_RightTouchStarted() => _RightPressed = true;

    public void InputEvent_RightTouchFinished() => _RightPressed = false;




}
