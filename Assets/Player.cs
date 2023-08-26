using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    Rigidbody2D rb;
    Camera cam;

    private void Start() {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Movement
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.MovePosition(rb.position + movement * 5 * Time.deltaTime);

        //flip sprite based on last input 
        if (movement.x > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        } else if (movement.x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
    }
}
