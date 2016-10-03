using UnityEngine;
using System.Collections;

public class Explodable : MonoBehaviour {

	private Rigidbody rigidBody;
	private float force = 4000f;

	void Start () {
		rigidBody = GetComponent <Rigidbody> ();
	}
	
	void OnTriggerEnter(Collider collider) {
		rigidBody.AddExplosionForce (force, collider.transform.position, 10f);
	}
}
