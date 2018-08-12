using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController Instance { get; private set; }

    public float traveledDistance = 0;
    public float maxDistance = 1000;
    public float objectSpeedModifier = 1;
    public float[] levelTheshoulds;

    public GameStatus gameStatus = GameStatus.Running;
    public string endGameCutSceneName;
    public enum GameStatus
    {
        Cutscene,
        Running
    }

    private void Awake()
    {
        Instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        traveledDistance += SpaceShipGroup.Instance.forwardSpeed * Time.deltaTime;
        CheckLevelChange();
        if(traveledDistance >= maxDistance)
        {
            TCUtils.TCSceneTransitionHelper.Instance.StartLoadingScene(endGameCutSceneName);
            enabled = false;
        }
    }

    protected void CheckLevelChange()
    {
        if (LevelController.Instance.currentLevel >= levelTheshoulds.Length)
            return;
        float currentRatio = Mathf.Clamp01(traveledDistance / maxDistance);

        if (currentRatio > levelTheshoulds[LevelController.Instance.currentLevel])
        {
            LevelController.Instance.NextLevel();
        }

    }
}
