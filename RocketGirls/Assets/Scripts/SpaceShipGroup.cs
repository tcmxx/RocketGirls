using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpaceShipGroup : MonoBehaviour {

    public static SpaceShipGroup Instance { get; private set; }

    public float resourceBurningRate;

    public float forwardSpeed;
    public float horizontalSpeed = 4;
    public float shipVerticalFactor = 0.011f;
    protected Rigidbody2D rBody;
    public List<Rocket> AllRocket { get; private set; }

    private void Awake()
    {
        Instance = this;
        rBody = GetComponent<Rigidbody2D>();
    }


    // Use this for initialization
    void Start () {
        Initialize();
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        UpdateVerticalPosition();
    }

    protected void Initialize()
    {
        AllRocket = new List<Rocket>();
        AllRocket.AddRange(GetComponentsInChildren<Rocket>());
        AllRocket.ForEach(t => { t.Group = this; });
    }

    protected void Move()
    {
        float move = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            move = 1;
        }

        Vector3 moveVel = new Vector3(move * horizontalSpeed, 0, 0);
        rBody.velocity = moveVel;
    }

    protected void UpdateVerticalPosition()
    {
        foreach (var r in AllRocket)
        {
            var p = r.transform.localPosition;
            p.y = shipVerticalFactor * r.currentResource;
            r.transform.localPosition = Vector3.Lerp(r.transform.localPosition,p,Time.deltaTime*5f);
        }

    }

    public void OnRocketDie(Rocket rocket, bool gameFail)
    {
        if (gameFail)
        {
            GameUI.Instance.ShowGameFail();
            enabled = false;
        }
        else
        {
            AllRocket.Remove(rocket);
        }
    }
    

}
