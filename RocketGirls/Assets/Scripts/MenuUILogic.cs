using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUILogic : MonoBehaviour {
    public string startSceneName;

    protected bool started = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!started && Input.GetButtonDown("Submit"))
        {
            started = true;
            TCUtils.TCSceneTransitionHelper.Instance.StartLoadingScene(startSceneName);
        }
	}
}
