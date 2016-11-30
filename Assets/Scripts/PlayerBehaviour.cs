using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public GameObject controllerRight;
	public GameObject controllerLeft;
	public GameObject playerEyes;

	private Explode explode;

	void Start () {
		explode = new Explode (GetComponent <ExplodeBehaviour> ());
	}
	
	void Update () {

		gameObject.transform.position = playerEyes.transform.position;

		explode.Update (Time.deltaTime, controllerLeft.transform.position, controllerRight.transform.position);
	}
}
