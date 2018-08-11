using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResouceCircle : MonoBehaviour {

    public float resource = 20;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Rocket rocket = collider.GetComponent<Rocket>();
        if (rocket != null)
        {
            rocket.GetResource(resource);
            Destroy(gameObject);
        }
    }
}
