using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject Highscore;
    [SerializeField] public TMP_Text HighscoreText;
    private void Start()
    {
        credits.SetActive(false);
        if(!GameManager.instance.FirstLoad)
        {
            SceneManager.LoadScene(1,LoadSceneMode.Additive);
        }
        if(GameManager.instance.highScore <= 0)
        {
            Highscore.SetActive(false);
        }
        else
        {
            Highscore.SetActive(true);
            HighscoreText.text = "High Score : " + GameManager.instance.highScore;
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Settings()
    {
        SceneManager.LoadScene(2,LoadSceneMode.Additive);
    }
    public void Credits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }
    public void BackToMenu()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
