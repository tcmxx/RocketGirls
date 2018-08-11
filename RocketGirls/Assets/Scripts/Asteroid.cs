using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    
    public float damage = 20;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Rocket rocket = collider.GetComponent<Rocket>();
        if (rocket != null)
        {
            rocket.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
