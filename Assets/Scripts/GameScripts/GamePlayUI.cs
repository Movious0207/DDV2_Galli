using UnityEngine;
using TMPro;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] public TMP_Text height;
    [SerializeField] public TMP_Text score;
    [SerializeField] public GameObject streak;
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public TMP_Text streakText;
    [SerializeField] public TMP_Text streakAmount;
    [SerializeField] public TowerSpawn Manager;
    [SerializeField] public WorldMovement blockManager;
    [SerializeField] public bool isPaused;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        if (Time.timeScale == 1)
        {
            pauseMenu.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(true);
        }

        if(Manager.perfectStreak <= 0)
        {
            streak.SetActive(false);
        }
        else
        {
            streak.SetActive(true);
            streakAmount.text = Manager.perfectStreak.ToString();
        }
        height.text = "Height: " + blockManager.BlockAmount;
        score.text = "Score: " + Manager.score;
    }
}
