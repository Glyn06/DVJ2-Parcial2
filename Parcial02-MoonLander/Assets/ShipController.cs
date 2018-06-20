﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
    public Rigidbody2D rb;
    public float force = 5;
    public float rotationSpeed = 250;

    private Vector2 vectorForce;

    // Use this for initialization
    void Start () {
		vectorForce = transform.up * force;
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(vectorForce * Time.deltaTime,ForceMode2D.Impulse);
        }
	}

    private void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float newRotation = rb.rotation + (h * rotationSpeed * Time.deltaTime);

        rb.MoveRotation(newRotation);
    }
}