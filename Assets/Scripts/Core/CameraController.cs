using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject characterManager;
    private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Start()
    {
        player = characterManager.GetComponent<CharacterManager>().characterActive.GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }
}
