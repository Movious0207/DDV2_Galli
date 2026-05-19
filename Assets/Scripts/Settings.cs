using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] Slider master;
    [SerializeField] Slider music;
    [SerializeField] Slider sfx;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        master.value = GameManager.instance.masterVolume;
        music.value = GameManager.instance.musicVolume;
        sfx.value = GameManager.instance.sfxVolume;
    }   

    public void musicValue()
    {
        GameManager.instance.audioSource.volume = music.value * master.value;
    }
    public void goToLast()
    {
        GameManager.instance.SaveVolumes(master.value,music.value,sfx.value);
        SceneManager.UnloadSceneAsync(2);
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
