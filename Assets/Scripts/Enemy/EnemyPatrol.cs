using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private float movementDistance;
    private float leftEdge;
    private float rightEdge;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft = true;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Condition run animation")]
    [SerializeField] private string condition; //radish_Run
    private Animator anim;

    private void Start()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
        anim = gameObject.GetComponent<Animator>();
    }

    private void Awake()
    {
        initScale = transform.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool(condition, false);
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x >= leftEdge)
            {
                MoveInDirection(1);
            }
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (transform.position.x <= rightEdge)
            {
                MoveInDirection(-1);
            }
            else
            {
                DirectionChange();
            }
        }
    }

    private void DirectionChange()
    {
        anim.SetBool(condition, false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool(condition, true);

        //make transform face direction
        transform.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        //move in that direction
        transform.position = new Vector3(transform.position.x + Time.deltaTime * -_direction * speed,
            transform.position.y, transform.position.z);
    }
}
