using UnityEngine;
using UnityEngine.UI;

//attatched to the planes
public class CanvasController : MonoBehaviour
{
    public GameObject canvas;
    public GameObject plane;
    public GameObject player;
    public bool isCanvasActive = false;
    public bool seenQuestion = false;

    private void Start()
    {
        canvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.gameObject == player)
        {
            if (seenQuestion != true)
            {
                ToggleCanvas(true);
                seenQuestion = true;
            }
            else
            {

            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the colliding object is the player
        if (other.gameObject == player)
        {
            ToggleCanvas(false);
        }
    }

    private void ToggleCanvas(bool show)
    {
        // Toggle the canvas visibility and pause the game
        canvas.SetActive(show);
        isCanvasActive = show;
        Time.timeScale = show ? 0f : 1f;
    }


}