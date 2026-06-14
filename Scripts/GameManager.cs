using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// مدير اللعبة - يدير حالة اللعبة العامة
/// Game Manager - Manages overall game state
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private PlayerData playerData;
    [SerializeField] private GameObject playerPrefab;

    private Dictionary<int, PlayerData> players = new Dictionary<int, PlayerData>();
    private bool isPaused = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        InitializeGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void InitializeGame()
    {
        // إنشاء بيانات اللاعب الافتراضية
        playerData = new PlayerData("Hero", "Warrior", 100, 1);
        players.Add(1, playerData);

        Debug.Log(playerData.ToString());
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        Debug.Log(isPaused ? "Game Paused" : "Game Resumed");
    }

    public PlayerData GetPlayerData()
    {
        return playerData;
    }

    public void AddPlayer(PlayerData newPlayer)
    {
        if (!players.ContainsKey(newPlayer.PlayerId))
        {
            players.Add(newPlayer.PlayerId, newPlayer);
        }
        else
        {
            Debug.LogWarning($"Player with ID {newPlayer.PlayerId} already exists!");
        }
    }

    public PlayerData GetPlayer(int playerId)
    {
        if (players.TryGetValue(playerId, out PlayerData player))
        {
            return player;
        }
        Debug.LogWarning($"Player with ID {playerId} not found!");
        return null;
    }

    public bool IsPaused()
    {
        return isPaused;
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0f;
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
