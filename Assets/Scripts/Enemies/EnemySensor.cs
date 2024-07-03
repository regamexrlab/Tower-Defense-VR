using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    public Enemy enemyBase;
    [SerializeField] bool attackOnlyObstacles;
    [SerializeField] float atkRadius;

    private void Start()
    {
        enemyBase = transform.parent.GetComponent<Enemy>();

        GetComponent<SphereCollider>().radius = atkRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!attackOnlyObstacles && other.gameObject.CompareTag("Tower"))
        {
            if (other.gameObject.GetComponent<TowerBehaviour>() != null)
            {
                enemyBase.ChangeTowerTarget(other.gameObject.GetComponent<TowerBehaviour>());
            }
        }

        if (other.gameObject.CompareTag("AttackObstacle") || other.gameObject.CompareTag("BaseObstacle"))
        {
            if (other.gameObject.GetComponent<TowerBehaviour>() != null)
                enemyBase.ChangeTowerTarget(other.gameObject.GetComponent<TowerBehaviour>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AttackObstacle") || 
            other.gameObject.CompareTag("BaseObstacle") ||
            other.gameObject.CompareTag("Tower"))
        {
            enemyBase.ChangeTowerTarget(null);
        }
    }

}