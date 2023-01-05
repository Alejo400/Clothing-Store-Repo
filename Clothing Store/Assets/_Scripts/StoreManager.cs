using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{

    public static StoreManager _sharedIntance;
    Dictionary<string, GameObject> listSelectedItems = new Dictionary<string, GameObject>();
    string buyerPersonName;
    GameObject buyerPerson;
    private void Awake()
    {
        if (_sharedIntance == null)
            _sharedIntance = this;
        else
            Destroy(this);
    }
    private void Start()
    {
        buyerPersonName = "Mary Sky";
    }
    /// <summary>
    /// add selected item of the store
    /// </summary>
    /// <param name="item">Prefab of selected item</param>
    public void AddItemToInventory(GameObject item)
    {
        listSelectedItems.Add(item.name, item);
    }
    public void RemoveItemOfInventory(GameObject item)
    {
        listSelectedItems.Remove(item.name);
    }
    public void RemoveAllItemsOfInventory()
    {
        listSelectedItems.Clear();
    }
    public void BuySelectedItems()
    {
        buyerPerson = GameObject.Find(buyerPersonName);
        foreach (var items in listSelectedItems)
        {
            if (buyerPerson.GetComponent<PlayerController>().myPurchasedItems.ContainsKey(items.Key))
            {
                buyerPerson.GetComponent<PlayerController>().myPurchasedItems.Add(items.Key + Random.Range(1, 999), items.Value);
            }
            else
            {
                buyerPerson.GetComponent<PlayerController>().myPurchasedItems.Add(items.Key, items.Value);
            }
        }
        UIManager._sharedIntance.HideStoreInventory();
    }
}
