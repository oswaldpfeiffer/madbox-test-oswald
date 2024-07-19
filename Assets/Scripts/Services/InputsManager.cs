using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsManager : BaseService<IInputsManager>, IInputsManager
{
    private IControllable _controlable;
    private IVirtualJoystick _virtualJoystick;
    private Vector3 _refPosition;

    public void SetControllable(IControllable controlable)
    {
        _controlable = controlable;
    }

    public void SetVirtualJoystick (IVirtualJoystick joystick)
    {
        _virtualJoystick = joystick;
    }

    public void RemoveVirtualJoystick()
    {
        _virtualJoystick = null;
    }

    public void RemoveControlable ()
    {
        _controlable = null;
    }

    void Update()
    {
#if UNITY_EDITOR
        HandleMouseInputs();
#else
        HandleTouchInputs();
#endif
    }

    private void HandleMouseInputs ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _refPosition = Input.mousePosition;
            if (_controlable != null) _controlable.SetIsMoving(true);
            if (_virtualJoystick != null)
            {
                _virtualJoystick.AnchorJoystick(Input.mousePosition);
                _virtualJoystick.DisplayJoystick(true);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (_controlable != null) _controlable.SetIsMoving(false);
            if (_virtualJoystick != null) _virtualJoystick.DisplayJoystick(false);
        }
        if (Input.GetMouseButton(0))
        {
            if (_controlable != null)
            {
                Vector3 newPos = Input.mousePosition;
                Vector3 delta = newPos - _refPosition;
                _controlable.SetMovementDirection(-delta.x, -delta.y);
                if (_virtualJoystick != null) _virtualJoystick.UpdateStickPosition(delta);
            }
        }
    }

    private void HandleTouchInputs()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _refPosition = touch.position;
                    if (_controlable != null) _controlable.SetIsMoving(true);
                    if (_virtualJoystick != null)
                    {
                        _virtualJoystick.AnchorJoystick(touch.position);
                        _virtualJoystick.DisplayJoystick(true);
                    }
                    break;

                case TouchPhase.Ended:
                    if (_controlable != null) _controlable.SetIsMoving(false);
                    if (_virtualJoystick != null) _virtualJoystick.DisplayJoystick(false);
                    break;
                case TouchPhase.Canceled:
                    if (_controlable != null) _controlable.SetIsMoving(false);
                    if (_virtualJoystick != null) _virtualJoystick.DisplayJoystick(false);
                    break;
                case TouchPhase.Moved:
                    if (_controlable != null)
                    {
                        Vector3 newPos = touch.position;
                        Vector3 delta = newPos - _refPosition;
                        _controlable.SetMovementDirection(-delta.x, -delta.y);
                        if (_virtualJoystick != null) _virtualJoystick.UpdateStickPosition(delta);
                    }
                    break;
                case TouchPhase.Stationary:
                    if (_controlable != null)
                    {
                        Vector3 newPos = touch.position;
                        Vector3 delta = newPos - _refPosition;
                        _controlable.SetMovementDirection(-delta.x, -delta.y);
                        if (_virtualJoystick != null) _virtualJoystick.UpdateStickPosition(delta);
                    }
                    break;
            }
        }
    }
}
