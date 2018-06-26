using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public int scoreMultiplier;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("m_Player"))
        {
            ShipController.instance.verticalspeed = ShipController.instance.rb.velocity.y;
        }
    }
}
