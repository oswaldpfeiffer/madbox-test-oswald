using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicesProvider : MonoBehaviour
{
    [SerializeField] private GameObject ServicesPrefab;
    [SerializeField] private GameObject PersistentUIPrefab;

    void Awake()
    {
        if (ServiceLocator.Instance == null)
        {
            Instantiate(ServicesPrefab);
        }

        if (PersistentUIManager.Instance == null)
        {
            Instantiate(PersistentUIPrefab);
        }
    }
}
