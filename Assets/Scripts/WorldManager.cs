using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

    // Testing out some ideas here for the VR Project
    // First need to consider what data/states we need to store
    public Transform dummy;
    public int numInstance;


	// Use this for initialization
	void Start () {
        for (int i = 0; i < numInstance; ++i) {
            Transform f = Instantiate(dummy, new Vector3(-2, 0, 1+(float)(i * 1.2)), Quaternion.identity);
            f.localScale = new Vector3(1, (float)i/2 + 1, 1);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
