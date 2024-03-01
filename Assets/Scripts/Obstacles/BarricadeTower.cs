using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeTower : TowerBehaviour
{
    protected override void Start()
    {
        base.Start();
    }

    public override void Tick()
    {
        if (healthBar != null && shieldBar != null)
        {
            healthBar.value = health;
            shieldBar.value = shield;
        }
    }
}
