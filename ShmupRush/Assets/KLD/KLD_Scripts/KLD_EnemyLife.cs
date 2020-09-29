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

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }
    
    public void takeDamage()
    {
        if (curHP > 0)
        {
            curHP--;
        }
        else
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<KLD_PlayerLife>().takeDamage();
            die();
        }
    }
}
