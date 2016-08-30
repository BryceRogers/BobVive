using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject controllerRight;
	public GameObject controllerLeft;
	public GameObject playerEyes;

	// Spell vars (maybe move)
	private float sqrShieldDistance = 2.6f;

	// Spell scripts
	private Shield shield;

	void Start () {
		shield = GetComponent<Shield>();
	}
	
	void Update () {

		gameObject.transform.position = playerEyes.transform.position;

		// Shield check. Use Vector2s and ignore y axis so that only horizontal distance counts (avoiding players holding one up and the other down)
		Vector2 controllerLeftPosition = new Vector2(controllerLeft.transform.position.x, controllerLeft.transform.position.z);
		Vector2 controllerRightPosition = new Vector2(controllerRight.transform.position.x, controllerRight.transform.position.z);
		float sqrControllerDistance = (controllerLeftPosition - controllerRightPosition).sqrMagnitude;
		if(sqrControllerDistance > sqrShieldDistance){
			shield.activate ();	
		} else {
			shield.deactivate ();
		}

	}
}
