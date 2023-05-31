using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private string nameConditionHurt;
    [SerializeField] private float delayTimeDeactive;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void EnemyTakeDamage()
    {
        anim.SetTrigger(nameConditionHurt);
        StartCoroutine(TriggerDeactiveAfterDelay(delayTimeDeactive));
    }

    private IEnumerator TriggerDeactiveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
