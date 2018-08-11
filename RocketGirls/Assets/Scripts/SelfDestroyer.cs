using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour {

    public float timeDelay = 5;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, timeDelay);
	}
	
}
