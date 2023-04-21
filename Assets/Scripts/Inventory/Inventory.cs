using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> items;// = new List<Item>();

    public int maxSpace = 9;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChanged;

    private void Awake()
    {
        instance = this;
        items = new List<Item>();
    }

    public bool Add(Item addItem)
    {
        if (items.Count >= maxSpace)
        {
            return false;
        }
        items.Add(addItem);
        onItemChanged?.Invoke();
        return true;
    }

    public void Remove(Item removeItem)
    {
        items.Remove(removeItem);
        onItemChanged?.Invoke();
    }
}
