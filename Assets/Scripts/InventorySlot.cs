
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image itemImage;

    public void AddItem(Item newItem)
    {
        item = newItem;
        itemImage.sprite = item.icon;
        itemImage.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
        itemImage.enabled = false;
    }
}
