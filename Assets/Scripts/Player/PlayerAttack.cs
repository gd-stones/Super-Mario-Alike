using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;

    [Header("Firepoint Player Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;

    private float cooldownTimer = Mathf.Infinity;

    [Header("Fireball Sound")]
    [SerializeField] private AudioClip fireballSound;

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }
#endif
    }

    public void Attack()
    {
        if (cooldownTimer >= attackCooldown && DataManager.Instance.coin >= 100)
        {
            SoundManager.instance.PlaySound(fireballSound);
            cooldownTimer = 0;

            //Shoot projectile
            fireballs[FindFireball()].transform.position = firepoint.position;
            fireballs[FindFireball()].GetComponent<PlayerProjectile>().ActivateProjectile();
            DataManager.Instance.coin -= 100;
        }
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
