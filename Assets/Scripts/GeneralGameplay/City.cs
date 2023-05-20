using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class City : Singleton<City>
{
    public int health = 100;

    public HealthUI healthUI;

    [HideInInspector]
    public UnityEvent OnCityDestroyed;

    public Timer timer;

    public HitEffect hitEffect;

    public GameObject gate;

    public ParticleSystem gateExplosion;

    public ParticleSystem godsExplosion;

    private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        healthUI.SetMaxHealth(health);
        healthUI.SetValue(health);

        isAlive = true;

        timer.OnTimerFinished.AddListener(CityDefended);
    }

    // Update is called once per frame
    public void AttackCity(int amount = 1)
    {
        if(!isAlive) return;

        health -= amount;

        if(hitEffect != null) hitEffect.PlayEffect();

        healthUI.SetCurrentTarget(health);

        if(health <= 0)
        {
            CityDestroyed();
        }
    }

    public void CityDestroyed()
    {
        isAlive = false;

        gate.gameObject.SetActive(false);
        gateExplosion.Play();

        OnCityDestroyed?.Invoke();
    }

    public void CityDefended()
    {
        godsExplosion.Play();
    }
}
