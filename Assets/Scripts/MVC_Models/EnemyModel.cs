using UnityEngine;

public class EnemyModel : IEnemyModel
{
    public float Health { get ; set; }
    public bool IsAlive { get; set; }
    public float MaxHealth { get; set; }
    public SOEnemyData EnemyData { get; set; }
    public EEnemyState EnemyState { get; set; }

    private Vector3 _target = Vector3.zero;
    private float _targetDist = 0f;

    public Vector3 GetMoveTarget()
    {
        return _target;
    }

    public void SetMoveTarget(Vector3 currentPosition, Vector3 heroPosition)
    {
        Vector3 diff = heroPosition - currentPosition;
        diff -= (diff.normalized * EnemyData.OffsetDistance);
        _target = diff;
        _targetDist = diff.magnitude;
    }

    public float GetReachTargetDuration()
    {
        return _targetDist / EnemyData.MoveSpeed;
    }
}
