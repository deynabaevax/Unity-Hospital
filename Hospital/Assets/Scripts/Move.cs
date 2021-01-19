using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    private Renderer rend;
    private Health healthScript;
    private Transform pTransform;
    private Vector3 direction;
    //private NavMeshAgent nav; // not usable for this moment
    private float waitTime;
    private float accuracyWP = 2f;
    private float speed = 3f;
    private ResourceManager resourceManager;
    private GameObject resources;
    private GameObject showPatientInfoObj;
    private ShowPatientInfo showPatientInfo;

    public int currentWP;
    public GameObject[] waypoints = new GameObject[6];
    public float startTime; //for amount of time to wait until going to the next place
    public GameObject entrance;
    public GameObject testWP;
    public GameObject receptionWP;
    public GameObject doctorWP;
    public GameObject onWayToMorgueWP;
    public GameObject morgueWP;
	

    // Start is called before the first frame update
    void Start()
    {
        healthScript = GetComponent<Health>();
        showPatientInfoObj = GameObject.FindGameObjectWithTag("Patient Info Object");
        showPatientInfo = showPatientInfoObj.GetComponent<ShowPatientInfo>();
        rend = GetComponent<Renderer>();
        resources = GameObject.FindGameObjectWithTag("ResourceManager");
        resourceManager = resources.GetComponent<ResourceManager>();
        currentWP = 0;
        waitTime = startTime;
        pTransform = GetComponent<Transform>();
        //nav = GetComponent<NavMeshAgent>(); // not usable for this moment
        waypoints[0] = entrance;
        waypoints[1] = receptionWP;
        waypoints[2] = testWP;
        direction = waypoints[currentWP].transform.position - pTransform.position;
        direction.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PatientMove();
        CheckResourcesAmount();
        
    }

    public void CheckResourcesAmount() //For the Results after the sim
    {
        if (resourceManager.nrOfAvailableNurses < ResourceManager.minNurses)
        {
            ResourceManager.minNurses = resourceManager.nrOfAvailableNurses;
        }
        if (resourceManager.doctorsAvailable < ResourceManager.minDoctors)
        {
            ResourceManager.minDoctors = resourceManager.doctorsAvailable;
        }
        if (ResourceManager.nrOfPatients > ResourceManager.nrOfMaxPatients)
        {
            ResourceManager.nrOfMaxPatients = ResourceManager.nrOfPatients;
        }
		if (resourceManager.nrOfBedsAvailable < ResourceManager.minBeds)
		{
			ResourceManager.minBeds = resourceManager.nrOfBedsAvailable;
		}
	}
    public bool CheckResourcesAmountforUnitTesting(int a,int b)
    {
        // a=resourceManager.nrOfAvailableNurses number
        // b=ResourceManager.minNurses number
        if (a < b)
        {
            b = a;
            return true;
        }
        else
        { return false; }
    }
    public void PatientMove()
    {
        // constanct following the waypoints
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWP].transform.position, speed * Time.deltaTime);
        //
        if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP) // check if patient has reached the current waypoint
        {
            if (waitTime <= 0 && currentWP <= waypoints.Length)
            {
                currentWP++;
                waitTime = startTime;
				//If they're not at currentWP = 6 they will be distroyed early, sometimes in the middle of the room.
                if ((currentWP == 6 && healthScript.health >= PatientsInput.healthRate) || 
					(currentWP == 6 && healthScript.health >= 50 && healthScript.health < PatientsInput.healthRate) ||
                    (currentWP == 6 && healthScript.health >= 0 && healthScript.health < PatientsInput.deathRate ||
                    currentWP == 6 && healthScript.health >= PatientsInput.deathRate && healthScript.health < 50))//shows when patient has to leave/die
                {
                    Destroy(this.gameObject, startTime);
                    ResourceManager.nrOfPatients--;
                    resourceManager.UpdateGUI();
                }
                if(currentWP == 1)
                {
                    ResourceManager.minTotalHSR--;
                    resourceManager.UpdateGUI();
                }
				if (currentWP == 3) // that's WP nurse
                {
					//resourceManager.nrOfPatsInTestOffice--;
					showPatientInfo.UpdatePatInfo();
                    if (healthScript.GetResults() == true) //patient has no corona
                    {
						waypoints[3] = entrance;
                        resourceManager.nrOfAvailableNurses--;
                        CheckResourcesAmount();
                        resourceManager.nrOfUndefPats--;
                        ResourceManager.nrOfHealthyPats++;
                        rend.material.color = Color.green;
                        resourceManager.UpdateGUI();
					}
					else if (healthScript.health >= 0 && healthScript.health < PatientsInput.deathRate)//patient is going to die
					{
						waypoints[3] = doctorWP;
						//resourceManager.nrOfPatsInCureOffice++;
						waypoints[4] = onWayToMorgueWP;
						waypoints[5] = morgueWP;
						resourceManager.nrOfAvailableNurses--;
                        CheckResourcesAmount();
                        resourceManager.nrOfUndefPats--;
                        ResourceManager.nrOfDeadPats++;
						rend.material.color = Color.gray;
						resourceManager.UpdateGUI();
					}
					else if (healthScript.health >= PatientsInput.deathRate && healthScript.health < 50)//patient is quite sick and needs to be cured in the hospital
					{
						//resourceManager.nrOfPatsInCureOffice++;
						waypoints[4] = doctorWP;
						resourceManager.nrOfAvailableNurses--;
                        CheckResourcesAmount();
                        resourceManager.nrOfUndefPats--;
                        ResourceManager.nrOfSickPats++;
						waypoints[5] = entrance;
						rend.material.color = Color.yellow;
						resourceManager.UpdateGUI();
					}
					else if (healthScript.health >= 50 && healthScript.health < PatientsInput.healthRate)//patient is sent home to self-quarentine
                    {
                        waypoints[3] = entrance;
                        resourceManager.nrOfAvailableNurses--;
                        CheckResourcesAmount();
                        resourceManager.nrOfUndefPats--;
                        ResourceManager.quarantinedPats++;
                        rend.material.color = Color.cyan;
                        resourceManager.UpdateGUI();
                    }
                }

                else if (currentWP == 4 && healthScript.health >= 0 && healthScript.health < 50 && healthScript.GetResults() == false) // WP 4 doctor
                {
					//resourceManager.nrOfPatsInCureOffice--;
					resourceManager.doctorsAvailable--;
                    resourceManager.nrOfBedsAvailable--;
                    CheckResourcesAmount();
                }
				//else if (currentWP == 4 && healthScript.health >= 30 && healthScript.health < 50)
				//{
				//    resourceManager.nrOfAvailableNurses--;
				//}
				else if (currentWP == 5 && healthScript.health >= PatientsInput.healthRate)
                {
                    resourceManager.nrOfAvailableNurses++;
                }
                else if (currentWP == 5 && healthScript.health >= 50 && healthScript.health < PatientsInput.healthRate)
                {
                    //resourceManager.doctorsAvailable--;
                    resourceManager.nrOfAvailableNurses++;
                }
                else if (currentWP == 5 && healthScript.health >= 0 && healthScript.health < 50) // WP 5 exit
                {
                    resourceManager.nrOfAvailableNurses++;
                    resourceManager.doctorsAvailable++;
                    resourceManager.nrOfBedsAvailable++;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
