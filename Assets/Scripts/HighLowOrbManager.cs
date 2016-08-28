using UnityEngine;
using System.Collections;
using NewtonVR;

public class HighLowOrbManager : MonoBehaviour {

	public GameObject lowOrbPrefab;
	public GameObject highOrbPrefab;

	private NVRInteractableItem orbRight;
	private NVRInteractableItem orbLeft;

	private float lowOrbMaxHeight = 0.8f;
	private float highOrbMinHeight = 1.8f;

	public void rightPress(NVRHand hand) {
		// Spawn new one at hand
		if (hand.transform.position.y < lowOrbMaxHeight) { // WARNING: Relies on player being level with the ground
			// Spawn Low
			GameObject orb = (GameObject)Instantiate (lowOrbPrefab, hand.transform.position, Quaternion.identity);
			orbRight = orb.GetComponent <NVRInteractableItem> ();
			orbRight.BeginInteraction (hand);
		} else if (hand.transform.position.y > highOrbMinHeight) {
			// Spawn High
			GameObject orb = (GameObject)Instantiate (highOrbPrefab, hand.transform.position, Quaternion.identity);
			orbRight = orb.GetComponent <NVRInteractableItem> ();
			orbRight.BeginInteraction (hand);
		}
	}

	public void rightRelease() {
		orbRight.EndInteraction ();
	}

	public void leftPress(NVRHand hand) {
		// Spawn new one at hand
		if (hand.transform.position.y < lowOrbMaxHeight) { // WARNING: Relies on player being level with the ground
			// Spawn Low
			GameObject orb = (GameObject)Instantiate (lowOrbPrefab, hand.transform.position, Quaternion.identity);
			orbLeft = orb.GetComponent <NVRInteractableItem> ();
			orbLeft.BeginInteraction (hand);
		} else if (hand.transform.position.y > highOrbMinHeight) {
			// Spawn High
			GameObject orb = (GameObject)Instantiate (highOrbPrefab, hand.transform.position, Quaternion.identity);
			orbLeft = orb.GetComponent <NVRInteractableItem> ();
			orbLeft.BeginInteraction (hand);
		}
	}

	public void leftRelease() {
		orbLeft.EndInteraction ();
	}

}
