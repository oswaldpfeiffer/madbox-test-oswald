using UnityEngine;

public interface IVirtualJoystick
{
    void UpdateStickPosition(Vector3 direction);
    void DisplayJoystick(bool state);
    void AnchorJoystick(Vector3 touchPosition);
}
