using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public List<GameObject> Terrains;

    private int randomNum;

	// Use this for initialization
	void Start () {
        randomNum = Random.Range(0,Terrains.Count);
        Instantiate(Terrains[randomNum],transform.position,Quaternion.identity,transform);
        Debug.Log(randomNum);
	}
}
