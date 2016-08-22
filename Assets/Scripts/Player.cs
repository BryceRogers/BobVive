using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject controllerRight;
	public GameObject controllerLeft;

	// Spell vars (maybe move)
	private float sqrShieldDistance = 3.0f;

	// Spell scripts
	private Shield shield;

	void Start () {
		shield = GetComponent<Shield>();
	}
	
	void Update () {

		// Spell checks
		float sqrControllerDistance = (controllerLeft.transform.position - controllerRight.transform.position).sqrMagnitude;
		Debug.Log (sqrControllerDistance);
		if(sqrControllerDistance > sqrShieldDistance){
			shield.activate ();	
		} else {
			shield.deactivate ();
		}
	
	}
}
