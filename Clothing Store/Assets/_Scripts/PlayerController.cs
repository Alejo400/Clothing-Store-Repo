using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rigibody;
    [SerializeField, Range(2, 6)]
    public float speed = 4;
    float horizontalMove, verticalMove;
    Vector2 movement;
    public Dictionary<string, GameObject> myPurchasedItems = new Dictionary<string, GameObject>();
    [SerializeField]
    public GameObject myClothes; //specific clothes of Mary Sky
    const int nCharactersToRemove = 5;
    public clothingCharacteristics[] clothesOfTypes;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        movement = new Vector2(horizontalMove, verticalMove);
        _rigibody.velocity = movement.normalized * speed;
    }
    public void changeClothes(string name)
    {
        //remove word "image" to find the name of Prefabs
        name = name.Remove(0, nCharactersToRemove);
        GameObject clothes = GameObject.Find(name);
        //know the type of clothes
        TypeClothing clothesType = clothes.GetComponent<clothingCharacteristics>().typeClothing;
        //Find the all clothes
        clothesOfTypes = FindObjectsOfType<clothingCharacteristics>();
        foreach (var item in clothesOfTypes)
        {
            //find which clothes have the same type of the selected clothes to use. Example "shirt"
            if (item.typeClothing == clothesType && item.gameObject.name != name)
            {
                //Disabled the sprite renderer
                item.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        clothes.GetComponent<SpriteRenderer>().enabled = true;
        
    }
}
