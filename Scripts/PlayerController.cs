using UnityEngine;

/// <summary>
/// وحدة تحكم اللاعب - تربط بين الحركة وبيانات اللاعب
/// Player Controller - Links movement with player data
/// </summary>
[RequireComponent(typeof(SimpleMove))]
public class PlayerController : MonoBehaviour
{
    private SimpleMove movement;
    private PlayerData playerData;

    [Header("Combat Settings")]
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float attackCooldown = 1f;
    private float lastAttackTime = 0f;

    void Start()
    {
        movement = GetComponent<SimpleMove>();
        playerData = GameManager.Instance.GetPlayerData();

        if (movement == null)
            Debug.LogError("SimpleMove component not found!");
    }

    void Update()
    {
        HandleInput();
        UpdatePlayerState();
    }

    void HandleInput()
    {
        // الهجوم
        if (Input.GetKeyDown(KeyCode.E) && CanAttack())
        {
            Attack();
        }

        // الشفاء
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(20);
        }
    }

    void UpdatePlayerState()
    {
        // يمكن إضافة تحديثات حالة إضافية هنا
    }

    void Attack()
    {
        lastAttackTime = Time.time;
        Debug.Log($"Attack! Damage: {attackDamage}");

        // هنا يمكن إضافة منطق الهجوم الفعلي
        // مثل رصد الأعداء والتحقق من الضربة
    }

    void Heal(int amount)
    {
        playerData.Heal(amount);
        Debug.Log($"Healed {amount}. Current Health: {playerData.Health}/{playerData.MaxHealth}");
    }

    bool CanAttack()
    {
        return Time.time - lastAttackTime >= attackCooldown;
    }

    public void TakeDamage(int damage)
    {
        playerData.TakeDamage(damage);
        Debug.Log($"Player took {damage} damage. Health: {playerData.Health}/{playerData.MaxHealth}");
    }

    public void AddMoney(int amount)
    {
        playerData.AddMoney(amount);
        Debug.Log($"Collected {amount} money. Total: {playerData.Money}");
    }

    public PlayerData GetPlayerData()
    {
        return playerData;
    }
}
