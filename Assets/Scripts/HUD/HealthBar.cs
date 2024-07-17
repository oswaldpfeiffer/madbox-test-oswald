using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IHealthBar
{
    [SerializeField] Image _fill;

    public void SetFillAmount(float ratio)
    {
        _fill.fillAmount = ratio;
    }

    public void SetVisible(bool state)
    {
        gameObject.SetActive(state);
    }
}
