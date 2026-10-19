using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable // Inheritance, Interfaces
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
    // Encapsulation
    public void TakeDamage(float amount)
    {
        CurrentHealth = Mathf.Max(0f, CurrentHealth - amount);
        HealthChanged.Invoke(CurrentHealth, MaxHealth);
    }

    public void Heal(float amount)
    {
        CurrentHealth = Mathf.Max(0f, CurrentHealth + amount);
        HealthChanged.Invoke(CurrentHealth, MaxHealth);
    }
}
