using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    [HideInInspector]public bool gameOver = false;
    [HideInInspector] public bool landed = false;

    // Use this for initialization
    void Start () {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            LevelManager.instance.level = 1;
        }
        else if (landed)
        {
            Time.timeScale = 0;
        }
	}
}
