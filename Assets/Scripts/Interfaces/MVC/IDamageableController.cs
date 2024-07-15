public interface IDamageableController
{
    void InitLife(SOHealth health);
    void TakeDamage(int damages);
    void Die();
}
