public interface IHeroController : IController, IDamageableController, IControllable
{
    void Initialize(IHeroModel model, SOHealth health, ILevelManager levelManager, IWeaponsManager weaponManager);
    void EquipWeapon(SOHeroWeapon weapon);
}
