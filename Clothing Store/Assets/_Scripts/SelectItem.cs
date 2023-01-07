using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    public GameObject checkMarkItem;
    [SerializeField]
    public GameObject[] item;
    public int ID;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //The selected image will execute a specific action depending of the selected structure
        if (GameManager._sharedInstance._selectedStructure == SelectedStructure.ClothingStore)
        {
            //Selected the item on inventory
            UIManager._sharedIntance.SelectedItem(checkMarkItem, item);
        }
        if (GameManager._sharedInstance._selectedStructure == SelectedStructure.Cabinet)
        {
            //player change clothes
            GameObject.Find("Mary Sky").GetComponent<PlayerController>().changeClothes(gameObject.name);
        }
    }
}
