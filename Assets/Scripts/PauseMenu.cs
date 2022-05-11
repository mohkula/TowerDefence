using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{
    public string mainMenu = "MainMenu";

public GameObject ui;
public GameObject musicController;



void Update ()
{

    if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
    {
        Toggle();
    }
}

public void Toggle ()
{
    ui.SetActive(!ui.activeSelf);

    if(ui.activeSelf)
    {
        Time.timeScale = 0f;
        
    }
    else
    {
        Time.timeScale = 1f;
    }
}

    public void Retry ()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu ()
    {
        Toggle();
        SceneManager.LoadScene(mainMenu);



    }

    public void Mute()
    {
        
        
        musicController.GetComponent<AudioSource>().mute =  !musicController.GetComponent<AudioSource>().mute;
    }


}
