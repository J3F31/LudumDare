using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image health;
    public MarineHealthManager _marineHealthManager;
    public void Update()
    {
        health.fillAmount = _marineHealthManager.Health / 100f;
    }
}
