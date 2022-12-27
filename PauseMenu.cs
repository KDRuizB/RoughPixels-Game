using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public GameObject PauseMenuO;
   public static bool isPaused;

     private void Start() {
          isPaused = false;
     }

   private void Awake() {
        PauseMenuO.SetActive(false);
   }

   private void PauseGame()
   {
        PauseMenuO.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
   }

   public void Resume()
   {
        PauseMenuO.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
   }

     //TODO game freesed nach erneuten starten
   public void BackToMainMenu()
   {
        SceneManager.LoadScene("MainMenu");
   }

   private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
   }

   public void QuitApp(){
    Application.Quit();
    Debug.Log("Application has quit.");
  }
}
