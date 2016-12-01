using UnityEngine;
using System.Collections;
using NewtonVR;

public class HighLowOrbManager : MonoBehaviour {

	private const float lowOrbMaxHeight = 0.8f;
	private const float highOrbMinHeight = 1.8f;
	private const float lowOrbSpeed = 40.0f;
	private const float highOrbSpeed = 4.0f;

	public GameObject lowOrbPrefab;
	public GameObject highOrbPrefab;

	private NVRInteractableItem orbRight;
	private NVRInteractableItem orbLeft;
	private bool orbRightLow; 
	private bool orbLeftLow; // These two bools used to determine which orb type it is on release


	public void rightPress(NVRHand hand) {
		// Spawn new one at hand
		if (hand.transform.position.y < lowOrbMaxHeight) { // WARNING: Relies on player being level with the ground
			// Spawn Low
			GameObject orb = (GameObject)Instantiate (lowOrbPrefab, hand.transform.position, Quaternion.identity);
			orbRight = orb.GetComponent <NVRInteractableItem> ();
			orbRight.BeginInteraction (hand);
			orbRightLow = true;
		} else if (hand.transform.position.y > highOrbMinHeight) {
			// Spawn High
			GameObject orb = (GameObject)Instantiate (highOrbPrefab, hand.transform.position, Quaternion.identity);
			orbRight = orb.GetComponent <NVRInteractableItem> ();
			orbRight.BeginInteraction (hand);
			orbRightLow = false;
		}
	}

	public void rightRelease(NVRHand hand) {
		if (orbRight != null) {
			orbRight.EndInteraction ();
			Vector3 orbVelocity;
			if (orbRightLow) {
				orbVelocity = Vector3.forward * lowOrbSpeed;
			} else {
				orbVelocity = Vector3.forward * highOrbSpeed;
			}
			Quaternion controllerRotation = Quaternion.FromToRotation (Vector3.forward, hand.transform.forward);
			orbVelocity = controllerRotation * orbVelocity;
			Rigidbody orbRigidBody = orbRight.GetComponent <Rigidbody> ();
			orbRigidBody.velocity = orbVelocity;
			orbRight = null; // Prevents the release from boosting the orb more
		}
	}

	public void leftPress(NVRHand hand) {
		// Spawn new one at hand
		if (hand.transform.position.y < lowOrbMaxHeight) { // WARNING: Relies on player being level with the ground
			// Spawn Low
			GameObject orb = (GameObject)Instantiate (lowOrbPrefab, hand.transform.position, Quaternion.identity);
			orbLeft = orb.GetComponent <NVRInteractableItem> ();
			orbLeft.BeginInteraction (hand);
			orbLeftLow = true;
		} else if (hand.transform.position.y > highOrbMinHeight) {
			// Spawn High
			GameObject orb = (GameObject)Instantiate (highOrbPrefab, hand.transform.position, Quaternion.identity);
			orbLeft = orb.GetComponent <NVRInteractableItem> ();
			orbLeft.BeginInteraction (hand);
			orbLeftLow = false;
		}
	}

	public void leftRelease(NVRHand hand) {
		if (orbLeft != null) {
			orbLeft.EndInteraction ();
			Vector3 orbVelocity;
			if (orbLeftLow) {
				orbVelocity = Vector3.forward * lowOrbSpeed;
			} else {
				orbVelocity = Vector3.forward * highOrbSpeed;
			}
			Quaternion controllerRotation = Quaternion.FromToRotation (Vector3.forward, hand.transform.forward);
			orbVelocity = controllerRotation * orbVelocity;
			Rigidbody orbRigidBody = orbLeft.GetComponent <Rigidbody> ();
			orbRigidBody.velocity = orbVelocity;
			orbLeft = null; // Prevents the release from boosting the orb more
		}
	}
}
