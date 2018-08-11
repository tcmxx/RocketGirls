using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class AverageResource : MonoBehaviour {



	public void Average()
    {
        int count = SpaceShipGroup.Instance.AllRocket.Count;
        float res = SpaceShipGroup.Instance.AllRocket.Aggregate<Rocket,float>(0,(b,a) => { return  b + a.currentResource; })/ count;
        SpaceShipGroup.Instance.AllRocket.ForEach(r => { r.currentResource = res; });


    }
}
