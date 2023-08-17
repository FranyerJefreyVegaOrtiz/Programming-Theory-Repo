using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public Image activarPowerUp;
    public Image fillImage;  // Asigna la imagen desde el Inspector
    public int totalEnemies = 14;  // Cantidad total de enemigos en el nivel
    private int enemiesDefeated = 0;  // Cantidad de enemigos derrotados

    private void Start()
    {
        UpdateFillAmount();
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++;
        UpdateFillAmount();
    }

    private void UpdateFillAmount()
    {
        float fillValue = (float)enemiesDefeated / totalEnemies;
        fillImage.fillAmount = fillValue;
        if (enemiesDefeated == totalEnemies)
        {
            activarPowerUp.gameObject.SetActive(false);
        }
    }

    public void ActivarPowerUp()
    {
        activarPowerUp.gameObject.SetActive(true);
        enemiesDefeated = 0;
        fillImage.fillAmount = enemiesDefeated;
    }

}
