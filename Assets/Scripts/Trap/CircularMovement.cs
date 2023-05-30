using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    public float rotationSpeed = 50.0f;

    private void Update()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.forward, rotationAmount);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(1);
        }
    }
}
