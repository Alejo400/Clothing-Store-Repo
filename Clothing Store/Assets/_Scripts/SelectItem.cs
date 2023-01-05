using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SelectItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    public GameObject checkMarkItem, item;
    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        UIManager._sharedIntance.SelectedItem(checkMarkItem, item);
    }
}
