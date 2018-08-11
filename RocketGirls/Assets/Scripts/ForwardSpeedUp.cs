using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardSpeedUp : MonoBehaviour {

    public float speedUpAmount = 4;
    public float speedUpTime = 5;

    protected float timer = 0;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                timer = 0;
                SpaceShipGroup.Instance.forwardSpeed -= speedUpAmount;
            }
        }
    }

    public void ActivateSpeedup()
    {
        if(timer<= 0)
            SpaceShipGroup.Instance.forwardSpeed += speedUpAmount;
        timer += speedUpTime;
    }
}
