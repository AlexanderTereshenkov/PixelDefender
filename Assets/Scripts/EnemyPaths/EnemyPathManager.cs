using UnityEngine;

public class EnemyPathManager : MonoBehaviour
{
    [SerializeField] private EnemyPathHolder[] enemyPathHolder;

    public EnemyPathHolder GetEnemyPathHolder() => enemyPathHolder[Random.Range(0, enemyPathHolder.Length)];
}
