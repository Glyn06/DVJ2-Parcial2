using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShipController : MonoBehaviour {
    public static ShipController instance;

    public Button backtomenu;
    public Button nextLevel;
    public Text gameOverText;
    public Rigidbody2D rb;
    public float force = 5;
    public float rotationSpeed = 250;
    public GameObject propeller;
    [HideInInspector]public float verticalspeed;
    public float fuel = 100;

    private Vector3 rotation;
    private Vector3 cameraPos;

    // Use this for initialization
    void Start () {
        instance = this;
        rotation = Vector3.zero;
        cameraPos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (fuel > 0)
        {
            Rotation();
            Propulsion();
        }
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
            fuel -= Time.deltaTime;
            rb.AddForce(transform.up * Time.deltaTime * force);

        }
        else
            propeller.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("m_Terrain"))
        {
            GameManager.instance.gameOver = true;
            gameOverText.gameObject.SetActive(true);
            backtomenu.gameObject.SetActive(true);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("m_Platform"))
        {
            if (verticalspeed < -1.5f)
            {
                GameManager.instance.gameOver = true;
                backtomenu.gameObject.SetActive(true);
                Destroy(gameObject);
            }
            else
            {
                Platform component = collision.gameObject.GetComponent<Platform>();
                ScoreManager.instance.score += 100 * component.scoreMultiplier;
                GameManager.instance.landed = true;
                LevelManager.instance.level++;
                nextLevel.gameObject.SetActive(true);
            }
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
