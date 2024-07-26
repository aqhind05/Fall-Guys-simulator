using UnityEngine;
using UnityEngine.UI;

// Attached to the player
public class PlayerFallOutOfMap : MonoBehaviour
{
    public GameObject gameOverCanvas; // Reference to the "Game Over" canvas object
    public GameObject[] canvasElements;
    public GameObject player;
    private bool isCanvasActive;

    private AudioSource backgroundMusicSource; // Reference to the background music audio source
    public AudioSource losingAudioSource; // Reference to the losing audio source

    private void Start()
    {
        // Get a reference to the background music audio source
        backgroundMusicSource = FindBackgroundMusicSource();

}

    private AudioSource FindBackgroundMusicSource()
    {
        // Search for the background music source in the scene
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            if (source.isPlaying && source.loop)
            {
                return source;
            }
        }
        return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.gameObject == player) //change it to get the player by the tag 
        {
            StopBackgroundMusic();
            PlayLosingAudio();
            ToggleCanvas(true);
        }
    }

    private void ToggleCanvas(bool show)
    {
        // Toggle the canvas visibility and pause the game
        gameOverCanvas.SetActive(true); // Show the "Game Over" canvas
        Time.timeScale = show ? 0f : 1f;

        // Hide all the canvas elements
        canvasElements[0].SetActive(false);
        canvasElements[1].SetActive(false);
        canvasElements[2].SetActive(true);
        canvasElements[3].SetActive(true);
        canvasElements[4].SetActive(false);
        isCanvasActive = show;
    }

    private void StopBackgroundMusic()
    {
        // Stop the background music
        backgroundMusicSource.Stop();
    }

    private void PlayLosingAudio()
    {
        // Play the losing audio
        losingAudioSource.Play();
    }
}