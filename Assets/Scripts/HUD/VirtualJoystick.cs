using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualJoystick : MonoBehaviour, IVirtualJoystick
{
    private CanvasGroup _canvasGroup;
    private RectTransform _rectTransform;

    [SerializeField] private RectTransform _stick;
    [SerializeField] private float _stickOffset;

    // Start is called before the first frame update
    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _rectTransform = GetComponent<RectTransform>();
        DisplayJoystick(false);
    }

    public void UpdateStickPosition (Vector3 direction)
    {
        _stick.anchoredPosition = direction.normalized * _stickOffset;
    }

    public void DisplayJoystick (bool state) {
        _canvasGroup.alpha = state ? 1 : 0;
    }

    public void AnchorJoystick(Vector3 touchPosition)
    {
        _rectTransform.anchoredPosition = touchPosition;
    }
}
