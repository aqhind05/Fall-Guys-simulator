using TMPro;
using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lastAnswer : MonoBehaviour
{
    public RTLTextMeshPro canvasText;
    public Canvas canvas;
    public Button button1;
    public Button button2;
    public Button button3;


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

    public void ResetGame()
    {
        // Reset the canvas text to 
        StopBackgroundMusic();
        PlayLosingAudio();
        canvasText.text = " تهانينا!! \n  لقد أكملت اللعبة  ";

        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(true);

    }

    public void OnResetButtonClick()
    {
        ResetGame();
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
