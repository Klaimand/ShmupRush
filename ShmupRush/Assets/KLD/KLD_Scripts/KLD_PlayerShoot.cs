using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KLD_PlayerShoot : MonoBehaviour
{
    KLD_MenuFonctions menuFonctions;


    [SerializeField]
    private float shootDelayWhenButtonIsPressed = 0f;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    Transform canon;


    float curTimeSinceLastShot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        menuFonctions = GameObject.Find("GameManager").GetComponent<KLD_MenuFonctions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!menuFonctions.GetResumeScreenState()) {
            checkPlayerShoot();
        }
    }

    void checkPlayerShoot ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PlayerShoot();
            curTimeSinceLastShot = 0;
        }
        else if (Input.GetButton("Fire1"))
        {
            if (curTimeSinceLastShot > shootDelayWhenButtonIsPressed)
            {
                PlayerShoot();
                curTimeSinceLastShot = 0f;
            }
            curTimeSinceLastShot += Time.deltaTime;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            curTimeSinceLastShot = 0f;
        }
    }

    void PlayerShoot ()
    {
        Instantiate(bullet, canon.position, canon.rotation);
    }
}
