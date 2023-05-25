using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration; //invulnerabilityDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        if (invulnerable) return;

        if (transform.localScale.x > 1)
        {
            transform.localScale = Vector3.one;
            StartCoroutine(Invunerability());
        }
        else
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

            if (currentHealth > 0)
            {
                //player hurt
                anim.SetTrigger("hurt");

                //iframes
                StartCoroutine(Invunerability());

                SoundManager.instance.PlaySound(hurtSound);
            }
            else
            {
                //player dead
                if (!dead)
                {
                    //deactivate all attached component classes
                    foreach (Behaviour component in components)
                    {
                        component.enabled = false;
                    }

                    anim.SetBool("isGrounded", true);
                    StartCoroutine(TriggerDeactiveAfterDelay(2.5f));
                    anim.SetTrigger("hurt");

                    dead = true;
                    SoundManager.instance.PlaySound(deathSound);
                }
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    //public void Respawn()
    //{
    //    dead = false;
    //    AddHealth(startingHealth);
    //    anim.ResetTrigger("hurt");
    //    anim.Play("Idle");
    //    StartCoroutine(Invunerability());

    //    //Activate all attached component classes
    //    foreach (Behaviour component in components)
    //    {
    //        component.enabled = true;
    //    }
    //}

    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);

        //invunerability duration
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes));
        }

        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }

    private IEnumerator TriggerDeactiveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
