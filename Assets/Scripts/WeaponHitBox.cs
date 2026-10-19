using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitBox : MonoBehaviour
{

    [SerializeField] private Weapon weapon;
    private bool _isAttacking;
    private Health _selfHealth;
    private HashSet<Health> _hitTargets = new HashSet<Health>();
    private void Awake()
    {
        _selfHealth = GetComponentInParent<Health>();
    }
    public void AttackBegin()
    {
        Debug.Log("Attack begin...");
        _hitTargets.Clear();
        _isAttacking = true;
    }
    public void AttackEnd()
    {
        _isAttacking = false;
        Debug.Log("Attack ends...");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!_isAttacking) return;
        TryDamage(other);
    }

    private void TryDamage(Collider other)
    {
        if (!_isAttacking) return;
        Health target = other.GetComponent<Health>();
        // target has no health, or target is self
        if (target == null || target == _selfHealth) return;
        // target is already hitted by the attack
        if (!_hitTargets.Add(target)) return;

        target.TakeDamage(weapon.GetWeaponAttackDamage());

    }
}
