using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{

    public static StoreManager _sharedIntance;
    Dictionary<string, GameObject[]> listSelectedItems = new Dictionary<string, GameObject[]>();
    string buyerPersonName;
    GameObject buyerPerson;
    public List<GameObject> purchasedItems = new List<GameObject>();
    private void Awake()
    {
        if (_sharedIntance == null)
            _sharedIntance = this;
        else
            Destroy(this);
    }
    private void Start()
    {
        //ToDo Improve how to get this value
        buyerPersonName = "Mary Sky";
    }
    /// <summary>
    /// add selected item of the store
    /// </summary>
    /// <param name="item">Prefab of selected item</param>
    public void AddItemToInventory(GameObject[] item)
    {
        listSelectedItems.Add(item[0].name, item);
    }
    public void RemoveItemOfInventory(GameObject[] item)
    {
        listSelectedItems.Remove(item[0].name);
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
                return;
                //buyerPerson.GetComponent<PlayerController>().myPurchasedItems.Add(items.Key + Random.Range(1, 999), items.Value);
            }
            else
            {
                //Add values of dictionary in the dictionary items of the player 
                buyerPerson.GetComponent<PlayerController>().myPurchasedItems.Add(items.Key, items.Value[0]);
                //instantiate and add prefabs in the transform of player category clothes (object empty)
                Instantiate(items.Value[0], buyerPerson.transform.Find("Clothes"));

                //instantiate and add images of items in the transform of player clothes (UI container)
                Instantiate(items.Value[1], buyerPerson.GetComponent<PlayerController>().myClothes.transform);
            }
        }
        UIManager._sharedIntance.HideStoreInventory();
    }
}
