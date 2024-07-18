public interface IInputsManager : IService
{
    void SetControllable(IControllable controlable);
    void SetVirtualJoystick(IVirtualJoystick joystick);
    void RemoveVirtualJoystick();
    void RemoveControlable();
}
