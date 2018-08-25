using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBike : MonoBehaviour {


    List<GameObject> effectedObjects = new List<GameObject>();
    public float moveMoveSpeed = 2;
    // Update is called once per frame
    private void FixedUpdate()
    {
        float x = transform.position.x;
        foreach(var o in effectedObjects)
        {
            if (o == null)
                continue;
            if(o.transform.position.x < x)
            {
                o.transform.position += Vector3.left * (moveMoveSpeed * GameController.Instance.objectSpeedModifier * Time.fixedDeltaTime);

            }
            else
            {
                o.transform.position += Vector3.right * (moveMoveSpeed * GameController.Instance.objectSpeedModifier * Time.fixedDeltaTime);
            }
        }
    }

    public void AddObject(Collider2D col)
    {
        effectedObjects.Add(col.gameObject);
        Debug.Log("Added object to ebike");
    }

    public void RemoveObject(Collider2D col)
    {
        effectedObjects.Remove(col.gameObject);
    }

}
