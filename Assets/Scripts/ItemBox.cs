using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{
    public List<Sprite> ItemSprites;
    public GameObject ItemDisplayObject;
    public float respawnTime = 3f;

    private bool canRespawn = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canRespawn = false; // disable respawn flag
            gameObject.GetComponent<MeshRenderer>().enabled = false; // hide the item box
            GetComponent<Collider>().enabled = false; // disable the collider
            Debug.Log("DESTROYYYYYY!!!!!!!!!!");

            // choose a random item sprite
            int randomIndex = Random.Range(0, ItemSprites.Count);

            // get the item display child object
            GameObject itemDisplay = ItemDisplayObject.transform.Find("ItemDisplay").gameObject;

            // get the raw image component of the item image child object
            RawImage itemImage = itemDisplay.transform.Find("ItemImage").GetComponent<RawImage>();

            // set the item sprite
            itemImage.texture = ItemSprites[randomIndex].texture;
            Debug.Log("ITEM CHANGE!!!!!!!!!!");

            StartCoroutine(RespawnCoroutine());
        }
    }

    IEnumerator RespawnCoroutine()
    {
        Debug.Log("RespawnCoroutine started");
        yield return new WaitForSeconds(respawnTime);

        canRespawn = true; // enable respawn flag
        gameObject.GetComponent<MeshRenderer>().enabled = true; // show the item box
        GetComponent<Collider>().enabled = true; // enable the collider
        Debug.Log("APPEAAR!!!!!!!!!!");
    }

    void Update()
    {
        if (canRespawn && !gameObject.GetComponent<MeshRenderer>().enabled)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
