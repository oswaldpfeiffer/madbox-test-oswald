using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDrop : MonoBehaviour
{
    [SerializeField] private Transform _weaponModelContainer;
    [SerializeField] private GameObject _onCollectSFX;

    private SOHeroWeapon _weapon;
    IWeaponsManager _weaponManager;

    public void Initialize (SOHeroWeapon weapon, IWeaponsManager weaponManager)
    {
        _weapon = weapon;
        _weaponManager = weaponManager;
        AddWeaponMesh();
    }

    private void AddWeaponMesh ()
    {
        GameObject mesh = _weaponManager.GetModelForWeaponSO(_weapon);
        GameObject instance = Instantiate(mesh, _weaponModelContainer);
    }

    public void OnCollect ()
    {
        GameObject sfx = Instantiate(_onCollectSFX);
        sfx.transform.position = transform.position + new Vector3(0, 0.5f, 0);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IHeroController heroController = other.GetComponent(typeof(IHeroController)) as IHeroController;
            heroController.EquipWeapon(_weapon);
            OnCollect();
        }
    }
}
