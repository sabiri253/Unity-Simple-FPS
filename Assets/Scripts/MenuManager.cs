using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("ModeMenu");
    }

    public void GoToMission()
    {
        SceneManager.LoadScene("Mission");
    }
    
    public void GoToTraining()
    {
        SceneManager.LoadScene("Training");
    }

    public void GoToArcade()
    {
        SceneManager.LoadScene("Arcade");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
