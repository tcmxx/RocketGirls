using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneHelper : MonoBehaviour {
    public void LoadScene(string name)
    {
        TCUtils.TCSceneTransitionHelper.Instance.StartLoadingScene(name);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
