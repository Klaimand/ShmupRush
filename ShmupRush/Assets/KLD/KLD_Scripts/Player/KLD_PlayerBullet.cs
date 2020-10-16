using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KLD_PlayerBullet : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField]
    private float bulletSpeed;

    [Space(10), SerializeField]
    private float timeToAutoDestroy;

    [SerializeField]
    bool isPlayerBullet = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoDestroyIn(timeToAutoDestroy));
    }

    private void Update()
    {
        //transform.position += transform.right * bulletSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.velocity = new Vector2(bulletSpeed, 0f);
        rb.velocity = (Vector2)transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.collider.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<KLD_EnemyLife>().takeDamage();
            Destroy(gameObject);
        }*/
        if (isPlayerBullet)
        {
            collision.gameObject.SendMessage("enemyTakeDamage", SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            collision.gameObject.SendMessage("takeDamage", SendMessageOptions.DontRequireReceiver);
        }
        Destroy(gameObject);

    }

    IEnumerator AutoDestroyIn(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
