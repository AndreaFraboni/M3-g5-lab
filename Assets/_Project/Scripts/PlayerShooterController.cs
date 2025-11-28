using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterController : MonoBehaviour
{  
    [SerializeField] float fireRate = 1.0f;
    [SerializeField] float fireRange = 2.0f;

    private Rigidbody2D _rb; 
    public GameObject BulletPrefab;

    private float _speed = 5.0f;
    private float _lastShootTime;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private GameObject FindNearestEnemy()
    {
        GameObject NearstEnemyFounded = null;
        GameObject[] enemiesList = GameObject.FindGameObjectsWithTag(Tags.Enemy);

        float nearstDistance = fireRange;

        foreach (GameObject enemy in enemiesList)
        {
            float CurDistance = Vector2.Distance(transform.position, enemy.transform.position);
            if (CurDistance < nearstDistance)
            {
                nearstDistance = CurDistance;
                NearstEnemyFounded = enemy;
            }
        }
        return NearstEnemyFounded;
    }

    public void Shoot()
    {
        GameObject Target = FindNearestEnemy();

        if (Target == null)
        {
            //Debug.Log("Target NULL !!!!!");
            return;
        }

        //Debug.Log("OK c'è un nemico vicino !! Potrei sparare !!!");
        GameObject cloneBullet;

        Vector2 spawnPosition = _rb.position;

        cloneBullet = Instantiate(BulletPrefab,spawnPosition, Quaternion.identity);

        if (cloneBullet != null)
        {
            Vector2 direction = (Target.GetComponent<Rigidbody2D>().position - _rb.position); // determiniamo la direzione in cui sparare
            direction.Normalize();

            Rigidbody2D _rbBullet = cloneBullet.GetComponent<Rigidbody2D>();

            _rbBullet.velocity = direction * _speed;
        }
        else
        {
            Debug.Log("Non hai assegnato il Prefab del Bullet !!!");
            return;
        }


    }

    private void Update()
    {
        if (Time.time - _lastShootTime > fireRate)
        {
            _lastShootTime = Time.time;
            Shoot();
        }

    }

}
