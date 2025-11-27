using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag(Tags.Enemy))
            {
                Debug.Log("ENEMY COLPITO !!! LO DEVO DISTRUGGERE !!");

            }
        }


    }
}
