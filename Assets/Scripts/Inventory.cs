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

    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
    public void Add (Item item)
    {
        items.Add(item);

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
