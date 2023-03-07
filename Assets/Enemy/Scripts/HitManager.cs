using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    [SerializeField]
    float hitPoints = 25;
    [SerializeField]
    int pointValue = 1;

    void Hit(float rawDamage)
    {
        hitPoints -= rawDamage;
        if (hitPoints <= 0)
        {
            GameManager.IncrementScore(pointValue);
            Invoke("SelfTerminate", 0f);
        }
    }

    void SelfTerminate()
    {
        Destroy(gameObject);
    }
}