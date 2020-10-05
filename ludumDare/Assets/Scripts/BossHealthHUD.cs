using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthHUD : MonoBehaviour
{
    public Image _bossHealthBar;
    public BossHealth _bossHealth;

    public void Update()
    {
        _bossHealthBar.fillAmount = _bossHealth.currentHealth / _bossHealth.maxHealth;

        
    }
}
