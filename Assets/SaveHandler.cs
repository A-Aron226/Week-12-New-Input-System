using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class SaveHandler : MonoBehaviour
{
    string path;  //file path to save and load data file from

    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + "/testSave.json"; //saves to unity project folder
    }

    // Update is called once per frame
    void Update()
    {
        Save();
        Load();
    }

    public void Save()
    {
        //if (Keyboard.current.vKey.wasPressedThisFrame) //testing code
        if (Keyboard.current.vKey.wasPressedThisFrame)
        {
            try //attempts to check if save file exists
            {
                SaveData sd = new SaveData();
                sd.playerPosition = FindAnyObjectByType<FPSController>().transform.position; //Gets player object from fps script
                sd.gunAmmo = FindAnyObjectByType<Gun>().ammo;
                sd.health = FindAnyObjectByType<Damageable>().currentHp;

                string jsonText = JsonUtility.ToJson(sd);
                Debug.Log(jsonText);


                File.WriteAllText(path, jsonText); //saves position in json text then stores it into file path

                Debug.Log("Saved");
            }

            catch (System.IO.FileNotFoundException e) //prints log if a FileNotFound exception occurs
            {
                Debug.Log("Save File does not exist.");
            }

            catch (System.Exception e) //prints out anything other error that occurs
            {
                Debug.Log(e);
            }
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
            FindAnyObjectByType<Gun>().ammo = myData.gunAmmo;
            FindAnyObjectByType<Damageable>().currentHp = myData.health;

            Debug.Log("Loaded");
        }
    }
}

[System.Serializable]
public class SaveData //Saving Position, ammo, and health
{
    public Vector3 playerPosition;
    public float health;
    public int gunAmmo;
}
