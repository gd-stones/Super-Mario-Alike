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
        if (invulnerable || SnailDamage.isInShell) return;

        if (transform.localScale.x > 1)
        {
            transform.localScale = Vector3.one;
            StartCoroutine(Invunerability());
            SoundManager.instance.PlaySound(hurtSound);
        }
        else
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

            if (currentHealth > 0)
            {
                anim.SetTrigger("hurt");
                SoundManager.instance.PlaySound(hurtSound);
                StartCoroutine(Invunerability()); // Iframes
            }
            else
            {
                if (!dead) // Player dead
                {
                    foreach (Behaviour component in components) // Deactivate all attached component classes
                        component.enabled = false;

                    anim.SetBool("isGrounded", true);
                    anim.SetTrigger("hurt");

                    dead = true;
                    SoundManager.instance.PlaySound(deathSound);
                    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("hurt");
        anim.Play("Idle");
        StartCoroutine(Invunerability());

        foreach (Behaviour component in components) // Activate all attached component classes
            component.enabled = true;
    }

    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);

        // Invunerability duration
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(0.5f, 0.2f, 0.5f, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes));
        }

        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }
}
