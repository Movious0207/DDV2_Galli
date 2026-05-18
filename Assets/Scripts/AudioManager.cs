using UnityEngine;

public enum SoundType
{
    Collision,
    Perfect
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] SoundList;
    private static AudioManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType type, float volume = 1)
    {
        instance.audioSource.PlayOneShot(instance.SoundList[(int)type], volume);
    }
}
