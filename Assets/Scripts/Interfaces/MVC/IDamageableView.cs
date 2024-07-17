using UnityEngine;

public interface IDamageableView
{
    Transform MoveableTransform { get; set; }
    void UpdateHealthBar(float ratio);
    void DisplayHealthBar(bool display);
    void PlayHitAnimation();
    void PlayDieAnimation();
}
