using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Attached to the right button
public class ResumeGame : MonoBehaviour
{
    public Canvas canvas;

   
    public void ResetGame()
    {
        // Restart the game after 5 seconds
        // Set the time scale back to 1 to resume the game
        Time.timeScale = 1f;

        // Hide the game canvas
        canvas.gameObject.SetActive(false);
    }

    public void OnResetButtonClick()
    {
        ResetGame();
    }
}