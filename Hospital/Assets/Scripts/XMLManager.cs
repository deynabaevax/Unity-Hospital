using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using System.Xml;
using System.IO;
using UnityEngine.UI;
using System;
using System.Linq;

public class XMLManager : MonoBehaviour
{
    ResourceManager rs;
    public static XMLManager ins;
    public ItemDatabase itemDB;
    public InputField loadSlot;
    public Text totPats;
    public Text healthPats;
    public Text quarPats;
    public Text sickPats;
    public Text deadPats;
    public Text HSRLeftText;
    public Text maxPats;
    public Text nrDoctorsText;
    public Text minNrDoctorsText;
    public Text nrNursesText;
    public Text minNrNursesText;
    public Text nrBedsText;
    public Text minNrBedsText;
    public int toLoad;
    public ItemEntry current;

    public XMLManager()
    {
        current = new ItemEntry()
        {
            totalPatients = ResourceManager.totalPatients.ToString(),
            healthyPatients = ResourceManager.nrOfHealthyPats.ToString(),
            quarantinedPatients = ResourceManager.quarantinedPats.ToString(),
            sickPatients = ResourceManager.nrOfSickPats.ToString(),
            deadPatients = ResourceManager.nrOfDeadPats.ToString(),
            nrOfPatientsRushHour = ResourceManager.nrOfMaxPatients.ToString(),
            totalNrOfDoctors = ResourceManager.totalDoctors.ToString(),
            availableNrofDoctorsRushHour = ResourceManager.minDoctors.ToString(),
            totalNrOfNurses = ResourceManager.nrOfNurses.ToString(),
            availableNrOfNurses = ResourceManager.minNurses.ToString(),
            totalNrOfBeds = ResourceManager.nrOfBeds.ToString(),
            availableNrOfBedsRushHour = ResourceManager.minBeds.ToString(),
            LeftHSR = ResourceManager.minTotalHSR.ToString(),
        };

    }
    private void Awake()
    {
        ins = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SaveItems()
    {

        LoadItems();
        itemDB.list.Add(current);
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        XmlSerializerNamespaces serializer2 = new XmlSerializerNamespaces();
        serializer2.Add(string.Empty, string.Empty);
        if (Application.dataPath + "/StreamingFiles/XML/item_data.xml" == null)
        {
            FileStream stream = new FileStream(Application.dataPath + "/StreamingFiles/XML/item_data.xml", FileMode.OpenOrCreate);
            stream.Close();
        }
        else
        {
            FileStream stream1 = new FileStream(Application.dataPath + "/StreamingFiles/XML/item_data.xml", FileMode.OpenOrCreate);
            serializer.Serialize(stream1, itemDB);
            stream1.Close();
        }
        LoadItems();
    }
    public void LoadItems1()
    {
        toLoad = Convert.ToInt32(loadSlot.text);
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingFiles/XML/item_data.xml", FileMode.Open);
        itemDB = serializer.Deserialize(stream) as ItemDatabase;
        totPats.text = $"Total patients: " + itemDB.list[toLoad].totalPatients;
        healthPats.text = $"Healthy patients: " + itemDB.list[toLoad].healthyPatients;
        quarPats.text = $"Patients sent home to quarantine: " + itemDB.list[toLoad].quarantinedPatients;
        sickPats.text = $"Sick patients: {itemDB.list[toLoad].sickPatients}";
        deadPats.text = $"Patients who have died: {itemDB.list[toLoad].deadPatients}";
        HSRLeftText.text = $"HSR left: {itemDB.list[toLoad].LeftHSR}";
        maxPats.text = $"Number of patients at the busiest moments: {itemDB.list[toLoad].nrOfPatientsRushHour}";
        nrDoctorsText.text = $"Initial number of doctors: {itemDB.list[toLoad].totalNrOfDoctors}";
        minNrDoctorsText.text = $"Available doctors at the busiest moment {itemDB.list[toLoad].availableNrofDoctorsRushHour}";
        nrNursesText.text = $"Initial number of nurses: {itemDB.list[toLoad].totalNrOfNurses}";
        minNrNursesText.text = $"Available nurses at the busiest moment {itemDB.list[toLoad].availableNrOfNurses}";
        nrBedsText.text = $"Initial number of beds: {itemDB.list[toLoad].totalNrOfBeds}";
        minNrBedsText.text = $"Available beds at the busiest moment {itemDB.list[toLoad].availableNrOfBedsRushHour}";
        stream.Close();
    }
    public void LoadItems()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingFiles/XML/item_data.xml", FileMode.Open);
        itemDB = serializer.Deserialize(stream) as ItemDatabase;
        //if (itemDB.list.Any())
        //{

        //    toLoad = Convert.ToInt32(loadSlot.text) - 1;
        //    totPats.text = $"Total patients: " + itemDB.list[toLoad].totalPatients;
        //    healthPats.text = $"Healthy patients: " + itemDB.list[toLoad].healthyPatients;
        //    quarPats.text = $"Patients sent home to quarantine: " + itemDB.list[toLoad].quarantinedPatients;
        //}
        stream.Close();
    }
}
[System.Serializable]
public class ItemEntry
{
    //public string totalPatients = ResourceManager.totalPatients.ToString();
    //public string healthyPatients = ResourceManager.nrOfHealthyPats.ToString();
    //public string quarantinedPatients = ResourceManager.quarantinedPats.ToString();
    //public string sickPatients = ResourceManager.nrOfSickPats.ToString();
    //public string deadPatients = ResourceManager.nrOfDeadPats.ToString();
    //public string nrOfPatientsRushHour = ResourceManager.nrOfMaxPatients.ToString();
    //public string totalNrOfDoctors = ResourceManager.totalDoctors.ToString();
    //public string availableNrofDoctorsRushHour = ResourceManager.minDoctors.ToString();
    //public string totalNrOfNerses = ResourceManager.nrOfNurses.ToString();
    //public string availableNrOfNurses = ResourceManager.minNurses.ToString();
    //public string totalNrOfBeds = ResourceManager.nrOfBeds.ToString();
    //public string availableNrOfBedsRushHour = ResourceManager.minBeds.ToString();

    public string totalPatients { get; set; }
    public string healthyPatients { get; set; }
    public string quarantinedPatients { get; set; }
    public string sickPatients { get; set; }
    public string deadPatients { get; set; }
    public string nrOfPatientsRushHour { get; set; }
    public string totalNrOfDoctors { get; set; }
    public string availableNrofDoctorsRushHour { get; set; }
    public string totalNrOfNurses { get; set; }
    public string availableNrOfNurses { get; set; }
    public string totalNrOfBeds { get; set; }
    public string availableNrOfBedsRushHour { get; set; }
    public string LeftHSR { get; set; }
}
[XmlRoot(nameof(ItemDatabase))]
[System.Serializable]
public class ItemDatabase
{
    [XmlArray("SimulationStats")]
    public List<ItemEntry> list { get; set; }
    public ItemDatabase()
    {
        list = new List<ItemEntry>();
    }
}