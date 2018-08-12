using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour {

    public static LevelController Instance { get; private set; }

    public GameObject[] levelSpawners;
    public SpriteFadeout[] levelBackgrounds;
    public int currentLevel = 0;
    public LevelNextEvent onNextLevel;
    private void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextLevel()
    {
        if(currentLevel < levelSpawners.Length - 1)
        {
            currentLevel++;
            SetLevel(currentLevel);

            onNextLevel.Invoke(currentLevel);
        }
    }

    public void SetLevel(int level)
    {
        currentLevel = level;
        for (int i = 0; i < levelSpawners.Length; ++i)
        {
             levelSpawners[i].SetActive(i == level);
        }
        for (int i = 0; i < levelBackgrounds.Length; ++i)
        {
            levelBackgrounds[i].target = (i == level)?1:0;
        }
    }
}

[Serializable]
public class LevelNextEvent : UnityEvent<int> { }