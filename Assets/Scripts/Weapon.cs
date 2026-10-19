using UnityEngine;

// Abstraction
public abstract class Weapon : MonoBehaviour
{
    [Header("Attack damage")]
    [Tooltip("Weapon's power.")]
    [SerializeField] private float attack_damage = 30f;   // Encapsulation

    protected abstract void Attack();
    // Encapsulation
    public float GetWeaponAttackDamage()
    {
        return attack_damage;
    }
    protected void IncreaseWeaponAttackDamage(float value)
    {
        attack_damage+=value;
    }
}
