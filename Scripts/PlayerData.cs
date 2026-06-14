using UnityEngine;
using System;

/// <summary>
/// بيانات اللاعب - يدير معلومات اللاعب الأساسية
/// Player Data - Manages basic player information
/// </summary>
[System.Serializable]
public class PlayerData
{
    [SerializeField] private string playerName;
    [SerializeField] private string role;
    [SerializeField] private int money;
    [SerializeField] private int playerId;
    [SerializeField] private int health;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private float experience;
    [SerializeField] private int level;

    // Events
    public event Action<int> OnMoneyChanged;
    public event Action<int> OnHealthChanged;
    public event Action<int> OnLevelUp;

    public PlayerData(string name, string playerRole, int startMoney = 0, int id = 1)
    {
        playerName = name;
        role = playerRole;
        money = startMoney;
        playerId = id;
        health = maxHealth;
        level = 1;
        experience = 0;
    }

    // Properties مع Validation
    public string PlayerName
    {
        get => playerName;
        set => playerName = value;
    }

    public string Role
    {
        get => role;
        set => role = value;
    }

    public int Money
    {
        get => money;
        set
        {
            money = Mathf.Max(0, value); // لا تقل عن صفر
            OnMoneyChanged?.Invoke(money);
        }
    }

    public int PlayerId
    {
        get => playerId;
        set => playerId = value;
    }

    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
            OnHealthChanged?.Invoke(health);
        }
    }

    public int MaxHealth => maxHealth;

    public float Experience
    {
        get => experience;
        set => experience = value;
    }

    public int Level
    {
        get => level;
        set => level = value;
    }

    // Methods
    public void AddMoney(int amount)
    {
        Money += amount;
    }

    public bool SpendMoney(int amount)
    {
        if (money >= amount)
        {
            Money -= amount;
            return true;
        }
        Debug.LogWarning("Not enough money!");
        return false;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Debug.Log("Player died!");
        }
    }

    public void Heal(int amount)
    {
        Health += amount;
    }

    public void AddExperience(float amount)
    {
        experience += amount;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        int requiredXP = level * 100;
        if (experience >= requiredXP)
        {
            level++;
            experience -= requiredXP;
            maxHealth += 10;
            OnLevelUp?.Invoke(level);
            Debug.Log($"Level Up! New Level: {level}");
        }
    }

    public override string ToString()
    {
        return $"Player: {playerName} | Role: {role} | Money: {money} | Level: {level} | Health: {health}/{maxHealth}";
    }
}
