using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class SaveHandler : MonoBehaviour
{
    string path = ""; //file path to save and load data file from
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        if (Keyboard.current.vKey.wasPressedThisFrame)
        {
            SaveData sd = new SaveData();
            sd.playerPosition = FindAnyObjectByType<FPSController>().transform.position; //Gets player object from fps script

            string jsonText = JsonUtility.ToJson(sd);
            Debug.Log(jsonText);

            
            File.WriteAllText(path, jsonText); //saves position in json text then stores it into file path
            Debug.Log("Saved");
        }
    }

    public void Load()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            string savetext = File.ReadAllText(path); //reads file path
            Debug.Log(savetext);

            SaveData myData = JsonUtility.FromJson<SaveData>(savetext); //converts string savetext in file from json
            FindAnyObjectByType<FPSController>().transform.position = myData.playerPosition; //loads player position to where the last position was saved

            Debug.Log("Loaded");
        }
    }
}
public class SaveData //Saving Position, ammo, and health
{
    public Vector3 playerPosition;
    public float health;
    public int ammo;
}
