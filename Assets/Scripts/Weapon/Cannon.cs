using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float timeToShoot;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPoint;
    private float tempSeconds;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempSeconds += Time.deltaTime;
        if (tempSeconds > timeToShoot)
        {
            Shoot();
            tempSeconds = 0;
        }

    }

    void Shoot()
    {
        Instantiate(bullet, spawnPoint.position, Quaternion.identity);

    }
}
