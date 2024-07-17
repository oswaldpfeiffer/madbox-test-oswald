public interface IInputsManager : IService
{
    void SetControllable(IControllable controlable);
    void SetVirtualJoystick(IVirtualJoystick joystick);
}
