using UnityEngine;

public class HeroModel : IHeroModel
{
    private float _speed = 4f; // TO BE REPLACED WITH WEAPON SPEED

    public int Health { get; set; }

    public Vector3 GetMoveVector(float x, float y)
    {
       return new Vector3(x, 0, y).normalized * Time.deltaTime * _speed;
    }

    public float GetLookAngle (float x, float y)
    {
        float angleInRadians = Mathf.Atan2(x, y);
        return angleInRadians* Mathf.Rad2Deg;
    }
}
