using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFactorDown : MonoBehaviour {

    public float factorMultiplier = 0.5f;
    
    public float activeTime = 5;

    protected float timer = 0;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                GameController.Instance.objectSpeedModifier /= factorMultiplier;
            }
        }
    }

    public void ActivateSpeedDown()
    {
        if (timer <= 0)
            GameController.Instance.objectSpeedModifier *= factorMultiplier;
        timer += activeTime;
    }
}
