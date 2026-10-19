using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform player;

    [Header("Enemy")]
    [SerializeField] private float damageRange = 2f;
    [SerializeField] private float damageAmount = 10f;
    [SerializeField] private float damageInterval = 2f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float stopDistance = 1.3f;



    private Rigidbody _rb;
    private Health _health;
    private Health _playerHP;
    private float _nextDamageTime = 0f;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
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

    private void FixedUpdate()
    {
        if (player == null) return;
        Vector3 direction = player.position - _rb.position;
        direction.y = 0f;
        float distance = direction.magnitude;

        if (distance <= stopDistance) return; 

        direction.Normalize();
        Vector3 nextPosition = _rb.position + direction * moveSpeed * Time.fixedDeltaTime;

        _rb.MovePosition(nextPosition);
        _rb.MoveRotation(Quaternion.LookRotation(direction));

    }

}
