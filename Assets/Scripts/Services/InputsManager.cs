using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsManager : BaseService<IInputsManager>, IInputsManager
{
    private IControllable _controlable;
    private Vector3 _refPosition;

    public void SetControllable(IControllable controlable)
    {
        _controlable = controlable;
    }

    void Update()
    {
        if (_controlable == null) return;
        HandleTouchMouseInputs();
    }

    public void HandleTouchMouseInputs ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _refPosition = Input.mousePosition;
            _controlable.SetIsMoving(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _controlable.SetIsMoving(false);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 newPos = Input.mousePosition;
            Vector3 delta = newPos - _refPosition;
            _controlable.SetMovementDirection(-delta.x, -delta.y);
        }
    }
}
