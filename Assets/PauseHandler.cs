using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame) //using this method since the InputMangaer method did not work. I believe it is because I have not used InputManager at all
        {
            bool isLoaded = SceneManager.GetSceneByName("PauseScene").isLoaded;

            if (!isLoaded)
            {
                SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive); //Loads Pause menu without unloading main scene
            }

            else
            {
                SceneManager.UnloadSceneAsync("PauseScene");
            }
        }
    }
}
