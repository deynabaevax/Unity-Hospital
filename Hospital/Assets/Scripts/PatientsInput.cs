using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PatientsInput : MonoBehaviour
{
    public static int patientNum;
    public InputField inputField;

    public static int doctorNum;
    public InputField inputField1;

    public static int nrNurses;
    public InputField inputField11;

    public static int nrBeds;
    public InputField inputFieldBeds;

    public static int deathRate;
    public InputField InputFieldDR;

    public static int healthRate;
    public InputField InputFieldHR;

    public static int HSRNum;
    public InputField InputFieldHSR;
    //also bed input needed
    public Button button;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CreateSim()
    {
        if (inputField.text != "" && inputField1.text != "" && inputField11.text != "" && InputFieldDR.text != "" && inputFieldBeds.text != "" && InputFieldHR.text != "" && InputFieldHSR.text != "")
        {
            patientNum = int.Parse(inputField.text);
            nrNurses = int.Parse(inputField11.text);
            doctorNum = int.Parse(inputField1.text);
            nrBeds = int.Parse(inputFieldBeds.text);
            HSRNum = int.Parse(InputFieldHSR.text);

            healthRate = 100 - int.Parse(InputFieldHR.text);
            deathRate = (healthRate * int.Parse(InputFieldDR.text)) / 100;

            ResetStats();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (inputField.text == null && inputField1.text == null && inputField11.text == null && InputFieldDR.text == null && inputFieldBeds.text == null && InputFieldHR.text == null && InputFieldHSR.text == null)
        {
            //Toast.Instance.Show("Enter values in the fields!", 3f);
        }
        else
        {
            //Toast.Instance.Show("Enter values in the fields!", 3f);
        }
    }
    public void ResetStats()
    {
        ResourceManager.nrOfHealthyPats = 0;
        ResourceManager.nrOfSickPats = 0;
        ResourceManager.quarantinedPats = 0;
        ResourceManager.nrOfDeadPats = 0;
        ResourceManager.minDoctors = PatientsInput.doctorNum;
        ResourceManager.minNurses = PatientsInput.nrNurses;
        ResourceManager.totalPatients = PatientsInput.patientNum;
    }
    public bool CreateSim(string field1, string field2, string field3, string field4, string field5, string field6)// for unit test
    {

        if (field1 != "" && field2 != "" && field3 != "" && field4 != "" && field5 != "" && field6 != "")
        {
            patientNum = int.Parse(field1);
            nrNurses = int.Parse(field2);
            doctorNum = int.Parse(field3);
            nrBeds = int.Parse(field4);
            healthRate = 100 - int.Parse(field5);
            deathRate = (healthRate * int.Parse(field6)) / 100;
            return true;
        }
        else { return false; }

    }
    public void ResetStats(int dN,int nrU,int pN)//for unit testing
    {
        
        ResourceManager.nrOfHealthyPats = 0;
        ResourceManager.nrOfSickPats = 0;
        ResourceManager.quarantinedPats = 0;
        ResourceManager.nrOfDeadPats = 0;
        ResourceManager.minDoctors = dN;
        ResourceManager.minNurses = nrU;
        ResourceManager.totalPatients = pN;
    }
}
