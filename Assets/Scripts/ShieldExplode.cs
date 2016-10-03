using UnityEngine;
using System.Collections;

public class ShieldExplode : MonoBehaviour {

	private bool exploding = false;
	private float timeLeft;

	public GameObject shieldExplodeObject;

	void Start() {
		shieldExplodeObject.SetActive (false);
	}

	void Update () {
		if (exploding) {
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0f) {
				exploding = false;
				shieldExplodeObject.SetActive (false);
			}
		}
	}

	public void explode() {
		if (!exploding) {
			exploding = true;
			shieldExplodeObject.SetActive (true);
			timeLeft = 0.5f;
		}
	}
}
