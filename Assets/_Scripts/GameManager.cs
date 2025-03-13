using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int score = 0;
    [SerializeField] private CoinCounterUI coinCounter;
    // [SerializeField] private TextMeshProUGUI scoreText;

    protected override void Awake()
    {
        base.Awake();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void IncreaseScore()
    {
        score++;
        //scoreText.text = $"Score: {score}";
        coinCounter.UpdateScore(score);
    }
}
