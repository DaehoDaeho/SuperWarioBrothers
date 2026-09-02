using TMPro;
using UnityEngine;

public enum GameState
{
    Ready,
    Playing,
    GameOver,
    Clear
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState currentState = GameState.Ready;

    public GameObject gameOverPanel;
    public GameObject clearPanel;

    public TMP_Text coinCountText;

    private int coinCount;

    private void Awake()
    {
        currentState = GameState.Playing;

        // Instance에 이미 객체가 등록되어 있다면, 중복 등록을 하지 않는 처리.
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverPanel.SetActive(false);
        clearPanel.SetActive(false);
        UpdateCoinCountUI();
    }

    public bool IsPlaying()
    {
        bool isPlaying = currentState == GameState.Playing;
        return isPlaying;
    }

    public void GameOver()
    {
        if(currentState != GameState.Playing)
        {
            return;
        }

        currentState = GameState.GameOver;
        gameOverPanel.SetActive(true);
    }

    public void GameClear()
    {
        if (currentState != GameState.Playing)
        {
            return;
        }

        currentState = GameState.Clear;
        clearPanel.SetActive(true);
    }

    public void AddCoinCount(int count)
    {
        coinCount += count;
        UpdateCoinCountUI();
    }

    void UpdateCoinCountUI()
    {
        coinCountText.text = "Coin: " + coinCount;
    }
}
