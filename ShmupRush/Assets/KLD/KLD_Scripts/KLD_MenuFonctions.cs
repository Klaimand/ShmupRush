using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KLD_MenuFonctions : MonoBehaviour
{
    [SerializeField]
    GameObject resumeCanvas;

    private bool isResumeScreenOpened;

    // Start is called before the first frame update
    void Start()
    {
        closeResumeScreen();
        isResumeScreenOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        switchResumeScreenOnEscapeKey();
    }

    void switchResumeScreenOnEscapeKey ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isResumeScreenOpened)
            {
                closeResumeScreen();
            }
            else
            {
                openResumeScreen();
            }
        }
    }

    public void openResumeScreen ()
    {
        Time.timeScale = 0f;
        resumeCanvas.SetActive(true);
        isResumeScreenOpened = true;
    }

    public void closeResumeScreen()
    {
        Time.timeScale = 1f;
        resumeCanvas.SetActive(false);
        isResumeScreenOpened = false;
    }

    public bool GetResumeScreenState ()
    {
        return isResumeScreenOpened;
    }

    public void restartScene ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
