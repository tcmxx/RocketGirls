using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverArea : MonoBehaviour
{

    public float recoverRate = 4;

    List<Rocket> inRockets;
    private void Awake()
    {
        inRockets = new List<Rocket>();
    }
    // Update is called once per frame
    void Update()
    {
        foreach (var r in inRockets)
        {
            r.GetResource(recoverRate * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var rocket = collision.GetComponent<Rocket>();
        if (rocket != null)
        {
            inRockets.Add(rocket);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var rocket = collision.GetComponent<Rocket>();
        if (rocket != null)
        {
            inRockets.Remove(rocket);
        }
    }
}
