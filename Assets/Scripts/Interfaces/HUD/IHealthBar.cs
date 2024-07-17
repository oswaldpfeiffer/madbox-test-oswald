using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthBar
{
    void SetVisible(bool state);
    void SetFillAmount(float ratio);
}
