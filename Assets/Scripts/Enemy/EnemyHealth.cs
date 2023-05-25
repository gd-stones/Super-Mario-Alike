using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private string nameConditionHurt;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void EnemyTakeDamage()
    {
        StartCoroutine(TriggerDeactiveAfterDelay(1f));
        anim.SetTrigger(nameConditionHurt);
    }

    private IEnumerator TriggerDeactiveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
