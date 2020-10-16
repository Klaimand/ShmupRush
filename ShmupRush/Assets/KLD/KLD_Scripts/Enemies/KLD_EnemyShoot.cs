using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KLD_EnemyShoot : MonoBehaviour
{

    [SerializeField]
    private float fireRate = 0.3f;

    float timeSinceLastShoot = 0f;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    Transform canon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkShoot();
    }

    void checkShoot()
    {
        if (timeSinceLastShoot >= fireRate)
        {
            shoot();
            timeSinceLastShoot = 0f;
        }
        timeSinceLastShoot += Time.deltaTime;

    }

    void shoot()
    {
        Instantiate(bullet, canon.position, canon.rotation);
    }

}
