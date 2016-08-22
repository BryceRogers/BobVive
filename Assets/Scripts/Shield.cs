using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public GameObject shield;

	private bool active;

	void Start () {
		shield.SetActive (false);
	}
	
	void Update () {
	}

	public void activate() {
		if (!active) {
			active = true;
			shield.SetActive (true);
		}
	}

	public void deactivate() {
		if(active) {
			active = false;
			shield.SetActive (false);
		}
	}
}
