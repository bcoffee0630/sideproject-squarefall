using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private GameObject gameOverUI;

    private int _score;

    [RuntimeInitializeOnLoadMethod]
    private static void InitSettings()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    
    #region Unity methods

    private void OnEnable()
    {
        Point.OnPointCollected += GetScore;
        Player.OnPlayerDeath += GameOver;
    }

    private void OnDisable()
    {
        Point.OnPointCollected -= GetScore;
        Player.OnPlayerDeath -= GameOver;
    }

    private void Start()
    {
        gameOverUI.SetActive(false);
    }

    #endregion

    private void GetScore()
    {
        _score++;
        text.SetText($"{_score}");
    }

    private void GameOver()
    {
        Invoke(nameof(ShowGameOverUI), 1f);
    }

    private void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }
}
