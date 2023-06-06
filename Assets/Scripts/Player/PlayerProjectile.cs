using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    [SerializeField] private GameObject playerDirection;
    private int direction;
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
        
        if (playerDirection.transform.eulerAngles.y == 0)
            direction = 1;
        else
            direction = -1;
    }

    private void Update()
    {
        if (hit) return;

        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            Deactivate();
    }

    List<string> tagsToCheck = new List<string> { "Mushroom", "Radish", "Enemy", "Flower", "Snail", "Wall" };
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tagsToCheck.Contains(collision.gameObject.tag))
        {
            hit = true;
            boxCollider2D.enabled = false;

            collision.gameObject?.GetComponent<EnemyHealth>()?.EnemyTakeDamage();
            Deactivate();
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
