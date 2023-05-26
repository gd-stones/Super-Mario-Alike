using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    [SerializeField] private float scaleValue;
    [SerializeField] private AudioClip pickupSound;
    private Transform playerScale;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupSound);
            Vector3 scaleChange = new Vector3(scaleValue, scaleValue, scaleValue);

            playerScale = collision.gameObject.GetComponent<Transform>();
            playerScale.localScale = scaleChange;

            gameObject.SetActive(false);
        }
    }
}
