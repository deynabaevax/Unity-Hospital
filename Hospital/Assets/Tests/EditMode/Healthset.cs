using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Healthset
    {
		// A Test behaves as an ordinary method
		//This test case tests whether or not the patient's health is set ranging from 0 to 100.
		[Test]
        public void HealthsetSimplePasses()
        {
            GameObject obj = new GameObject();
            Health health = obj.AddComponent<Health>();
            health.health = -1;
            health.SetHealth();
            var result = false;
            if (health.health >= 0 && health.health <= 100)
            { result = true; }
            Assert.That(true, Is.EqualTo(result));
        }
    }
}
