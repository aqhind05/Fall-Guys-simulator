using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour
{
    public string scene = "SecondScene";

    private void nextScene()
    {
        SceneManager.LoadScene(scene);
    }

    public void OnResetButtonClick()
    {
        nextScene();
    }

}
