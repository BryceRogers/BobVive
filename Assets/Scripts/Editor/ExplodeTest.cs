using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using NSubstitute;

public class ExplodeTest
{

	[Test]
	public void UpdateShouldExplodeIfExplodeAvailableAndDistanceEnough() {

		// Arrange
		var mockExplodeObject = Substitute.For<Explodable> ();
		var explode = new Explode (mockExplodeObject);
		float arbitraryDeltaTime = 1f;

		// Act
		explode.Update (arbitraryDeltaTime, new Vector3(0f, 0f, 0f), new Vector3(5f, 5f, 5f));

		// Assert
		mockExplodeObject.Received (1).explode ();
	}

	[Test]
	public void UpdateShouldNotExplodeWhenExplodeOnCooldown() {
		
		// Arrange
		var mockExplodeObject = Substitute.For<Explodable> ();
		var explode = new Explode (mockExplodeObject);
		float lessThanCooldown = 0.1f;

		// Act
		explode.Update (lessThanCooldown, new Vector3(0f, 0f, 0f), new Vector3(5f, 5f, 5f));
		// Second update should not result in additional explode call since it would be on cooldown
		explode.Update (lessThanCooldown, new Vector3(0f, 0f, 0f), new Vector3(5f, 5f, 5f));

		// Assert
		mockExplodeObject.Received (1).explode ();
	}

	[Test]
	public void UpdateShouldNotExplodeWhenDistanceNotEnough() {
		
		// Arrange
		var mockExplodeObject = Substitute.For<Explodable> ();
		var explode = new Explode (mockExplodeObject);
		float arbitraryDeltaTime = 1f;

		// Act
		explode.Update (arbitraryDeltaTime, new Vector3(0f, 0f, 0f), new Vector3(0.1f, 0.1f, 0.1f));

		// Assert
		mockExplodeObject.DidNotReceive ().explode ();
	}
}
