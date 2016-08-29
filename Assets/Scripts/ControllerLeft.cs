using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NewtonVR;

public class ControllerLeft : MonoBehaviour {

	public GameObject teleportOrbsManagerObject;
	private TeleportOrbManager teleportOrbsManager;

	public GameObject highLowOrbsManagerObject;
	private HighLowOrbManager highLowOrbsManager;

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
		teleportOrbsManager = teleportOrbsManagerObject.GetComponent <TeleportOrbManager> ();
		highLowOrbsManager = highLowOrbsManagerObject.GetComponent <HighLowOrbManager> ();
	}

	void Update () {
		if(controller == null) {
			Debug.Log ("Controller not initialized.");
			return;
		}

		if (controller.GetPressDown (touchPad)) {
			teleportOrbsManager.leftPress (nVRHand);
		}
		if (controller.GetPressUp (touchPad)) {
			teleportOrbsManager.leftRelease ();
		}
		if (controller.GetPressDown (triggerButton)) {
			highLowOrbsManager.leftPress (nVRHand);
		}
		if (controller.GetPressUp (triggerButton)) {
			highLowOrbsManager.leftRelease (nVRHand);
		}
	}

}