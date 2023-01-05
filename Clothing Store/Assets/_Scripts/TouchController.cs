using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchController : MonoBehaviour
{
    public UnityEvent onTouch;

    private void OnMouseDown()
    {
       onTouch.Invoke();
    }
}
