using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KLD_EnemyCosMvt : MonoBehaviour
{
    [SerializeField]
    float speed = 3f, amplitude = 3f, periodMultiplier = 1f;

    float curX = 0f;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos - new Vector3(curX, (Mathf.Sin(curX * periodMultiplier)) * amplitude, 0f);

        curX += Time.deltaTime * speed;
    }
}
