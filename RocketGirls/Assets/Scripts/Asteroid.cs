using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public AudioClip sfx;
    private void Start()
    {
        transform.localRotation = Quaternion.AngleAxis(Random.Range(0, 360),Vector3.forward);
        transform.localScale = new Vector3(Random.value < 0.5f ? 1 : -1, 1, 1);
    }
    public float damage = 20;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Rocket rocket = collider.GetComponent<Rocket>();
        if (rocket != null)
        {
            AudioSource.PlayClipAtPoint(sfx, Vector3.zero);
            rocket.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
