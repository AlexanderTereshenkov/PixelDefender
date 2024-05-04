using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour
{
    public static CannonManager main;

    [Header("References")]
    [SerializeField] private GameObject cannonPrefab;

    private void Awake()
    {
        main = this;
    }

    public GameObject GetCannon()
    {
        return cannonPrefab;
    }
}

