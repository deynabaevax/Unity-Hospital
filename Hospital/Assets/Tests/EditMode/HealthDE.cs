using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HealthDe
    {
		// A Test behaves as an ordinary method
		//This test case tests whether the patient gets the correct diagnosis. 
		//If the patient's health is above 100-given health rate, then their test results should display that they are not sick = true. 
		//If their health is below, the results should display that they are sick = false.
		[Test]
        public void HealthDeSimplePasses()
        {
            GameObject obj = new GameObject();

            Health health = obj.AddComponent<Health>();

            health.TestResults = false;
            health.health = 100;
            PatientsInput.healthRate = 50;
            health.DecideTest();
            Assert.That(true, Is.EqualTo(health.TestResults));
        }


    }
}
