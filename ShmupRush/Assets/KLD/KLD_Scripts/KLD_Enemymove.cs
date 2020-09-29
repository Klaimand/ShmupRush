using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KLD_Enemymove : MonoBehaviour
{
    [SerializeField]
    Vector2 moveVector = Vector2.zero;
    [SerializeField]
    float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)moveVector.normalized * speed * Time.deltaTime;
    }
}
