using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image icon;
    public Button xbtn;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        xbtn.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        xbtn.interactable = false;
    }

    public void OnXbtnClicked()
    {
        Inventory.instance.Remove(item);
    }

    public void OnItemBtnClicked()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
