using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemDisplay : MonoBehaviour
{
    public List<Sprite> ItemSprites;

    private Image itemImage;

    void Start()
    {
        itemImage = GetComponentInChildren<Image>();
    }

    public void ChangeItem()
    {
        // Choose a random item sprite
        int randomIndex = Random.Range(0, ItemSprites.Count);

        // Set the item sprite of the first Image component found in the hierarchy
        Image image = GetComponentInChildren<Image>();
        if (image != null)
        {
            image.sprite = ItemSprites[randomIndex];
        }
        else
        {
            Debug.LogError("No Image component found in ItemDisplay hierarchy.");
        }
    }
}
