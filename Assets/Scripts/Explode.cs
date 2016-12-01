using System;
using UnityEngine;

public class Explode {
	
	private const float sqrDistanceToExplode = 2.6f;
	private const float explodeCooldown = 2f;

	private Explodable explodable;
	private bool explodeAvailable = true;
	private float explodeTimer = 0f;
	
	public Explode (Explodable explodable) {
		this.explodable = explodable;
	}

	public void Update(float deltaTime, Vector3 controller1Pos, Vector3 controller2Pos) {
		
		if (!explodeAvailable) {
			
			explodeTimer += deltaTime;
			if (explodeTimer > explodeCooldown) {
				explodeTimer = 0f;
				explodeAvailable = true;
			}

		} else {
			
			if (horizontalSqrDistanceGreaterThan (controller1Pos, controller2Pos, sqrDistanceToExplode)) {
				explodeAvailable = false;
				explodable.explode ();
			}
		}
	}

	private bool horizontalSqrDistanceGreaterThan(Vector3 pos1, Vector3 pos2, float minDist) {
		Vector2 pos1NoVertical = new Vector2 (pos1.x, pos1.z);
		Vector2 pos2NoVertical = new Vector2 (pos2.x, pos2.z);
		float sqrDistance = (pos1NoVertical - pos2NoVertical).sqrMagnitude;
		return sqrDistance > minDist;
	}
}

