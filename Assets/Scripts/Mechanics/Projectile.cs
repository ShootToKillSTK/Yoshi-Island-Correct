using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public int damage;
    public float lifetime;

    //this is meant to be modified by the object creating the projectile.
    //eg. the shoot script
    [HideInInspector]
    public Vector2 initVel;
    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0) lifetime = 2.0f;
        if (damage <= 0) damage = 2;

        GetComponent<Rigidbody2D>().velocity = initVel;
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("PlayerProjectile"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
