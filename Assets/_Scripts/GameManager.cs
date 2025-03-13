using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int score = 0;
    [SerializeField] private CoinCounterUI coinCounter;
    // [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject settingsMenu;
    private bool isSettingsActive;
    public bool isSettingsMenuActive => isSettingsActive;

    protected override void Awake()
    {
        base.Awake();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        inputManager.OnSettingsMenu.AddListener(ToggleSettingsMenu);
        DisableSettingsMenu();
    }

    public void IncreaseScore()
    {
        score++;
        //scoreText.text = $"Score: {score}";
        coinCounter.UpdateScore(score);
    }

     private void ToggleSettingsMenu()
    {
        if (isSettingsActive) DisableSettingsMenu();
        else EnableSettingsMenu();
    }

    private void EnableSettingsMenu()
    {
        Time.timeScale = 0f;
        settingsMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isSettingsActive = true;
    }

    public void DisableSettingsMenu()
    {
        Time.timeScale = 1f;
        settingsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isSettingsActive = false;
    }

    public void QuitGame(){
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

}
