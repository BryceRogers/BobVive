using UnityEngine;
using System.Collections;

public class LowOrb : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag.Equals ("destructible")) {
//			collider.GetComponent <>(); // Trigger cool destroy animation here
			Destroy (collision.gameObject);
		}
		Destroy (gameObject);
	}
}

