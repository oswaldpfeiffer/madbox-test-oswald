using UnityEngine;

public interface IDamageableController
{
    Transform GetPositionTransform();
    void InitLife(SOHealth health);
    void TakeDamage(float damages);
    void Die();
}
