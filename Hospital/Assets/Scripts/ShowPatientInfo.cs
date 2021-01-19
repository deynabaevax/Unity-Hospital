using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowPatientInfo : MonoBehaviour
{
    public Text patNameText;
    public Text patHealthText;
    public Text diagnosisText;
    public Move move;


    private Health tempHealth;
    private RaycastHit toSelect;
    // Start is called before the first frame update
    void Start()
    {
        patNameText.text = "";
        patHealthText.text = "";
        diagnosisText.text = "";
        DisablePatInfo();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            toSelect = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out toSelect);
            if (toSelect.collider.CompareTag("Patient") && tempHealth != null && move != null)
            {
                tempHealth = toSelect.collider.gameObject.GetComponent<Health>();
                move = toSelect.collider.gameObject.GetComponent<Move>();
                UpdatePatInfo();
                EnablePatInfo();
                if (toSelect.collider.gameObject != null)
                {
                    if (move.currentWP == 3)
                    {
                        UpdatePatInfo();
                    }
                }
            }
            else
            {
                if (!IsPointerOverUIObject())
                    DisablePatInfo();
            }
        }

    }

    public void UpdatePatInfo()
    {
        if (tempHealth != null)
        {
            patNameText.text = $"Patient name: {tempHealth.name}";
            patHealthText.text = $"Patient hp:{tempHealth.health}";
            if (move.currentWP < 3)
            {
                diagnosisText.text = "Result: unknown";
            }
            else
            {
                if (tempHealth.TestResults == false)
                {
                    diagnosisText.text = "Result: positive";
                }
                else
                {
                    diagnosisText.text = "Result: negative";
                }
            }

        }

    }
    private void EnablePatInfo()
    {
        patNameText.enabled = true;
        patHealthText.enabled = true;
        diagnosisText.enabled = true;
    }
    private void DisablePatInfo()
    {
        patNameText.enabled = false;
        patHealthText.enabled = false;
        diagnosisText.enabled = false;
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
