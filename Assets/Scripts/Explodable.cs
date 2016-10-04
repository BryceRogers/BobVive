using UnityEngine;
using System.Collections;

public class Explodable : MonoBehaviour {

	private Rigidbody rigidBody;
	private float force = 4000f;
	private float explosionCooldown = 2f;
	private float timer = 0f;
	private bool exploded = false;

	void Start () {
		rigidBody = GetComponent <Rigidbody> ();
	}

	void Update() {
		if (exploded) {
			timer += Time.deltaTime;
			if(timer > explosionCooldown) {
				exploded = false;
				timer = 0f;
			}
		}
	}
	
	void OnTriggerEnter(Collider collider) {
		if (!exploded) {
			rigidBody.AddExplosionForce (force, collider.transform.position, 10f);
			exploded = true;
		}
	}
}
