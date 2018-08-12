using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAsteroid : MonoBehaviour {

    public float followSpeed;
    public float selfDestroyDelay = 4;
    public Transform target;

    protected bool hitTarget = false;

    protected SpriteRenderer mainRenderer;

    private void Awake()
    {
        mainRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
		
	}


    private void FixedUpdate()
    {
        if(!hitTarget && target != null)
        {
            var dist = target.position - transform.position;
            if(dist.magnitude <= followSpeed * Time.fixedDeltaTime)
            {
                transform.position = target.position;
                hitTarget = true;
                OnHitTarget();
            }
            else
            {
                transform.position += dist.normalized * followSpeed * Time.fixedDeltaTime;
            }
        }
    }

    protected void OnHitTarget()
    {
        Rocket r = target.GetComponent<Rocket>();
        r.DieWithoutLoss();
        mainRenderer.enabled = false;
        Destroy(gameObject, selfDestroyDelay);
    }
}
