using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRBEject : MonoBehaviour {

    public float angleRange = 45;
    public float interval = 0.14f;
    public GameObject objectPrefab;
    public float initialSpeed = 4;
    public Vector3 relativePosition;
    public void StartEject(int amount)
    {
        StartCoroutine(EjectionCoroutine(amount));
    }

    protected IEnumerator EjectionCoroutine(int amount)
    {
        for (int i = 0; i < amount; ++i)
        {
            yield return new WaitForSeconds(interval);
            float angle = Random.Range(-angleRange/2, angleRange/2) * Mathf.Deg2Rad ;
            Rigidbody2D ojb = Instantiate(objectPrefab, transform.position+ relativePosition, Quaternion.identity).GetComponent<Rigidbody2D>();
            ojb.velocity = transform.TransformDirection(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0))*initialSpeed;
        }

    }

}
