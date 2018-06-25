using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
    public Rigidbody2D rb;
    public float force = 5;
    public float rotationSpeed = 250;
    public GameObject propeller;

    private Vector3 rotation;
    private Vector3 cameraPos;

    // Use this for initialization
    void Start () {
        rotation = Vector3.zero;
        cameraPos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update() {
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

        if (collision.gameObject.CompareTag("m_Platform"))
        {
            /*if (rb.velocity.y < -2.5f) /////REVISAR ESTA PORQUERIA
            {
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Infinite Win!");
            }*/
            Platform component = collision.gameObject.GetComponent<Platform>();
            ScoreManager.instance.score += 100 * component.scoreMultiplier;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("m_Terrain"))
        {
            Vector3 newPosCam = new Vector3(transform.position.x, transform.position.y, transform.position.z -10);
            Camera.main.transform.SetPositionAndRotation(newPosCam, Quaternion.identity);
            Camera.main.orthographicSize = 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Camera.main.transform.SetPositionAndRotation(cameraPos, Quaternion.identity);
        Camera.main.orthographicSize = 5;
    }
}
