using UnityEngine;

public enum SoundType
{
    Collision,
    Perfect
}

public enum MusicType
{
    Music
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] SoundList;
    [SerializeField] private AudioClip GameMusic;
    private static AudioManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.generator = GameMusic;
        PlayMusic();
    }

    private void Start()
    {

    }

    public static void PlaySound(SoundType type, float volume = 1)
    {
        instance.audioSource.PlayOneShot(instance.SoundList[(int)type], volume);
    }
    public static void PlayMusic()
    {
        if(!instance.audioSource.isPlaying)
        {
        instance.audioSource.Play();
        instance.audioSource.loop = true;   
        }
    }
}
