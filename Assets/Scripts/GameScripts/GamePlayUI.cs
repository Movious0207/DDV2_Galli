using UnityEngine;
using TMPro;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] public TMP_Text height;
    [SerializeField] public TMP_Text score;
    [SerializeField] public GameObject streak;
    [SerializeField] public TMP_Text streakText;
    [SerializeField] public TMP_Text streakAmount;
    [SerializeField] public TowerSpawn Manager;
    [SerializeField] public WorldMovement blockManager;

    void Start()
    {
                
    }

    
    void Update()
    {
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
