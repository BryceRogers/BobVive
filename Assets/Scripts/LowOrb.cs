using UnityEngine;
using System.Collections;

public class LowOrb : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag.Equals ("destructible")) {
//			collider.GetComponent <>(); // Trigger cool destroy animation here
			Destroy (collider.gameObject);
		}
		Destroy (gameObject);
	}
}

