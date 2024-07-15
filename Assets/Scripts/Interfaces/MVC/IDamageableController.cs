using UnityEngine;

public interface IDamageableController
{
    Transform GetPositionTransform();
    void InitLife(SOHealth health);
    void TakeDamage(int damages);
    void Die();
}
