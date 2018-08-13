using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResouceCircle : MonoBehaviour {

    public float resource = 20;
    protected bool used = false;
    public AudioClip sfx;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Rocket rocket = collider.GetComponent<Rocket>();
        if (rocket != null && !used)
        {
            AudioSource.PlayClipAtPoint(sfx, Vector3.zero);
            used = true;
            rocket.GetResource(resource);
            Destroy(gameObject);
        }
    }
}
