using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;
    [HideInInspector] public int score;

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

	}
}
