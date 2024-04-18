using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; //unlocks cursor
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        Time.timeScale = 0; //Halts game
    }

    private void OnDisable()
    {
        Time.timeScale = 1; //resumes game
        Cursor.lockState = CursorLockMode.Locked; //locks the cursor
    }
}
