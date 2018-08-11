using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


public class LayerTrigger : MonoBehaviour {


    
	public LayerMask triggerLayer;

	public PlayerCollisionEvents[] events;

    
    public bool oneWay = false; //if true, only object enter/exit from local positive y will be triggered

	[SerializableAttribute]
	public struct PlayerCollisionEvents{
		public PlayerCollisionEventType eventType;
		public TriggerEvent unityEvent;
	}

	public enum PlayerCollisionEventType{
		Enter,
		Stay,
		Exit
	}

    private void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col){

        if (oneWay)
        {
            if(transform.InverseTransformPoint(col.transform.position).y < 0)
            {
                return;
            }
        }

        if ((1 << col.gameObject.layer & triggerLayer.value) != 0) {
			TriggerEvents (PlayerCollisionEventType.Enter, col);
		}
	}

	void OnTriggerStay2D(Collider2D col){
        if (oneWay)
        {
            if (transform.InverseTransformPoint(col.transform.position).y < 0)
            {
                return;
            }
        }
        if ((1<<col.gameObject.layer & triggerLayer.value) != 0)
			TriggerEvents (PlayerCollisionEventType.Stay, col);
	}

	void OnTriggerExit2D(Collider2D col){
        if (oneWay)
        {
            if (transform.InverseTransformPoint(col.transform.position).y < 0)
            {
                return;
            }
        }
        if ((1 << col.gameObject.layer & triggerLayer.value) != 0) {
			TriggerEvents (PlayerCollisionEventType.Exit, col);
		}
	}


	private void TriggerEvents(PlayerCollisionEventType type, Collider2D col){
        if (!enabled)
            return;
		foreach (var f in events) {
			if (f.eventType == type) {
				f.unityEvent.Invoke (col);
			}
		}
	}

   


    private void OnDrawGizmosSelected()
    {
        if (oneWay)
        {
            Vector3 localY = transform.TransformDirection(Vector3.up);
            Vector3 localX1 = transform.TransformDirection(Vector3.up + Vector3.right);
            Vector3 localX2 = transform.TransformDirection(Vector3.up - Vector3.right);
            Gizmos.DrawLine(transform.position, transform.position + localY);
            Gizmos.DrawLine(transform.position, transform.position + localX1/2);
            Gizmos.DrawLine(transform.position, transform.position + localX2/2);
        }
    }

}
[Serializable]
public class TriggerEvent : UnityEvent<Collider2D> { }
