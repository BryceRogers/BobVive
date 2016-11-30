using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using NSubstitute;

public class ExplodeTest
{

	[Test]
	public void UpdateShouldExplodeIfExplodeAvailableAndDistanceEnough() {

		//Arrange
		var mockExplodeObject = Substitute.For<Explodable> ();
//		mockExplodeBehaviour.shieldExplodeObject = new GameObject ();
		var explode = new Explode (mockExplodeObject);
		float arbitraryDeltaTime = 1f;

		//Act
		explode.Update (arbitraryDeltaTime, new Vector3(0f, 0f, 0f), new Vector3(5f, 5f, 5f));

		//Assert
		mockExplodeObject.Received (1).explode ();
	}
}
