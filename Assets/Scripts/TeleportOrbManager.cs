using UnityEngine;
using System.Collections;
using NewtonVR;

public class TeleportOrbManager : MonoBehaviour {

	public GameObject teleportOrbPrefab;

	private NVRInteractableItem interactableItemRight;
	private NVRInteractableItem interactableItemLeft;

	private bool rightHeld;
	private bool leftHeld;
	private bool rightIsSeeker; // which orb is seeking the other
	private bool seeking;

	private static float baseSpeed = 8.0f;
	private static float speed = baseSpeed;
	private static float acceleration = 0.5f;
	private static float sqrOrbTeleDistance = 0.1f; // How close the orbs need to be before the teleporation occurs

	public void rightPress(NVRHand hand) {
		seeking = false;
		// Destroy current right orb
		if (interactableItemRight) {
			Destroy (interactableItemRight.gameObject);
			interactableItemRight = null;
		}

		// Spawn new one at hand
		GameObject teleportOrb = (GameObject)Instantiate (teleportOrbPrefab, hand.transform.position, Quaternion.identity);
		interactableItemRight = teleportOrb.GetComponent <NVRInteractableItem>();
		interactableItemRight.BeginInteraction (hand);

		rightHeld = true;
	}

	public void rightRelease() {
		rightHeld = false;
		interactableItemRight.EndInteraction ();

		if (interactableItemLeft && !leftHeld) { // left exists and has been thrown
			seeking = true;
			rightIsSeeker = true;
		}
	}

	public void leftPress(NVRHand hand) {
		seeking = false;
		// Destroy current right orb
		if (interactableItemLeft) {
			Destroy (interactableItemLeft.gameObject);
			interactableItemLeft = null;
		}

		// Spawn new one at hand
		GameObject teleportOrb = (GameObject)Instantiate (teleportOrbPrefab, hand.transform.position, Quaternion.identity);
		interactableItemLeft = teleportOrb.GetComponent <NVRInteractableItem>();
		interactableItemLeft.BeginInteraction (hand);

		leftHeld = true;
	}

	public void leftRelease() {
		leftHeld = false;
		interactableItemLeft.EndInteraction ();

		if (interactableItemRight && !rightHeld) { // right exists and has been thrown
			seeking = true;
			rightIsSeeker = false;
		}
	}

	void FixedUpdate () {
		if (seeking) {
			if (rightIsSeeker) {
				seek (interactableItemRight.gameObject, interactableItemLeft.gameObject);
			} else {
				seek (interactableItemLeft.gameObject, interactableItemRight.gameObject);
			}
		}
		
	}

	private void seek(GameObject seeker, GameObject seeken) {
		Vector3 direction = seeken.transform.position -  seeker.transform.position;
		float distance = direction.sqrMagnitude;
		if(distance < sqrOrbTeleDistance) {
			seeking = false;
			Destroy (interactableItemLeft.gameObject);
			interactableItemLeft = null;
			Destroy (interactableItemRight.gameObject);
			interactableItemRight = null;
			speed = baseSpeed;
		}
		speed += acceleration;
		Vector3 velocity = direction.normalized * speed;
		seeker.GetComponent <Rigidbody>().velocity = velocity;
	}
}
