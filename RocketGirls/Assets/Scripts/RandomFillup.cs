using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFillup : MonoBehaviour {

    public int fillupCount = 3;
    public float filupAmount = 40;
	
    public void Fillup()
    {
        MathUtils.Shuffle(SpaceShipGroup.Instance.AllRocket, new System.Random());

        for(int i =0; i < Mathf.Min(fillupCount, SpaceShipGroup.Instance.AllRocket.Count); ++i)
        {
            SpaceShipGroup.Instance.AllRocket[i].GetResource(filupAmount);
        }
    }


}
