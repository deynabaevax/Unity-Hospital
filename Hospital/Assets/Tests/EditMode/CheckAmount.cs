using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CheckAmount
    {
		// A Test behaves as an ordinary method
		//This test case tests whether or not the minimum value for nurses gets changed when necessary. 
		//This is important for the result screen for the user to see if they have enough nurses working in this given situation.
		[Test]
        public void CheckAmountSimplePasses()
        {
            GameObject obj = new GameObject();
            Move move = obj.AddComponent<Move>();
            int a = 10;
            int b=ResourceManager.minNurses = 11;
            var Correct = false;
            Correct = move.CheckResourcesAmountforUnitTesting(a, b);           
            Assert.That(true, Is.EqualTo(Correct));
        }
    }
}
