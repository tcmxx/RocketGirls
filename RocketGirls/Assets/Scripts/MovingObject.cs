using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {


    public enum SpeedMode
    {
        Relative,
        Absolute
    }

    public SpeedMode speedMode = SpeedMode.Relative;
    public float speed = 2;
    public float speedScale = 1;
    protected Rigidbody2D rBody;
    private void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(speedMode == SpeedMode.Relative)
            rBody.velocity = Vector3.down * (speed + SpaceShipGroup.Instance.forwardSpeed) * GameController.Instance.objectSpeedModifier* speedScale;
        else
            rBody.velocity = Vector3.down * (speed) * GameController.Instance.objectSpeedModifier * speedScale;
    }
}
