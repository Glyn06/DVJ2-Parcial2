using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public List<GameObject> Terrains;
    [HideInInspector] public int level = 1;
    public static LevelManager instance;

    private int randomNum;

	// Use this for initialization
	void Start () {
        randomNum = Random.Range(0,Terrains.Count);
        Instantiate(Terrains[randomNum],transform.position,Quaternion.identity);
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    

    
}
