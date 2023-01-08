using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject StoreInventory, CabinetInventory;
    public static UIManager _sharedIntance;
    [SerializeField]
    List<GameObject> checkMarks = new List<GameObject>();
    private void Awake()
    {
        if (_sharedIntance == null)
            _sharedIntance = this;
        else
            Destroy(this);
    }
    //Show UI Inventory to buy in store
    public void ShowStoreInventory() 
    {
        GameManager._sharedInstance.playerMove(false);
        StoreInventory.SetActive(true);
    }
    //Hide UI Inventory and remove selected items
    public void HideStoreInventory()
    {
        GameManager._sharedInstance.playerMove(true);
        StoreInventory.SetActive(false);
        foreach (var item in checkMarks)
        {
            item.SetActive(false);
        }
        StoreManager._sharedIntance.RemoveAllItemsOfInventory();
    }
    //Show Cabinet UI Inventory to change clothes
    public void ShowCabinetInventory()
    {
        GameManager._sharedInstance.playerMove(false);
        CabinetInventory.SetActive(true);
    }
    //Hide UI Cabinet
    public void HideCabinet()
    {
        GameManager._sharedInstance.playerMove(true);
        CabinetInventory.SetActive(false);
    }
    /// <summary>
    /// //Show or Hide checkmark in images items. Add or Remove Item of Inventory to Buy
    /// </summary>
    /// <param name="checkMark">selected item</param>
    public void SelectedItem(GameObject checkMark, GameObject[] item)
    {
        checkMark.SetActive(!checkMark.activeInHierarchy);
        if (checkMark.activeInHierarchy)
        {
            StoreManager._sharedIntance.AddItemToInventory(item);
            StoreManager._sharedIntance.InteractablePurchasedBotton();
        }
        else
        {
            StoreManager._sharedIntance.RemoveItemOfInventory(item);
            StoreManager._sharedIntance.InteractablePurchasedBotton();
        }
    }
}
