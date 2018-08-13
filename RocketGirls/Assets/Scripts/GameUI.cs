using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
    public string gameSceneName;
    public string menuSceneName;
    public static GameUI Instance { get; private set; }

    public Slider progressBarRef;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        progressBarRef.value = Mathf.Clamp01(GameController.Instance.traveledDistance / GameController.Instance.maxDistance);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TwoOptionPanel.Instance.StartOptionPanel(LocalizationText.GetText("Restart"), () => { TCUtils.TCSceneTransitionHelper.Instance.StartLoadingScene(gameSceneName); },
                LocalizationText.GetText("Quit"), () => { TCUtils.TCSceneTransitionHelper.Instance.StartLoadingScene(menuSceneName); }, null
            );
        }
    }

    public void ShowGameFail(float delay = 2.34f)
    {
        StartCoroutine(DelayedCall(() => TwoOptionPanel.Instance.StartOptionPanel(LocalizationText.GetText("Restart"), () => { TCUtils.TCSceneTransitionHelper.Instance.StartLoadingScene(gameSceneName); },
                LocalizationText.GetText("Quit"), () => { TCUtils.TCSceneTransitionHelper.Instance.StartLoadingScene(menuSceneName); }, LocalizationText.GetText("Your rocket girls fell at :") + ((int)GameController.Instance.traveledDistance) + "/" + ((int)GameController.Instance.maxDistance)
            ), delay));

    }

    IEnumerator DelayedCall(Action act, float delay)
    {
        yield return new WaitForSeconds(delay);
        act.Invoke();
    }
}
