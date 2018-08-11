using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Slider progressBarRef;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        progressBarRef.value = Mathf.Clamp01(GameController.Instance.traveledDistance / GameController.Instance.maxDistance);

    }
}
