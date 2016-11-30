using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class PlayerTest
{
	// THIS IS A BULLSHIT TESTING TESTICLE TEST
	[Test]
	public void EditorTest()
	{
		//Arrange
		Player player = new Player ();

		//Act
		player.triggerPressedShieldOn ();

		//Assert
		//The object has a new name
		Assert.AreEqual(player.leftTriggerHeld, false);
	}
}

