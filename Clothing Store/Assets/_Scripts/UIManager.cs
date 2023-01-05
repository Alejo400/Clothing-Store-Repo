using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject StoreInventory;

    public void ShowStoreInventory() {
        Debug.Log("Inventorio");
        StoreInventory.SetActive(true);
    } 
}
