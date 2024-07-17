using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hit : MonoBehaviour, IHit
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _destructionDelay;

    public void SetHit(IDamageableController controller, SOHeroWeapon weapon)
    {
        _text.text = Mathf.CeilToInt(weapon.Damages).ToString();
        transform.position = controller.GetPositionTransform().position + new Vector3(0, 0.5f,0);
        Destroy(this.gameObject, _destructionDelay);
        VertexGradient v = _text.colorGradient;
        v.topLeft = weapon.DamageHitColor;
        v.topRight = weapon.DamageHitColor;
        _text.colorGradient = v;
    }
}
