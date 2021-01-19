using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public string patName;
    public int health;
    public bool TestResults;
    // Start is called before the first frame update
    void Start()
    {
        SetHealth();
        DecideTest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHealth()
    {
        health = Random.Range(0, 100);
    }
    public void DecideTest()
    {
        if (health >= PatientsInput.healthRate) {
            TestResults = true;  //Not sick
        }
        else 
        {
            TestResults = false;  //Sick
        }
    }
    public bool GetResults()
    {
        return TestResults;
    }

	//For unit testing the DecideTest() Function
	public bool Hell(int healthy)
	{
		if (healthy >= 70)
		{
			return
			TestResults = true; //Not sick
		}
		else
		{
			return
			TestResults = false; //Sick
		}
	}
}
