using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform player;

    [SerializeField] private float damageRange = 1f;
    [SerializeField] private float damageAmount = 10f;
    [SerializeField] private float damageInterval = 2f;

    private Health _health;
    private Health _playerHP;
    private float _nextDamageTime = 0f;
    private void Awake()
    {
        _health = GetComponent<Health>();
    }
    private void Start()
    {
        if (player != null)
        {
            _playerHP = player.GetComponent<Health>();
            Debug.Log($"Player has {_playerHP}");
        }
    }

    private void Update()
    {
        if(_health != null && _health.CurrentHealth <= 0f)
        {
            Destroy(gameObject);
            return;
        }


        if(_playerHP == null || player == null)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if(distance <= damageRange && Time.time >= _nextDamageTime)
        {
            Debug.Log("Enemy is dealing damage to palyer...");
            _playerHP.TakeDamage(damageAmount);
            _nextDamageTime = Time.time + damageInterval;
        }
    }





}
