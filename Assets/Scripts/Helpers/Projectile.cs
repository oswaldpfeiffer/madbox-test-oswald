using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    public float Damages { get; set; }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * _moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IHeroController heroController = other.GetComponent(typeof(IHeroController)) as IHeroController;
            heroController.TakeDamage(Damages);
            Destroy(this.gameObject);
        }
    }
}
