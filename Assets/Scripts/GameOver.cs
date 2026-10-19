using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private WeaponRod weaponRod;
    [SerializeField] private Health _health;
    
    private bool _gameOver;
    private void Awake()
    {
        gameOverPanel.SetActive(false);
    }
    private void OnEnable()
    {
        _health.HealthChanged += CheckHealth;
        
    }
    private void Start()
    {
        CheckHealth(_health.CurrentHealth, _health.MaxHealth);
    }

    private void OnDisable()
    {
        _health.HealthChanged -= CheckHealth;
    }

    private void CheckHealth(float cur, float max)
    {
        if (_gameOver || cur > 0f) return;
        Endgame();
    }

    public void BackToMainMenu()
    {
        Time.timeScale += 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("MainMenu");
    }

    internal void Endgame()
    {
        _gameOver = true;
        playerController.enabled = false;
        weaponRod.enabled = false;

        gameOverPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
}
