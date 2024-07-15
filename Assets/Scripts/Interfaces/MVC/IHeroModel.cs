using UnityEngine;

public interface IHeroModel : IModel, IDamageableModel
{
    Vector3 GetMoveVector(float x, float y);
    float GetLookAngle(float x, float y);
}
