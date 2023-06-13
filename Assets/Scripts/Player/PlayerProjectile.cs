using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    
    public GameObject characterManager;
    private GameObject playerDirection;
    private int direction;
    private float lifetime;

    private CircleCollider2D circleCol;
    private bool hit;

    private void Awake()
    {
        circleCol = gameObject.GetComponent<CircleCollider2D>();
        playerDirection = characterManager.GetComponent<CharacterManager>().characterActive;
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        circleCol.enabled = true;

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
            circleCol.enabled = false;

            collision.gameObject?.GetComponent<EnemyHealth>()?.EnemyTakeDamage();
            Deactivate();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hit = true;
            circleCol.enabled = false;

            collision.gameObject?.GetComponent<EnemyHealth>()?.EnemyTakeDamage();
            Deactivate();
        }
    }

    private void Deactivate() => gameObject.SetActive(false);
}
