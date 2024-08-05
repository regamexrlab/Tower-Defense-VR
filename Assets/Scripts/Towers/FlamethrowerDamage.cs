using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerDamage : MissileDamage
{
    //[SerializeField] private ParticleSystem fireEffect;
    [SerializeField] private Collider fireVolume;
    bool isJumped = false;

    public override void Init(float damage, float firerate)
    {
        audioSource = GetComponent<AudioSource>();
        missileSystemMain = missileSystem.main;

        this.damage = damage;
        this.firerate = firerate;
        //delay = 1f / firerate;
    }

    public void ToggleIsJumped()
    {
        isJumped = !isJumped;

        if (isJumped == true)
            missileSystem.Clear();
    }

    public override void ActivateGun(bool activeState)
    {
        if (activeState == true)
        {
            audioSource.loop = true;
            missileSystemMain.loop = true;
            UpdateDamage(damage * 2);
            fireVolume.enabled = true;
            missileSystem.Play();
        }
        else
        {
            missileSystem.Stop();
            audioSource.loop = false;
            missileSystemMain.loop = false;
            fireVolume.enabled = false;
            UpdateDamage(damage / 2);
        }
    }

    public override void DamageTick(Enemy target)
    {
        //fireVolume.enabled = target != null;

        if ((target && !isJumped) || (isJumped && fireVolume.enabled))
        {
            if (!missileSystem.isPlaying)
                missileSystem.Play();
            return;
        }

        //fireEffect.Stop();
    }
}
