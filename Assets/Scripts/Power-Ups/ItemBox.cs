using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{
    public List<Sprite> ItemSprites;
    public GameObject ItemDisplayObject;
    public float respawnTime = 3f;

    public Sprite defaultSprite;

    private bool canRespawn = true;


    private void OnTriggerEnter(Collider other)
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

            // check if the chosen item is a rocket
            if (ItemSprites[randomIndex].name == "Shroom")
            {
                // set the rocket power-up flag to true
                RocketController.hasRocketPowerup = true;
                RocketController.rocketHasBeenUsed = false;

            }
            else
            {
                RocketController.hasRocketPowerup = false;
                RocketController.rocketHasBeenUsed = false;
            }



            if (ItemSprites[randomIndex].name == "Star")
            {
                // set the propulsor power-up flag to true
                Propulsor.hasPropulsorPowerup = true;
                Propulsor.propulsorHasBeenUsed = false;
            }
            else
            {
                Propulsor.hasPropulsorPowerup = false;
                Propulsor.propulsorHasBeenUsed = false;
            }



            if (ItemSprites[randomIndex].name == "Coin")
            {
                Obstacle.hasObstacle = true;
                Obstacle.obstacleHasBeenUsed = false;
            }
            else
            {
                Obstacle.hasObstacle = false;
                Obstacle.obstacleHasBeenUsed = false;
            }



            if (ItemSprites[randomIndex].name == "Shrink")
            {
                ShrinkController.hasShrinkPowerup = true;
                ShrinkController.shrinkHasBeenUsed = false;
            }
            else
            {
                ShrinkController.hasShrinkPowerup = false;
                ShrinkController.shrinkHasBeenUsed = false;
            }



            if (ItemSprites[randomIndex].name == "Shield")
            {
                Shield.hasShield = true;
                Shield.shieldHasBeenUsed = false;
            }
            else
            {
                Shield.hasShield = false;
                Shield.shieldHasBeenUsed = false;
            }



            StartCoroutine(RespawnCoroutine());
        }
    }

    private IEnumerator RespawnCoroutine()
    {
        Debug.Log("RespawnCoroutine started");
        yield return new WaitForSeconds(respawnTime);


        canRespawn = true; // enable respawn flag
        gameObject.GetComponent<MeshRenderer>().enabled = true; // show the item box
        GetComponent<Collider>().enabled = true; // enable the collider
        Debug.Log("APPEAAR!!!!!!!!!!");
    }

    private void Update()
    {
        if(RocketController.hasRocketPowerup == false && RocketController.rocketHasBeenUsed == true)
        {
            // get the item display child object
            GameObject itemDisplay = ItemDisplayObject.transform.Find("ItemDisplay").gameObject;

            // get the raw image component of the item image child object
            RawImage itemImage = itemDisplay.transform.Find("ItemImage").GetComponent<RawImage>();
            itemImage.texture = defaultSprite.texture;
            RocketController.rocketHasBeenUsed = false;
        }

        if (Propulsor.hasPropulsorPowerup == false && Propulsor.propulsorHasBeenUsed == true)
        {
            // get the item display child object
            GameObject itemDisplay = ItemDisplayObject.transform.Find("ItemDisplay").gameObject;

            // get the raw image component of the item image child object
            RawImage itemImage = itemDisplay.transform.Find("ItemImage").GetComponent<RawImage>();
            itemImage.texture = defaultSprite.texture;
            Propulsor.propulsorHasBeenUsed = false;
        }


        if (Obstacle.hasObstacle == false && Obstacle.obstacleHasBeenUsed == true)
        {
            // get the item display child object
            GameObject itemDisplay = ItemDisplayObject.transform.Find("ItemDisplay").gameObject;

            // get the raw image component of the item image child object
            RawImage itemImage = itemDisplay.transform.Find("ItemImage").GetComponent<RawImage>();
            itemImage.texture = defaultSprite.texture;
            Obstacle.obstacleHasBeenUsed = false;
        }

        if (ShrinkController.hasShrinkPowerup == false && ShrinkController.shrinkHasBeenUsed == true)
        {
            // get the item display child object
            GameObject itemDisplay = ItemDisplayObject.transform.Find("ItemDisplay").gameObject;

            // get the raw image component of the item image child object
            RawImage itemImage = itemDisplay.transform.Find("ItemImage").GetComponent<RawImage>();
            itemImage.texture = defaultSprite.texture;
            Obstacle.obstacleHasBeenUsed = false;
        }

        if (Shield.hasShield == false && Shield.shieldHasBeenUsed == true)
        {
            // get the item display child object
            GameObject itemDisplay = ItemDisplayObject.transform.Find("ItemDisplay").gameObject;

            // get the raw image component of the item image child object
            RawImage itemImage = itemDisplay.transform.Find("ItemImage").GetComponent<RawImage>();
            itemImage.texture = defaultSprite.texture;
            Obstacle.obstacleHasBeenUsed = false;
        }

        if (canRespawn && !gameObject.GetComponent<MeshRenderer>().enabled)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
