using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KLD_RotateCanon : MonoBehaviour
{

    float startRotation;



    [SerializeField]
    float maxRelativeAngle = 20f, speed = 5f;

    Vector2 minMaxAngles;


    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation.eulerAngles.z;
        minMaxAngles = new Vector2(startRotation - maxRelativeAngle, startRotation + maxRelativeAngle);
    }

    // Update is called once per frame
    void Update()
    {
        float frameZ = Mathf.SmoothStep(minMaxAngles.x, minMaxAngles.y, Mathf.PingPong(Time.time * speed, 1f));
        transform.rotation = Quaternion.Euler(0f, 0f, frameZ);
    }
}
