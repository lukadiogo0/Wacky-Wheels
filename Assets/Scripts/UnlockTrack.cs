using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UnlockTrack : MonoBehaviour
{
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;

    public GameObject level2Unlock, level3Unlock, level4Unlock;



    

    // Update is called once per frame
    void Update()
    {
        //inserir condicao que torna interactable
        Level2.GetComponent<Button>().interactable = true; 
        Level3.GetComponent<Button>().interactable = true; 
        Level4.GetComponent<Button>().interactable = true; 


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

    public void SelectLevel2(){
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(level2Unlock);
    }
    public void SelectLevel3(){
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(level3Unlock);
    }
    public void SelectLevel4(){
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(level4Unlock);
    }
}
