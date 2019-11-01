/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfKeys;
    public int coins;
    public float maxMagic = 12;
    public float currentMagic;

    public void OnEnable()
    {
        currentMagic = maxMagic;
    }

    public void ReduceMagic(float magicCost)
    {
        currentMagic -= magicCost;
    }

    public bool CheckForItem(Item item)
    {
        if(items.Contains(item))
        {
            return true;
        }
        return false;

    }

    public void AddItem(Item itemToAdd)
    {
        // Is the item a key?
        if(itemToAdd.isKey)
        {
            numberOfKeys++;
        }
        else
        {
            if(!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }

        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Player Inventory", fileName = "New Player Inventory")]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> myInventory = new List<Item>();

    public void AddItem(Item newItem)
    {
        if (!myInventory.Contains(newItem))
        {
            myInventory.Add(newItem);
        }
        else
        {
            newItem.numberHeld++;
        }
    }

    public void RemoveItem(Item newItem)
    {
        if (myInventory.Contains(newItem))
        {
            myInventory.Remove(newItem);
        }
    }

    public void UseItem(Item newItem)
    {
        if (myInventory.Contains(newItem))
        {
            if (newItem.numberHeld > 0)
            {
                newItem.numberHeld--;
            }
        }
    }

    public bool IsItemInInventory(Item newItem)
    {
        return myInventory.Contains(newItem);
    }

    public bool canUseItem(Item newItem)
    {
        return newItem.numberHeld > 0;
    }

}


