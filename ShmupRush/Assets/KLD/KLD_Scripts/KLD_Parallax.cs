using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KLD_Parallax : MonoBehaviour
{
    [SerializeField]
    float parallaxCoeff = 1f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.right * Time.deltaTime * 2f * parallaxCoeff;
    }
}
