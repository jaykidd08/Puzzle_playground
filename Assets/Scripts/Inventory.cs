using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Search;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();

    public GameObject inventoryUI;

    public PagePickup pageOverlay;

    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();

    public static int LauncherKeys = 0;
    public static int DimensionalKeys = 0;
    public static int MiniKeys = 0;

    public static bool hasAllLauncherKeys = false;
    public static bool hasAllMiniKeys = false;
    public static bool hasAllDimensionalKeys = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    }
    public void Add (Item item)
    {
        items.Add(item);

        //Check what tool each item belongs to and update the corresponding total keys
        if (item.itemName.Contains("Launcher Part"))
        {
            LauncherKeys++;
        }
        else if (item.itemName.Contains("Dimensional Vision Part"))
        {
            DimensionalKeys++;
        }
        else if (item.itemName.Contains("Mini-Man Part"))
        {
            MiniKeys++;
        }

        pageOverlay.DisplayPage(item.itemDescription);

        //Check if keys in each level have been obtained to set Boolean values to true
        if (MiniKeys >= 3)
        {
            hasAllMiniKeys = true;
            Debug.Log("Mini Keys Gathered");
        }
        else if (DimensionalKeys >= 3)
        {
            hasAllDimensionalKeys = true;
        }
        else if (LauncherKeys >= 3)
        {
            hasAllLauncherKeys = true;
        }

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void Remove (Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

    }


}
