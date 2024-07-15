using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggle : MonoBehaviour
{
    [SerializeField] private GameObject KnobRight;
    [SerializeField] private GameObject KnobLeft;
    [SerializeField] private GameObject BackgroundActive;
    [SerializeField] private Button _toggleButton;

    public void SetActiveState (bool isActive)
    {
        BackgroundActive.SetActive(isActive);
        KnobRight.SetActive(isActive);
        KnobLeft.SetActive(!isActive);
    }

    public Button GetToggleButton ()
    {
        return _toggleButton;
    }
}
