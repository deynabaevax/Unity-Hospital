using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public static string hospitalName = "Durka";
    public static int nrOfPatients;
    public static int nrOfMaxPatients = 0;
    public static int nrOfBeds = PatientsInput.nrBeds;
    public int nrOfBedsAvailable;
    public static int totalHSR;
    
    public static int totalDoctors;
    public int doctorsAvailable;
    public int nrOfUndefPats;
    public static int nrOfHealthyPats;
    public static int nrOfSickPats;
    public static int quarantinedPats;
	public static int nrOfDeadPats;
	public static int nrOfNurses;
	public int nrOfAvailableNurses;
    public static int minDoctors = PatientsInput.doctorNum;
    public static int minNurses = PatientsInput.nrNurses;
	public static int minBeds = PatientsInput.nrBeds;
    public static int totalPatients = PatientsInput.patientNum;
    public static int minTotalHSR = PatientsInput.HSRNum;
    public Text hospitalNameText;
    public Text nrOfPatientsText;
    public Text nrOfBedsAvailableText;
    public Text nrOfBedsText;
    public Text totalDoctorsText;
    public Text doctorsAvailableText;
    public Text undefText;
    public Text healthyText;
    public Text sickText;
    public Text quarantinedPatsText;
	public Text deadText;
	public Text nrNursesText;
    public Text nrNursesAvailableText;
    public Text resultText;
    public Text minDoctorsText;
    public Text minNursesText;
	public Text minBedsText;
    public Text nrOfMaxPatientsText;
    public Text totalPatsText;
	public Text nrOfNursesInTestOfficeText;
	public Text nrOfDoctorsInCureOfficeText;
    public Text HSRText;
    public Text HSRResultText;
    public Button resultSceneButton;


    // Start is called before the first frame update
    void Start()
    {
        nrOfUndefPats = PatientsInput.patientNum;
        doctorsAvailable = PatientsInput.doctorNum;
        totalDoctors = PatientsInput.doctorNum;
        nrOfNurses = PatientsInput.nrNurses;
        nrOfAvailableNurses = PatientsInput.nrNurses;
		nrOfBedsAvailable = PatientsInput.nrBeds;
        totalHSR = PatientsInput.HSRNum;

		if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            UpdateGUI();
            resultSceneButton.interactable = false;//DO NOT MOVE THIS OR I WILL KILL YOU!!!
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            UpdateResultsGUI();
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if(nrOfUndefPats == 0)
        {
            resultSceneButton.interactable = true;
        }
        
    }
    public void UpdateGUI()
    {
        hospitalNameText.text = $"Hospital name: {hospitalName}";
        nrOfPatientsText.text = $"Number of patients: {nrOfPatients}";
		nrOfBedsText.text = $"Number of beds: {nrOfBeds}";
		nrOfBedsAvailableText.text = $"Beds available: {nrOfBedsAvailable}";
        totalDoctorsText.text = $"Number of doctors: {totalDoctors}";
        doctorsAvailableText.text = $"Number of doctors available: {doctorsAvailable}";
        undefText.text = $"Undefined: {nrOfUndefPats}";
        healthyText.text = $"Healthy: {nrOfHealthyPats}";
		quarantinedPatsText.text = $"Home Quarantine: {quarantinedPats}";
		sickText.text = $"Sick: {nrOfSickPats}";
		deadText.text = $"Dead: {nrOfDeadPats}";
		nrNursesText.text = $"Number of nurses: {nrOfNurses}";
        nrNursesAvailableText.text = $"Available nurses: {nrOfAvailableNurses}";
		nrOfNursesInTestOfficeText.text = $"Available \nNurses: {nrOfAvailableNurses}/{nrOfNurses}";
		nrOfDoctorsInCureOfficeText.text = $"Available \nDoctors: {doctorsAvailable}/{totalDoctors}";
        HSRText.text = $"HSRNum available: {minTotalHSR}";
	}
    public void UpdateResultsGUI()
    {
        resultText.text = $"Results for hospital {hospitalName}";
        healthyText.text = $"Healthy patients: {nrOfHealthyPats}";
        quarantinedPatsText.text = $"Patients sent home to quarantine: {quarantinedPats}";
        sickText.text = $"Sick patients: {nrOfSickPats}";
        deadText.text = $"Patients who have died: {nrOfDeadPats}";
		minNursesText.text = $"Available nurses at the busiest moment: {minNurses}";
        totalDoctorsText.text = $"Initial number of doctors: {totalDoctors}";
        nrNursesText.text = $"Initial number of nurses: {nrOfNurses}";
        nrOfMaxPatientsText.text = $"Number of patients at the busiest moments: {nrOfMaxPatients}";
        totalPatsText.text = $"Total patients: {totalPatients}";
		nrOfBedsText.text = $"Initial number of beds: {nrOfBeds}";
		minBedsText.text = $"Available beds at the busiest moment: {minBeds}";
        HSRResultText.text = $"HSRNum available: {minTotalHSR}";
        if (minBeds < 0)
		{
			minBedsText.color = Color.red;
		}
		if (minDoctors < 0)
		{
			minDoctorsText.color = Color.red;
		}
        if (minTotalHSR < 0)
        {
            HSRResultText.color = Color.red;
        }
        minDoctorsText.text = $"Available doctors at the busiest moment: {minDoctors}";
		if (minNurses < 0)
		{
			minNursesText.color = Color.red;
		}
	}
}
