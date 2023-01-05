using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    public GameObject StoreInventory;
    public static UIManager _sharedIntance;
    [SerializeField]
    public List<GameObject> checkMarks = new List<GameObject>();
    private void Awake()
    {
        if (_sharedIntance == null)
            _sharedIntance = this;
        else
            Destroy(this);
    }
    //Show UI Inventory to buy in store
    public void ShowStoreInventory() {
        StoreInventory.SetActive(true);
    }
    //Hide UI Inventory and remove selected items
    public void HideStoreInventory()
    {
        StoreInventory.SetActive(false);
        foreach (var item in checkMarks)
        {
            item.SetActive(false);
        }
        StoreManager._sharedIntance.RemoveAllItemsOfInventory();
    }
    /// <summary>
    /// //Show or Hide checkmark in images items
    /// </summary>
    /// <param name="checkMark">selected item</param>
    public void SelectedItem(GameObject checkMark, GameObject item)
    {
        checkMark.SetActive(!checkMark.activeInHierarchy);
        if (checkMark.activeInHierarchy)
        {
            StoreManager._sharedIntance.AddItemToInventory(item);
        }
        else
        {
            StoreManager._sharedIntance.RemoveItemOfInventory(item);
        }
    }
}
