using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NewtonVR;

public class Controller : MonoBehaviour {

	public GameObject teleportOrbPrefab;

	private NVRInteractableItem interactableItem;

	private NVRHand nVRHand;

	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device controller { 
		get { 
			return SteamVR_Controller.Input( (int) trackedObject.index);
		}
	}

	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private Valve.VR.EVRButtonId touchPad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

	void Start () {
		trackedObject = GetComponent <SteamVR_TrackedObject> ();
		nVRHand = GetComponent <NVRHand> ();
	}

	void Update () {
		if(controller == null) {
			Debug.Log ("Controller not initialized.");
			return;
		}

		if (controller.GetPressDown (touchPad)) {
			GameObject teleportOrb = (GameObject)Instantiate (teleportOrbPrefab, nVRHand.transform.position, Quaternion.identity);
			interactableItem = teleportOrb.GetComponent <NVRInteractableItem>();
			interactableItem.BeginInteraction (nVRHand);
		}
		if (controller.GetPressUp (touchPad)) {
			interactableItem.EndInteraction ();
		}

	}

}