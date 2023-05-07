using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockTrack : MonoBehaviour
{
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;

    

    // Update is called once per frame
    void Update()
    {
        //inserir condicao que torna interactable
        Level2.GetComponent<Button>().interactable = true; 
        Level3.GetComponent<Button>().interactable = true; 
        //Level4.GetComponent<Button>().interactable = true; 


    }

    public void Level2Unlock()
    {
        Level2.SetActive(false);
    }
    public void Level3Unlock()
    {
        Level3.SetActive(false);
    }
    public void Level4Unlock()
    {
        Level4.SetActive(false);
    }
}
