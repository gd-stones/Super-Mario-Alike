using System.Collections;
using UnityEngine;

public class ActiveScaleCollectible : MonoBehaviour
{
    [SerializeField] private GameObject scaleCollectible;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float moveDuration = 5f;
    private float brickFootCoordinateY;
    private float playerHeadCoordinateY;

    private void Start()
    {
        brickFootCoordinateY = transform.position.y - 0.5f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHeadCoordinateY = collision.gameObject.GetComponent<Transform>().position.y + 0.5f;

            if (brickFootCoordinateY >= playerHeadCoordinateY)
            {
                scaleCollectible.SetActive(true);
                StartCoroutine(MoveRightForDuration());
                StartCoroutine(DisableComponent());
            }
        }
    }

    private IEnumerator MoveRightForDuration()
    {
        float timer = 0f;
        while (timer < moveDuration)
        {
            Vector3 movement = new Vector3(moveSpeed, 0f, 0f);
            if (scaleCollectible != null)
                scaleCollectible.transform.Translate(movement * Time.deltaTime);

            timer += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator DisableComponent()
    {
        yield return new WaitForSeconds(moveDuration);
        Destroy(this);
    }
}
