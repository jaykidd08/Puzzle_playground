using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCrafting : InteractableObject
{
    
    public override void Interact()
    {
        if (Inventory.hasAllLauncherKeys)
        {
            ToolSelection.hasLauncher = true;
            //code to display tool has been crafted
            Debug.Log("Launcher Crafted");
            Inventory.hasAllLauncherKeys = false;
            //Remove items from inventory
        }
        else if (Inventory.hasAllDimensionalKeys)
        {
            ToolSelection.hasDimensionalGoggles = true;
            //code to display tool has been crafted
            Debug.Log("Dimensional Goggles Crafted");
            Inventory.hasAllDimensionalKeys = false;
            //Remove items from inventotry
        }
        else if (Inventory.hasAllMiniKeys)
        {
            ToolSelection.hasMiniMan = true;
            //code to display tool has been crafted
            Debug.Log("Mini-Man Crafted");
            Inventory.hasAllMiniKeys = false;
            //Remove items from inventory
        }
        else
        {

        }
    }

}
