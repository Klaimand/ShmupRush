using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KLD_TriggerOnCam : MonoBehaviour
{
    Transform cameraTransform = null;
    Camera mainCamera = null;

    [SerializeField]
    GameObject[] objectToTrigger;

    bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        mainCamera = cameraTransform.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!triggered && cameraTransform.position.x + mainCamera.orthographicSize * 16f / 9f > transform.position.x)
        {
            triggered = true;
            foreach(GameObject go in objectToTrigger)
            {
                go.SetActive(true);
            }
        }
    }
}
