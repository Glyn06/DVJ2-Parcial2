using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDmanager : MonoBehaviour {

    public Text Score;
    public Text Fuel;
    public Text Height;
    public Text Time;
    public Text Xvelocity;
    public Text Yvelocity;

    private void Update()
    {
        Score.text = "Score " + ((int)(ScoreManager.instance.score)).ToString();
        Fuel.text = "Fuel " + ((int)(ShipController.instance.fuel)).ToString();
        Height.text = "Height " + ((int)(ShipController.instance.transform.position.y)).ToString();
        Time.text = "Time " + ((int)(GameManager.instance.time)).ToString();
        Xvelocity.text = "X velocity " + ShipController.instance.rb.velocity.x.ToString();
        Yvelocity.text = "Y velocity " + ShipController.instance.rb.velocity.y.ToString();
    }
}
