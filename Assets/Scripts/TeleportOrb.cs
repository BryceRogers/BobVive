using UnityEngine;
using System.Collections;

public class TeleportOrb : MonoBehaviour {

	public GameObject otherOrb;
	public bool isSeeker;

	private float speed = 3.0f;
	private Rigidbody rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		if(isSeeker) {
			Vector3 direction = otherOrb.transform.position -  transform.position;
			Vector3 velocity = direction.normalized * speed;
			rigidBody.velocity = velocity;
		}
	}
}
