using UnityEngine;

public interface IHeroView : IView, IDamageableView
{
    void Move(Vector3 moveVec, float rotationAngle);
    void SetMovement(bool move);
}
