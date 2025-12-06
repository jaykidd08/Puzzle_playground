using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnDoor : InteractableObject
{
    public string sceneEntrance;
    public override void Interact()
    {
        Inventory.LauncherKeys = 0;
        Inventory.DimensionalKeys = 0;
        Inventory.MiniKeys = 0;
        SceneManager.LoadScene(sceneEntrance);

        
    }
}
