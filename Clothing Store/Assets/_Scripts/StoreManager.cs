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
    public Button PurchasedButtom;

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
    /// <summary>
    /// Enabled the botton to buy if the dictionary have 1 key or more
    /// </summary>
    public void InteractablePurchasedBotton()
    {
        if (listSelectedItems.Count <= 0)
            PurchasedButtom.interactable = false;
        else
            PurchasedButtom.interactable = true;
    }
    public void BuySelectedItems()
    {
        buyerPerson = GameObject.Find(buyerPersonName);
        foreach (var items in listSelectedItems)
        {
            if (!buyerPerson.GetComponent<PlayerController>().myPurchasedItems.ContainsKey(items.Key + "(Clone)"))
            {
                //Add keys and items of dictionary in the dictionary items of the player
                //instantiate and add prefabs in the transform of player category clothes (object empty)

                buyerPerson.GetComponent<PlayerController>().myPurchasedItems.Add(items.Key + "(Clone)",
                    Instantiate(items.Value[0], buyerPerson.transform.Find("Clothes")));

                //instantiate and add images of items in the transform of player clothes (UI container)
                Instantiate(items.Value[1], buyerPerson.GetComponent<PlayerController>().myClothes.transform);
            }
            else
            {
                //give a random number to buy similar clothes
                int randomNumber = Random.Range(0, 999);
                //create new key to find the item
                string newKey = $"{items.Key}(Clone){randomNumber}";

                buyerPerson.GetComponent<PlayerController>().myPurchasedItems.Add(newKey,
                    Instantiate(items.Value[0], buyerPerson.transform.Find("Clothes")));

                GameObject imageItem = Instantiate(items.Value[1], buyerPerson.GetComponent<PlayerController>().myClothes.transform);
                imageItem.name += randomNumber;
            }
        }
        UIManager._sharedIntance.HideStoreInventory();
    }
}
