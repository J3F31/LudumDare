using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadCooldown : MonoBehaviour
{
    public Image reloadCooldown;
    public Text ammo;
    public PlayerShoot _playerShoot;
    
    void Update()
    {
        if (_playerShoot.isReloading == true)
        {
            reloadCooldown.fillAmount += 1f / _playerShoot.reloadTime * Time.deltaTime; 
        } else
        {
            reloadCooldown.fillAmount = 0f;
        }

        ammo.text = _playerShoot.Ammo.ToString();
    }
}
