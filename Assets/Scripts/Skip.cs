using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    
    public void ReplayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SkipTheLVL2()
    {
        SceneManager.LoadScene("Lvl2");
    }
    public void SkipTheLVL3()
    {
        SceneManager.LoadScene("Lvl3");
    }
}
