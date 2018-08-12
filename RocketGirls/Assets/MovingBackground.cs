using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class MovingBackground : MonoBehaviour {

    public AnimationCurve moveCurve;
    public float maxMoveDis;

    public float currentRatio = 0;

    float initialY;
    
	void OnEnable () {
        initialY = transform.position.y;

    }

    private void Update()
    {
        var p = transform.position;
        p.y = moveCurve.Evaluate(currentRatio) * maxMoveDis + initialY;
        transform.position = p;
    }
}
