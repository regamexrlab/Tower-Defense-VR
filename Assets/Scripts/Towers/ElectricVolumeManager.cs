using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricVolumeManager : MonoBehaviour
{
    [SerializeField] private FlamethrowerDamage baseClass;
    [SerializeField] private float effectTime = 10f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = EnemySpawner.enemyTransformPairs[other.transform];
            Effect shockEffect = new Effect("Shock", baseClass.DamageValue, baseClass.FirerateValue, 2.0f, 0.5f, enemy.Speed, effectTime);
            AppliedEffect effect = new AppliedEffect(enemy, shockEffect, "ShockStatus");
            TowerDefenseManager.EnqueueEffectToApply(effect);
        }
    }
}
