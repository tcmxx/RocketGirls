using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Asteroid : MonoBehaviour {

    public AudioClip sfx;
    public bool randomRotation = true;
    public UnityEvent onHit;
    private void Start()
    {
        if (randomRotation)
        {
            transform.localRotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward);
            Vector3 scale = transform.localScale;
            transform.localScale = new Vector3(Random.value < 0.5f ? scale.x : -scale.x, scale.y, scale.z);
        }
        
    }
    public float damage = 20;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Rocket rocket = collider.GetComponent<Rocket>();
        if (rocket != null)
        {
            
            AudioSource.PlayClipAtPoint(sfx, Vector3.zero);
            rocket.TakeDamage(damage);
            onHit.Invoke();
            Destroy(gameObject);
        }
    }
}
