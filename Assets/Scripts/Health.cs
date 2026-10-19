using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [Header("Health")]
    [SerializeField]private float maxHealth = 100f;
    public float CurrentHealth { get; private set; }
    public float MaxHealth => maxHealth;

    public event Action<float, float> HealthChanged;
    private void Awake()
    {
        CurrentHealth = maxHealth;
    }
    public void TakeDamage(float amount)
    {
        CurrentHealth = Mathf.Min(0f, CurrentHealth - amount);
        HealthChanged.Invoke(CurrentHealth, MaxHealth);
    }

    public void Heal(float amount)
    {
        CurrentHealth = Mathf.Min(0f, CurrentHealth + amount);
        HealthChanged.Invoke(CurrentHealth, MaxHealth);
    }
}
