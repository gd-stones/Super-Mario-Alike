using System.Collections;
using UnityEngine;

public class ActiveCoinCollectible : MonoBehaviour
{
    [SerializeField] private GameObject coinCollectible;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coinCollectible.SetActive(true);
            Destroy(this);

            //StartCoroutine(DisableComponent());
        }
    }

    private IEnumerator DisableComponent()
    {
        yield return null;
        Destroy(this);
    }
}
