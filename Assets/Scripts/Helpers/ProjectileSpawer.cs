using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawer : MonoBehaviour, IProjectileSpawner
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _shootPosition;

    public void Shoot (float damages)
    {
        GameObject projectile = Instantiate(_projectilePrefab);
        projectile.transform.position = _shootPosition.position;
        projectile.transform.rotation = _shootPosition.rotation;
        projectile.GetComponent<Projectile>().Damages = damages;
    }
}
