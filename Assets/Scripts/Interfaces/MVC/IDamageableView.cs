using UnityEngine;

public interface IDamageableView
{
    Transform MoveableTransform { get; set; }
    IHealthBar HealthBar { get; set; }
    void UpdateHealthBar(float ratio);
    void PlayHitAnimation();
    void PlayDieAnimation();
}
