using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    private Transform target;
    private float knockBack = 5; 
    private float damage = 20;

    private void Update()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            target = collider.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            target = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactDammage(collision);
    }

    private void ContactDammage (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStatus player = collision.gameObject.GetComponent<PlayerStatus>();
            Vector3 diff = collision.transform.position - transform.position;
            diff.Normalize();

            if (player)
            {
                player.TakeDamage(damage, diff * knockBack);
            }
        }
    }
}
