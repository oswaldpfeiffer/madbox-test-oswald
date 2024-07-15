using UnityEngine;

public interface ILevelManager
{
    IEnemyController GetClosestEnemy(Vector3 position);
}
