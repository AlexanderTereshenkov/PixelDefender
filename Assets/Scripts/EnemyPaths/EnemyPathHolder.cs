using UnityEngine;

public class EnemyPathHolder : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    public Transform[] Waypoints() => waypoints;

}
