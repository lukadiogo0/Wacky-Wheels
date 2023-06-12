using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Load scene
    private DoNotDestroy doNotDestroyScript;

      private void Start()
    {
        doNotDestroyScript = GameObject.FindGameObjectWithTag("Game Music").GetComponent<DoNotDestroy>();
    }
   
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Level1(){
        doNotDestroyScript.StopMusic();
        SceneManager.LoadScene(1);
    }
    public void Level2(){
        doNotDestroyScript.StopMusic();
        SceneManager.LoadScene(2);
    }
    public void Level3(){
        doNotDestroyScript.StopMusic();
        SceneManager.LoadScene(3);
    }
    public void Level4(){
        doNotDestroyScript.StopMusic();
        SceneManager.LoadScene(4);
    }
     public void TrackSelector()
    {
        SceneManager.LoadScene(5);
    }
    

    //Quit game
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Player has left the game");
    }

    
}
