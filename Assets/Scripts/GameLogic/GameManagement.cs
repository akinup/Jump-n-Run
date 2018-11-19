using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour {

    public Transform playerPrefab;
    public GameObject startPoint;

	// Use this for initialization
	void Start () {

        Instantiate(playerPrefab, startPoint.transform.position, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
