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
        if (Input.GetKeyDown(KeyCode.A))
        {
            gainHP();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            takeDamage();
        }
    }

    public void gainHP ()
    {
        curHP++;
        refreshHpDisplay();
    }

    public void takeDamage ()
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

    void die ()
    {
        menuFonctions.popGameOver();
        print("isdead");
    }

    void refreshHpDisplay ()
    {
        hpDisplayText.text = curHP > 99 ? "99+" : curHP.ToString();
    }

}
