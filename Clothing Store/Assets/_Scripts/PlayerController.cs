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
}
