using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Load scene
   
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Level1(){
        SceneManager.LoadScene(1);
    }
    public void Level2(){
        SceneManager.LoadScene(1);
    }
    public void Level3(){
        SceneManager.LoadScene(1);
    }
    public void Level4(){
        SceneManager.LoadScene(1);
    }
     public void TrackSelector()
    {
        SceneManager.LoadScene(2);
    }
    

    //Quit game
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Player has left the game");
    }

    
}
