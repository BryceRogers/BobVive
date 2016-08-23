using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject controllerRight;
	public GameObject controllerLeft;
	public GameObject playerEyes;

	// Spell vars (maybe move)
	private float sqrShieldDistance = 2.8f;

	// Spell scripts
	private Shield shield;

	void Start () {
		shield = GetComponent<Shield>();
	}
	
	void Update () {

		gameObject.transform.position = playerEyes.transform.position;

		// Spell checks
		float sqrControllerDistance = (controllerLeft.transform.position - controllerRight.transform.position).sqrMagnitude;
		if(sqrControllerDistance > sqrShieldDistance){
			shield.activate ();	
		} else {
			shield.deactivate ();
		}
	
	}
}
