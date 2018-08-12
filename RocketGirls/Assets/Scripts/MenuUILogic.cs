using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUILogic : MonoBehaviour {
    public string startSceneName;

    protected bool started = false;
    protected Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!started && Input.GetButtonDown("Submit"))
        {
            started = true;
            StartCoroutine(StartGameCoroutine());
            
        }
	}


    IEnumerator StartGameCoroutine()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(2.5f);
        TCUtils.TCSceneTransitionHelper.Instance.StartLoadingScene(startSceneName);
    }
}
