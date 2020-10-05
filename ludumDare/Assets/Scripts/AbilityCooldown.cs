using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldown : MonoBehaviour
{
    public Image dashCooldown;
    public PlayerMovement _playerMovement;
    private bool isCooldown = false;
    
    void Start()
    {
        dashCooldown.fillAmount = 0f;
    }
    void Update()
    {
        Dash();
    }
    void Dash()
    {
        if(_playerMovement.dashOnCooldown == true && isCooldown == false)
        {
            isCooldown = true;
            dashCooldown.fillAmount = 1f;
        }
        if(isCooldown == true)
        {
           dashCooldown.fillAmount -= 1f / _playerMovement.dashCooldown * Time.deltaTime; 
           if (dashCooldown.fillAmount <= 0)
           {
               dashCooldown.fillAmount = 0;
               isCooldown = false;
           }
        }
    }
}
