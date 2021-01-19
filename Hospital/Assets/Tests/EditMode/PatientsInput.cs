using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PatientsInputTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void PatientsInputTestSimplePasses()
        {
            GameObject obj = new GameObject();
            PatientsInput patientsInput = obj.AddComponent<PatientsInput>();
            string field1 = "10";
            string field2 = "10";
            string field3 = "10";
            string field4 = "10";
            string field5 = "10";
            string field6 = "10";
            var result = false;
            result = patientsInput.CreateSim(field1, field2, field3, field4, field5, field6);
            Assert.That(true, Is.EqualTo(result));
        }

        
        
    }
}
