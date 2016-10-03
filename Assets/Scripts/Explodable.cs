using UnityEngine;
using System.Collections;

public class Explodable : MonoBehaviour {

	private Rigidbody rigidBody;
	private float force = 4000f;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent <Rigidbody> ();
	}
	
	void OnTriggerEnter(Collider collider) {
		Debug.Log ("hit");
//		Vector3 direction = transform.position - collider.transform.position;
		rigidBody.AddExplosionForce (force, collider.transform.position, 10f);
	}
}
