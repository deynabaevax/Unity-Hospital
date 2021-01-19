using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ResetTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void ResetTestSimplePasses()
        {
            GameObject obj = new GameObject();
            PatientsInput patientsInput = obj.AddComponent<PatientsInput>();
            int dN = 10;
            int nrU = 10;
            int pN = 10;
            ResourceManager.minDoctors = 0;
            ResourceManager.minNurses = 0;
            ResourceManager.totalPatients = 0;
            patientsInput.ResetStats(dN,nrU,pN);
            var result = false;
            if (ResourceManager.minDoctors==dN&& ResourceManager.minNurses== nrU&& ResourceManager.totalPatients==pN)
            { result = true; }
            else { result = false; }
            Assert.That(true, Is.EqualTo(result));
        }

       
    }
}
