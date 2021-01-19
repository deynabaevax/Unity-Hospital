using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToastMessagePopup : MonoBehaviour
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

    public void StartClicked()
    {
        if (inputField.text != "" && inputField1.text != "" && inputField11.text != "" && InputFieldDR.text != "" && inputFieldBeds.text != "" 
            && InputFieldHR.text != "" && InputFieldHSR.text != "")
        {
            patientNum = int.Parse(inputField.text);
            nrNurses = int.Parse(inputField11.text);
            doctorNum = int.Parse(inputField1.text);
            nrBeds = int.Parse(inputFieldBeds.text);
            HSRNum = int.Parse(InputFieldHSR.text);

            Toast.Instance.Show("Enter values in the fields!", 2f);
        }
        else
        {
            Toast.Instance.Show("Enter values in the fields!", 2f);
        }
    }
}
