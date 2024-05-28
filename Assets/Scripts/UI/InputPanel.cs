using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����Ͽ��� ��ġ �Է����� ĳ���͸� �̵���Ű�� ���� ���Ǵ� ������Ʈ�Դϴ�.
/// </summary>
public sealed class InputPanel : MonoBehaviour
{
    /// <summary>
    /// ����, ������ �Է� ���θ� ��Ÿ���ϴ�.
    /// </summary>
    private bool _LeftPressed, _RightPressed;

    /// <summary>
    /// ������ �Է� ���Դϴ�.
    /// </summary>
    private float _HorizontalAxisValue;

    /// <summary>
    /// ���� �� �Է°� ���� �� �߻��ϴ� �̺�Ʈ�Դϴ�.
    /// </summary>
    public event System.Action<float /* horizontalAxisValue*/> onHorizontalAxisValueUpdated;

    private void Update() => UpdateHorizontalInputValue();

    /// <summary>
    /// ���� �� �Է� ���� �����մϴ�.
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
