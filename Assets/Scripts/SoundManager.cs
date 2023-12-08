using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public AudioClip backgroundMusic;
    public AudioClip deathSound;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Make the GameObject persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySound();
    }

    public void PlaySound()
    {
        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No sound clip assigned to the SoundManager.");
        }
    }

    public void StopSound()
    {
        audioSource.Stop();
    }
}