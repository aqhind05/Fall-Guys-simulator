using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//attatched to the wrong button
public class ResetButton : MonoBehaviour
{
    public TextMeshProUGUI canvasText;
    public Canvas canvas;
    public Button button1;
    public Button button2;
    public Button button3;


    private void Start()
    {
        // Set the initial text on the canvas
        //canvasText.text = "Welcome to the map!";
    }

    public void ResetGame()
    {
        // Reset the canvas text to "Wrong answer"
        canvasText.text = "جواب خاطئ!";
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(true);

    }

    public void OnResetButtonClick()
    {
        ResetGame();
    }

}