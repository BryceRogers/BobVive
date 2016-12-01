using UnityEngine;
using System.Collections;

public class HighOrb : MonoBehaviour {

	private float timer = 15f;

	void Update () {
	
		timer -= Time.deltaTime;
		if (timer <= 0f) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision collision) {

		GetComponent <Rigidbody>().velocity = Vector3.zero;
	}
}

