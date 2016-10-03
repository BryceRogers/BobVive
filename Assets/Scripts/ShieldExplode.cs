using UnityEngine;
using System.Collections;

public class ShieldExplode : MonoBehaviour {

//	private float scaleFactor = 1f;
//	private Vector3 originalScale = new Vector3 (0.5f, 0.5f, 0.5f);
//	private float maxScaleFactor = 30f;
//	private float scaleSpeed = 60f;
	private bool exploding = false;
//	private SphereCollider collider;
	private float timeLeft;

	public GameObject shieldExplodeObject;
//	public GameObject player;

	void Start() {
//		collider = GetComponent <SphereCollider> ();
		shieldExplodeObject.SetActive (false);
	}

	void Update () {
		if (exploding) {
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0f) {
				//shieldExplodeObject.GetComponent <SphereCollider>().radius = 0.5f;
				exploding = false;
				shieldExplodeObject.SetActive (false);
			}
//			if (scaleFactor > maxScaleFactor) {
//				exploding = false;
//				gameObject.transform.localScale = originalScale;
//			} else {
//				scaleFactor += scaleSpeed * Time.deltaTime;
//				Vector3 scale = originalScale * scaleFactor;
//				gameObject.transform.localScale = scale;
//				collider.radius = scaleFactor / 2f;
//			}
		}

//		gameObject.transform.position = player.transform.position + new Vector3(0f, -1f, 0f);
	}

	public void explode() {
		if (!exploding) {
			//shieldExplodeObject.GetComponent <SphereCollider>().radius = 10f;
			exploding = true;
			shieldExplodeObject.SetActive (true);
			timeLeft = 0.5f;
//			scaleFactor = 1f;
		}
	}
}
