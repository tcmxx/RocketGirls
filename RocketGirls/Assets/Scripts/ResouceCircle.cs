using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResouceCircle : MonoBehaviour {

    public float resource = 20;
    protected bool used = false;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Rocket rocket = collider.GetComponent<Rocket>();
        if (rocket != null && !used)
        {
            used = true;
            rocket.GetResource(resource);
            Destroy(gameObject);
        }
    }
}
