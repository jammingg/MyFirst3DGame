using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    

    [Header("Enemy")]
    [SerializeField] private float damageRange = 2f;
    [SerializeField] private float damageAmount = 10f;
    [SerializeField] private float damageInterval = 2f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float stopDistance = 1.3f;


    private Transform player;
    private Rigidbody _rb;
    private Health _health;
    private Health _playerHP;
    private float _nextDamageTime = 0f;
    private bool _isDead;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = false;
    }
    private void Start()
    {
        EnemyCounter.enemyCounter.RegisterEnemy();
        if (player == null)
        {
            GameObject playerObject = GameObject.FindWithTag("Player");

           if (playerObject == null)
           {
                return;
           }

            player = playerObject.transform;
        }

        _playerHP = player.GetComponent<Health>();

    }

    private void Update()
    {
        if (_isDead) return;
        if(_health != null && _health.CurrentHealth <= 0f)
        {
            _isDead = true;
            EnemyCounter.enemyCounter.Enemykilled();
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

        Vector3 velocity = Vector3.zero;
        direction.Normalize();
        if (distance > stopDistance)
        {
            velocity = direction * moveSpeed;
        }

        
        _rb.linearVelocity = new Vector3(velocity.x, _rb.linearVelocity.y, velocity.z);

        _rb.MoveRotation(Quaternion.LookRotation(direction));

    }

}
