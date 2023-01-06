using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _sharedInstance;
    public SelectedStructure _selectedStructure;
    private void Awake()
    {
        if(_sharedInstance == null)
        {
            _sharedInstance = this;
        }
    }
}
