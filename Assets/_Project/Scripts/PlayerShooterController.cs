using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterController : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] float fireRate = 1.0f;
    [SerializeField] float fireRange = 2.0f;

    public GameObject BulletPrefab;

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
        if (Target != null)
        {
            GameObject cloneBullet;
            Vector2 PlayerPosition = _rb.position;

            cloneBullet = Instantiate(BulletPrefab);
            
            //if (cloneBullet != null)
            //{
            //    Vector2 direction = (Target.GetComponent<Rigidbody2D>().position - _rb.position); // determiniamo la direzione in cui sparare
            //    direction.Normalize();
            //    cloneBullet.GetComponent<Rigidbody2D>().MovePosition(_rb.position + (direction * Time.deltaTime));
            //}
            //else
            //{
            //    Debug.Log("Non hai assegnato il Prefab del Bullet !!!");
            //    return;
            //}
        }
        else
        {
            Debug.Log("Target NULL !!!!!");
            return;
        }
    }

    private void Update()
    {

    }

}
