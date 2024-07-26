using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject[] canvasElements; // Array of all the canvas elements to hide

    private void Start()
    {
       
        // Get a reference to the button component
        Button startButton = GetComponent<Button>();

        // Pause the game until the start button is pressed
        Time.timeScale = 0f;

        // Add a listener to the button's onClick event
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {

        // Hide all the canvas elements
        foreach (GameObject element in canvasElements)
        {
            element.SetActive(false);
        }

        // Resume the game
        Time.timeScale = 1f;

        // Add your game start logic here
        // e.g. start the game, load a scene, etc.
    }
}