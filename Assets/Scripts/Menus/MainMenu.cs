using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayTutorial()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        FindObjectOfType<SoundManagerScriptALOY>().Play("Tutorial");
        FindObjectOfType<SoundManagerScriptALOY>().Pause("Menu");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        FindObjectOfType<SoundManagerScriptALOY>().Pause("Menu");
    }
    void Start()
    {
        FindObjectOfType<SoundManagerScriptALOY>().Play("Menu");
        FindObjectOfType<SoundManagerScriptALOY>().Pause("Theme");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
