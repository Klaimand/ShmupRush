using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KLD_PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Camera mainCamera;
    private KLD_CameraScroll cameraScroller;

    public float playerSpeed;

    #region Axis Variables

    [Header("VirtualAxis"), SerializeField]
    private float xAxisSensitivity;
    [SerializeField]
    private float yAxisSensitivity;
    private float virtualXRawAxis, virtualYRawAxis, virtualXAxis, virtualYAxis;
    [SerializeField]
    private int XaccelerationFrame, XdecelerationFrame, YaccelerationFrame, YdecelerationFrame;

    #endregion

    [SerializeField]
    Vector2 playerSize;

    [SerializeField]
    bool isTooHigh, isTooLow, isTooLeft, isTooRight;
     
    //***********************************************************************************************************

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        cameraScroller = mainCamera.GetComponent<KLD_CameraScroll>();
    }

    // Update is called once per frame
    void Update()
    {
        manageVirtualRawAxis();
        manageVirtualXAxis();
        checkCameraBounds();
    }

    private void FixedUpdate()
    {
        doPlayerShipSpeed();
    }

    private void manageVirtualRawAxis()
    {
        /* X AXIS
         * 
         * 
         * 
         * 
         */

        if (Input.GetAxisRaw("Horizontal") >= xAxisSensitivity)
        {
            virtualXRawAxis = 1f;
        }
        else if (Input.GetAxisRaw("Horizontal") <= -xAxisSensitivity)
        {
            virtualXRawAxis = -1f;
        }
        else
        {
            virtualXRawAxis = 0f;
        }

        /* Y AXIS
         * 
         * 
         * 
         * 
         */

        if (Input.GetAxisRaw("Vertical") >= xAxisSensitivity)
        {
            virtualYRawAxis = 1f;
        }
        else if (Input.GetAxisRaw("Vertical") <= -xAxisSensitivity)
        {
            virtualYRawAxis = -1f;
        }
        else
        {
            virtualYRawAxis = 0f;
        }
    }

    private void manageVirtualXAxis()
    {

        /* X AXIS
         * 
         * 
         * 
         * 
         */

        if (virtualXRawAxis == 1f && virtualXAxis < 1f)
        {
            virtualXAxis += 1f / (float)XaccelerationFrame;
        }
        else if (virtualXRawAxis == -1f && virtualXAxis > -1f)
        {
            virtualXAxis -= 1f / (float)XaccelerationFrame;
        }
        else if (virtualXRawAxis == 0f)
        {
            if (virtualXAxis > 0f)
            {
                virtualXAxis -= 1f / (float)XdecelerationFrame;
            }
            if (virtualXAxis < 0f)
            {
                virtualXAxis += 1f / (float)XdecelerationFrame;
            }
        }

        if (virtualXAxis > 1f)
        {
            virtualXAxis = 1f;
        }
        else if (virtualXAxis < -1f)
        {
            virtualXAxis = -1f;
        }
        else if (virtualXRawAxis == 0f && virtualXAxis > -(1f / (float)XdecelerationFrame) && virtualXAxis < 1f / (float)XdecelerationFrame)
        {
            virtualXAxis = 0f;
        }

        /* Y AXIS
         * 
         * 
         * 
         * 
         */

        if (virtualYRawAxis == 1f && virtualYAxis < 1f)
        {
            virtualYAxis += 1f / (float)YaccelerationFrame;
        }
        else if (virtualYRawAxis == -1f && virtualYAxis > -1f)
        {
            virtualYAxis -= 1f / (float)YaccelerationFrame;
        }
        else if (virtualYRawAxis == 0f)
        {
            if (virtualYAxis > 0f)
            {
                virtualYAxis -= 1f / (float)YdecelerationFrame;
            }
            if (virtualYAxis < 0f)
            {
                virtualYAxis += 1f / (float)YdecelerationFrame;
            }
        }

        if (virtualYAxis > 1f)
        {
            virtualYAxis = 1f;
        }
        else if (virtualYAxis < -1f)
        {
            virtualYAxis = -1f;
        }
        else if (virtualYRawAxis == 0f && virtualYAxis > -(1f / (float)YdecelerationFrame) && virtualYAxis < 1f / (float)YdecelerationFrame)
        {
            virtualYAxis = 0f;
        }
    }

    private void doPlayerShipSpeed ()
    {
        Vector2 axisVector = new Vector2(virtualXAxis, virtualYAxis);

        if (isTooHigh && axisVector.y > 0f)
        {
            axisVector = new Vector2(axisVector.x, 0f);
        }
        else if (isTooLow && axisVector.y < 0f)
        {
            axisVector = new Vector2(axisVector.x, 0f);
        }

        if (isTooLeft && axisVector.x < 0f)
        {
            axisVector = new Vector2(0f, axisVector.y);
        }
        else if (isTooRight && axisVector.x > 0f)
        {
            axisVector = new Vector2(0f, axisVector.y);
        }


        if (axisVector.magnitude > 1f)
        {
            axisVector.Normalize();
        }

        rb.velocity = (Vector2.right * cameraScroller.GetCameraSpeed()) + (axisVector * playerSpeed);

    }

    private void checkCameraBounds ()
    {
        isTooHigh = false;
        isTooLow = false;
        isTooLeft = false;
        isTooRight = false;

        Vector2 cameraPosition = mainCamera.transform.position;

        //X
        if (transform.position.x <= mainCamera.transform.position.x - (mainCamera.orthographicSize * 16f/9f))
        {
            isTooLeft = true;
        }
        else if (transform.position.x + playerSize.x >= mainCamera.transform.position.x + (mainCamera.orthographicSize * 16f / 9f))
        {
            isTooRight = true;
        }




        //Y
        if (transform.position.y + playerSize.y/2f >= mainCamera.orthographicSize)
        {
            isTooHigh = true;
        }
        else if (transform.position.y - playerSize.y / 2f <= -mainCamera.orthographicSize)
        {
            isTooLow = true;
        }



    }
}
