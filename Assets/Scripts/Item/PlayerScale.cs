using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    [SerializeField] private float scaleValue;
    [SerializeField] private AudioClip pickupSound;
    private Transform playerScale;

    [SerializeField] private float moveSpeed = 2f;

    public ActiveScaleCollectible active;
    private int direction = 1;
    private bool hitWall = false;

    private void Update()
    {
        if (active.headCollision)
            MoveScaleCollectible();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(pickupSound);
            Vector3 scaleChange = new Vector3(scaleValue, scaleValue + 0.25f, scaleValue);

            playerScale = collision.gameObject.GetComponent<Transform>();
            playerScale.localScale = scaleChange;

            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            hitWall = true;
    }

    private void MoveScaleCollectible()
    {
        if (hitWall)
            direction = -direction;
        hitWall = false;

        Vector3 movement = new Vector3(moveSpeed * direction, 0f, 0f);
        if (gameObject.activeSelf == true)
            transform.Translate(movement * Time.deltaTime);
    }
}
