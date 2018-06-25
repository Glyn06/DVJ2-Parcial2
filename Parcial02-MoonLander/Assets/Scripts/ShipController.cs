using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
    public Rigidbody2D rb;
    public float force = 5;
    public float rotationSpeed = 250;
    public GameObject propeller;

    private Vector3 rotation;

    // Use this for initialization
    void Start () {
        rotation = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
        Rotation();
        Propulsion();
    }

    private void Rotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            float h = Input.GetAxis("Horizontal");
            float newRotation = rb.rotation + (h * rotationSpeed * Time.deltaTime);
            rotation.z = newRotation;

            transform.eulerAngles = rotation;
        }
    }
    private void Propulsion() {
        if (Input.GetKey(KeyCode.Space))
        {
            propeller.gameObject.SetActive(true);
            rb.AddForce(transform.up * Time.deltaTime * force);
        }
        else
            propeller.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("m_Terrain"))
        {
            Destroy(gameObject);
        }
    }
}
