using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedEventCaller : MonoBehaviour {

    public float minInterval = 5;
    public float maxInterval = 10;
    public bool repeating = true;
    public int maxCount = 0;
    public float initialDelay = 0;
    public bool counting = true;
    public UnityEvent onTime;

    protected int repeatedCount = 0;
    protected float nextInterval = 0;
    protected float timer = 0;
	// Use this for initialization
	void Start () {
        nextInterval = Random.Range(minInterval, maxInterval);
        timer = nextInterval - initialDelay;
	}
	
	// Update is called once per frame
	void Update () {
        if (counting)
        {
            timer += Time.deltaTime;
            if (timer > nextInterval)
            {
                timer = timer - nextInterval;
                nextInterval = Random.Range(minInterval, maxInterval);
                onTime.Invoke();
                repeatedCount++;
                if (!repeating || (repeatedCount >= maxCount && maxCount > 0))
                    counting = false;
            }
        }
	}

    public void Restart()
    {
        nextInterval = Random.Range(minInterval, maxInterval);
        timer = nextInterval - initialDelay;
        counting = true;
        repeatedCount = 0;
    }
    
}
