using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KLD_MainMenuFonctions : MonoBehaviour
{



    public void goToGame()
    {
        SceneManager.LoadScene("KLD_EmptyRoom");
    }

}
