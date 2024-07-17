public interface IHeroController : IController, IDamageableController, IControllable
{
    void Initialize(IHeroModel model, SOHeroData data, ILevelManager levelManager, IWeaponsManager weaponManager, IAudioManager audioManager);
    void EquipWeapon(SOHeroWeapon weapon);
}
