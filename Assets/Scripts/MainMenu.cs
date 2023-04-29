using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Load scene
    public void Play()
    {
        SceneManager.LoadScene("complete_track_demo");
        //SceneManager.LoadScene("Map1");
    }

    //Quit game
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Player has left the game");
    }

}
