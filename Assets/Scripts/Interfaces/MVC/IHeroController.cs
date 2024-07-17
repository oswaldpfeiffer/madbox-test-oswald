public interface IHeroController : IController, IDamageableController, IControllable
{
    void Initialize(IHeroModel model, SOHeroData data, ILevelManager levelManager, IWeaponsManager weaponManager);
    void EquipWeapon(SOHeroWeapon weapon);
}
