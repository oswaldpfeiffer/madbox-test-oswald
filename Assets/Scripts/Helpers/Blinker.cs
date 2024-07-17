using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _skinnedMesh;
    [SerializeField] private float DecreaseFactor;
    private float _blinkValue;

    private bool resetCol;

    public void Blink()
    {
        _blinkValue = 1f;
        resetCol = false;
    }

    private void Update()
    {
        if (_blinkValue > 0)
        {
            SetColor(_blinkValue);
            _blinkValue -= Time.deltaTime * DecreaseFactor;
        } else
        {
            if (!resetCol)
            {
                SetColor(0f);
                resetCol = true;
            }
        }
    }

    private void SetColor (float col)
    {
        Material m = _skinnedMesh.material;
        m.SetColor("_EmissionColor", new Color(col, col, col));
        _skinnedMesh.material = m;
    }
}
