using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientSpawner : MonoBehaviour
{
    public int toSpawn;
    private int currPat;
    public GameObject[] patients;
    public GameObject entrance;
    public ResourceManager rs;
    // Start is called before the first frame update
    void Start()
    {

        currPat = 0;
        toSpawn = PatientsInput.patientNum - 1;
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator Spawn()
    {
        while (currPat <= toSpawn)
        {
            patients[currPat].SetActive(true);
            ResourceManager.nrOfPatients++;
            currPat++;
            yield return new WaitForSeconds(5f);
        }


    }
}
