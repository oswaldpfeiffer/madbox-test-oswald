using UnityEngine;

public interface IEnemyModel : IModel, IDamageableModel
{
    SOEnemyData EnemyData { get; set; }
    EEnemyState EnemyState { get; set; }
    void SetMoveTarget(Vector3 currentPosition, Vector3 heroPosition);
    Vector3 GetMoveTarget();
    float GetReachTargetDuration();
}
