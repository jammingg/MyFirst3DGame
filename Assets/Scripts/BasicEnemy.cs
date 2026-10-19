using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    private Health _health;
    private void Awake()
    {
        _health = GetComponent<Health>();
    }
}
