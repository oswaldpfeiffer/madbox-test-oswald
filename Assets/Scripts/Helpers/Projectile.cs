using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _model;

    public float Damages { get; set; }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * _moveSpeed * Time.deltaTime;
        _model.Rotate(new Vector3(1, 0.5f, 1.5f));
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
