using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerHelper : MonoBehaviour {
    public bool checkAttachedRB = true;
    public bool checkParent = false;
    public float destroyDelay = 2;
    public void Destroy(Collider2D col)
    {
        
        if (checkAttachedRB && col.attachedRigidbody)
        {
            Destroy(col.attachedRigidbody.gameObject, destroyDelay);
        }
        else
        {
            Destroy(col.gameObject, destroyDelay);
        }
    }

    public void Destroy(Collision2D col)
    {

        if (checkParent)
        {
            Destroy(col.gameObject.transform.parent.gameObject, destroyDelay);
        }
        else
        {
            Destroy(col.gameObject, destroyDelay);
        }
    }


}
