using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiecePickUp : InteractableObject
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp()
    {
        Debug.Log("You have picked up " + item.itemName);
        Inventory.instance.Add(item);
        //create code to add puzzle piece to inventory

        Destroy(gameObject);
    }
}
