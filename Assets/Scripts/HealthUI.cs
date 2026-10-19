using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Slider slider;

    private void OnEnable()
    {
        health.HealthChanged += UpdateBar;
        UpdateBar(health.CurrentHealth, health.MaxHealth);
    }
    private void OnDisable()
    {
        health.HealthChanged -= UpdateBar;
    }
    private void UpdateBar(float cur, float max)
    {
        slider.value = cur / max;
    }
}
