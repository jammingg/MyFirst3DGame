using System;
using TMPro;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
   public static EnemyCounter enemyCounter {  get; private set; }
    [SerializeField] private GameOver gameOver;
    [SerializeField] private TMP_Text killsCanvasText;

    public int TotalEnemies { get; private set; }
    public int Enemieskilled { get; private set; }

    private void Awake()
    {
        enemyCounter = this;
        UpdateUI();
    }

    

    public void RegisterEnemy()
    {
        TotalEnemies++;
        UpdateUI();
    }

    public void Enemykilled() {
        Enemieskilled++;
        UpdateUI();
        if (Enemieskilled >= TotalEnemies) {

            gameOver.Endgame();
        }

    }

    private void OnDestroy()
    {
        if(enemyCounter == this)
        {
            enemyCounter = null;
        }
    }
    private void UpdateUI()
    {
        killsCanvasText.text = $"Kills: {Enemieskilled} / {TotalEnemies}";

    }
}
