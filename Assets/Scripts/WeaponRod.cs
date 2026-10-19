using System.Collections;
using UnityEngine;

public class WeaponRod : Weapon    // Inheritance
{
    [Header("Swing")]
    [SerializeField] private Vector3 swingAngles = new Vector3(0f, 0f, -90f);
    [SerializeField] private float swingDuration = 0.2f;
    [SerializeField] private float returnDuration = 0.3f;


    [SerializeField] private Transform pivot;
    private Quaternion _originalRotation;
    private bool _isAttacking;

    //private void Awake()
    //{
    //    //_originalRotation = transform.localRotation;
    //}
    private void Start()
    {
        _isAttacking = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    // Polymorphism
    protected override void Attack()
    {
        if (_isAttacking) return;
        _isAttacking = true;
        Debug.Log("Attack! Using rod!");
        StartCoroutine(Swing());
    }

    private IEnumerator Swing()
    {
        _isAttacking = true;
        _originalRotation = pivot.localRotation;
        Quaternion targetRotation = _originalRotation * Quaternion.Euler(swingAngles);
        // out
        yield return RotateOverTime(_originalRotation, targetRotation, swingDuration);
        // back
        yield return RotateOverTime(targetRotation, _originalRotation, returnDuration);
        yield return _isAttacking = false;
    }

    private IEnumerator RotateOverTime(Quaternion originalRotation, Quaternion targetRotation, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            float rotating = Mathf.Clamp01(time / duration);
            rotating = Mathf.SmoothStep(0f, 1f, rotating);

            pivot.localRotation = Quaternion.Slerp(originalRotation, targetRotation, rotating);
            yield return null;
        }
        pivot.localRotation = targetRotation;
    }

}
