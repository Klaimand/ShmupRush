using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class KLD_EnemyLife : MonoBehaviour
{

    Collider2D col = null;

    [SerializeField]
    private int startHP = 3;

    private int curHP = 0;

    [SerializeField]
    GameObject explosionObj;

    [SerializeField]
    Vector3 explosionOffset;

    [Header("Damage Blink"), SerializeField]
    float blinkDuration = 0.5f;
    [SerializeField]
    float blinkTime = 0.05f;
    [SerializeField]
    SpriteRenderer spriteRenderer;


    private void Awake()
    {
        col = GetComponent<Collider2D>();
        curHP = startHP;
    }

    public void enemyTakeDamage()
    {
        if (curHP > 0)
        {
            StartCoroutine(blink());
            curHP--;
        }
        else
        {
            die();
        }
    }

    void die()
    {
        spawnExplosionObj();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("takeDamage");
            die();
        }
    }

    void spawnExplosionObj()
    {
        Instantiate(explosionObj, transform.position + explosionOffset, Quaternion.Euler(0f, 0f, Random.value * 360f));
    }

    IEnumerator blink()
    {
        float curBlinkDuration = 0f, curBlinkTime = 0f;
        bool isColored = false;
        while (curBlinkDuration < blinkDuration)
        {
            if (curBlinkTime > blinkTime)
            {
                if (!isColored)
                {
                    spriteRenderer.color = Color.red;
                    //color
                }
                else
                {
                    spriteRenderer.color = Color.white;
                    //remove color
                }
                isColored = !isColored;
                curBlinkTime = 0f;
            }
            curBlinkDuration += Time.deltaTime;
            curBlinkTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = Color.white;

    }

}
