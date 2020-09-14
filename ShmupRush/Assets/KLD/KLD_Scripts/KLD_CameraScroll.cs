using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KLD_CameraScroll : MonoBehaviour
{
    [SerializeField]
    private float curCameraSpeed = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * curCameraSpeed * Time.deltaTime;
    }

    /*
    private void FixedUpdate()
    {
        transform.position += Vector3.right * curCameraSpeed * Time.fixedDeltaTime;
    }*/

    public void SetCameraSpeed (float newCameraSpeed)
    {
        curCameraSpeed = newCameraSpeed;
    }

    public float GetCameraSpeed ()
    {
        return curCameraSpeed;
    }

}
