using UnityEngine;
using System.Collections;
using NewtonVR;

public class HighLowHandSpawner : MonoBehaviour
{
	private const float aimTime = 2f;
	private const float lowOrbSpeed = 40.0f;
	private const float highOrbSpeed = 4.0f;
	private const float lowOrbMinDistance = 1f;
	private const float highOrbMinDistance = 0.5f;
	
	public GameObject lowOrbPrefab;
	public GameObject highOrbPrefab;
	public GameObject playerHead;

	private NVRInteractableItem orb;
	private NVRHand nvrHand;

	private float timer = 0f;
	private bool orbLow; // if false then high

	void Start () {
		nvrHand = GetComponent <NVRHand> ();
	}
	
	void Update () {

		if (orb == null) {
			if (lowEnoughForLowOrb()) {
				summonOrb (lowOrbPrefab);
				orbLow = true;
			}
			else if (highEnoughForHighOrb()) {
				summonOrb (highOrbPrefab);
				orbLow = false;
			}
		}
		else {
			timer -= Time.deltaTime;
			if (timer <= 0f) {
				releaseOrb ();
			}
		}
	}

	private bool lowEnoughForLowOrb() {
		
		Vector3 handPosition = transform.position;
		Vector3 headPosition = playerHead.transform.position;
		float distance = Mathf.Abs (handPosition.y - handPosition.y);
		return handPosition.y < headPosition.y && distance > lowOrbMinDistance;
	}

	private bool highEnoughForHighOrb() {

		Vector3 handPosition = transform.position;
		Vector3 headPosition = playerHead.transform.position;
		float distance = Mathf.Abs (handPosition.y - handPosition.y);
		return handPosition.y > headPosition.y && distance > highOrbMinDistance;
	}

	private void summonOrb(GameObject orbPrefab) {
		
		GameObject summonedOrb = (GameObject)Instantiate (orbPrefab, transform.position, Quaternion.identity);
		orb = summonedOrb.GetComponent <NVRInteractableItem> ();
		orb.BeginInteraction (nvrHand);
		timer = aimTime;
	}

	private void releaseOrb() {
		
		orb.EndInteraction ();
		Vector3 orbVelocity;
		if (orbLow) {
			orbVelocity = Vector3.forward * lowOrbSpeed;
		} else {
			orbVelocity = Vector3.forward * highOrbSpeed;
		}
		Quaternion controllerRotation = Quaternion.FromToRotation (Vector3.forward, nvrHand.transform.forward);
		orbVelocity = controllerRotation * orbVelocity;
		orb.GetComponent <Rigidbody> ().velocity = orbVelocity;
		orb = null;
	}
}

