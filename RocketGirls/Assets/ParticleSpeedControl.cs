using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpeedControl : MonoBehaviour {
    protected ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var m = particle.main;
        var e = particle.emission;
        m.startSpeed = SpaceShipGroup.Instance.forwardSpeed*4;
        e.rateOverTimeMultiplier = SpaceShipGroup.Instance.forwardSpeed*2;
    }
}
