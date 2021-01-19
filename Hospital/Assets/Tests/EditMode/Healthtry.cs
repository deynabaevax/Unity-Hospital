using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
namespace Tests
{
    public class Healthtry
    {
		// A Test behaves as an ordinary method
		//This test case tests whether the patient gets the correct diagnosis. 
		//If the patient's health is above 100-given health rate, then their test results should display that they are not sick = true. 
		//If their health is below, the results should display that they are sick = false.
		[Test]
		public void HealthtrySimplePasses()
		{
			//Arrangment
			GameObject obj = new GameObject();
			Health health = obj.AddComponent<Health>();
			int health2 = 80;
			var expectedresults = true;
			//Acting
			var healthTesting = health.Hell(health2);
			//Assertion
			Assert.That(healthTesting, Is.EqualTo(expectedresults));
		}       
    }
}
