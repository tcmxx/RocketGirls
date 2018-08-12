using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGroupEvent : MonoBehaviour {

    public GameObject deathAsteroidPref;

	// Use this for initialization
	void Start () {
        //StartCoroutine(QuitGroupCoroutine());
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnLevel(int level)
    {
        if(level == 2)
        {
            StartCoroutine(QuitGroupCoroutine());
        }
    }


    protected IEnumerator QuitGroupCoroutine()
    {
        yield return new WaitForSeconds(2);

        foreach (var r in SpaceShipGroup.Instance.AllRocket)
        {
            if (r.name == "SpaceshipMMQ" || r.name == "SpaceshipWXY" || r.name == "SpaceshipZZN")
            {
                var d = Instantiate(deathAsteroidPref, r.transform.position + Vector3.up * 10,Quaternion.identity).GetComponent<DeathAsteroid>();
                d.target = r.transform;
            }
        }
    }
}
