using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ChangeSceneTests
    {
		// A Test behaves as an ordinary method
		//This test case tests when the simulation goes back to the previous scene to restart the simulation from the result scene if the variables of the result screen get reset. 
		[Test]
        public void ChangeSceneTestsSimplePasses()
        {
			//Arrangement
			GameObject obj = new GameObject();
			GoToScene scene = obj.AddComponent<GoToScene>();
			var expected = 0;

			//Acting
			var resetTesting = scene.Reset();

			//Assertion
			Assert.That(resetTesting, Is.EqualTo(expected));
		}
    }
}
