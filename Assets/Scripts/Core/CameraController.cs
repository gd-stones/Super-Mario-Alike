using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Update()
    {
        //Follow player
        //if (player.position.y > 3.5f)
        //{
        //    transform.position = new Vector3(player.position.x + lookAhead, player.position.y, transform.position.z);
        //    lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
        //}
        //else
        //{
        //    transform.position = new Vector3(player.position.x + lookAhead, Mathf.Lerp(0, player.position.y, Time.deltaTime * cameraSpeed), transform.position.z);
        //    lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
        //}

        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }
}
