using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {
    
    public float moveSpeed; //How fast to move.
    public Vector3 direction; //Direction.
    public Vector3 moveDirection; //Direction * Movespeed.
    public KeyCode Left; //Key to move left.
    public KeyCode Right; //Key to move right.
    public KeyCode Down; //Key to move down.
    public KeyCode Up; //Key to move up.

    void Update () {
        PlayerInput();
	}

    private void PlayerInput() {
        int hori = 0; //horizontal
        int vert = 0; //vertical
        if (Input.GetKey(Left)) { hori -= 1; }
        if (Input.GetKey(Right)) { hori += 1; }
        if (Input.GetKey(Down)) { vert -= 1; }
        if (Input.GetKey(Up)) { vert += 1; }

        //Get a direction by finding the normalized vector3 based on the current horizontal and vertical.
        direction = Vector3.Normalize(new Vector3(hori,0,vert));
        moveDirection = direction * moveSpeed * Time.deltaTime; //Smooth Movement.
        transform.position += moveDirection; //Apply movement.
    }
}
