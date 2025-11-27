using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private PlayerController player;
    private Rigidbody2D _rbPlayer;

    private void Awake()
    {
        if (player == null)
        {
            GameObject go = GameObject.FindGameObjectWithTag(Tags.Player);
            if (go != null)
            {
                player = go.GetComponent<PlayerController>();
            }
        }
    }

    void EnemyMovement()
    {
     Vector2 newPos = Vector2.MoveTowards(transform.position, player._rb.position, speed * Time.deltaTime);
     transform.position = newPos;
    }


    private void FixedUpdate()
    {
        EnemyMovement();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag(Tags.Player))
            {
                Debug.Log("HO COLPITO IL PLAYER !!! LO DEVO DISTRUGGERE !!");

            }
        }
    }
}
