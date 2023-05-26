using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireball : MonoBehaviour
{
    [SerializeField] private float timeDelayAttack;
    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupSound);
            collision.gameObject.GetComponent<PlayerAttack>().enabled = true;

            gameObject.SetActive(false);
        }
    }
}
