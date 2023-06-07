using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void NextButton()
    {
        SceneManager.LoadScene(2);
    }
    public void FinishButton()
    {
        SceneManager.LoadScene(0);
    }
}
