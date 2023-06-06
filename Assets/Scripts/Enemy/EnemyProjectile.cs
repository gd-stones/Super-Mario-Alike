using UnityEngine;
using System.Collections.Generic;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;

    private BoxCollider2D boxCollider2D;
    private bool hit;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        boxCollider2D.enabled = true;
    }

    private void Update()
    {
        if (hit) return;

        float movementSpeed = -speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
        {
            Deactivate();
        }
    }

    List<string> tagsToCheck = new List<string> { "Player", "Mushroom", "Radish" };
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tagsToCheck.Contains(collision.gameObject.tag))
        {
            hit = true;
            boxCollider2D.enabled = false;

            collision.gameObject?.GetComponent<PlayerHealth>()?.TakeDamage(1);
            collision.gameObject?.GetComponent<EnemyHealth>()?.EnemyTakeDamage();
            Deactivate(); //when this hits any object deactivate
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
