using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KLD_PlayerLife : MonoBehaviour
{

    Text hpDisplayText = null;

    [SerializeField]
    private int startHP = 3;

    private int curHP = 0;

    [SerializeField]
    GameObject explosionObj;

    [SerializeField]
    Vector2 explosionOffset;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    KLD_MenuFonctions menuFonctions;

    // Start is called before the first frame update
    void Start()
    {
        menuFonctions = GameObject.Find("GameManager").GetComponent<KLD_MenuFonctions>();

        hpDisplayText = GameObject.Find("LifeCanvas").transform.GetChild(0).GetComponent<Text>();

        curHP = startHP;
        refreshHpDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            gainHP();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            takeDamage();
        }*/
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Walls"))
        {
            die();
        }
    }

    public void gainHP()
    {
        curHP++;
        refreshHpDisplay();
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
        refreshHpDisplay();
    }

    void die()
    {
        menuFonctions.popGameOver();
        spawnExplosionObj();
        spriteRenderer.enabled = false;
        print("isdead");
    }

    void refreshHpDisplay()
    {
        hpDisplayText.text = curHP > 99 ? "99+" : curHP.ToString();
    }

    void spawnExplosionObj()
    {
        Instantiate(explosionObj, transform.position + (Vector3)explosionOffset, Quaternion.Euler(0f, 0f, Random.value * 360f));
    }

}
