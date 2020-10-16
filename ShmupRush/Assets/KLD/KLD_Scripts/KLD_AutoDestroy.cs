using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KLD_AutoDestroy : MonoBehaviour
{

    [SerializeField]
    float timeToDestroy = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
