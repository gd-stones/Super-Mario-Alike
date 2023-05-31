using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    [SerializeField] private float scaleValue;
    [SerializeField] private AudioClip pickupSound;
    private Transform playerScale;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupSound);
            Vector3 scaleChange = new Vector3(scaleValue, scaleValue + 0.25f, scaleValue);

            playerScale = collision.gameObject.GetComponent<Transform>();
            playerScale.localScale = scaleChange;

            Destroy(gameObject);
        }
    }
}
