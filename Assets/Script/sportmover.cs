using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sportmover : MonoBehaviour
{
    [SerializeField]
    private GameObject startPoint;
    [SerializeField]
    private GameObject endPoint;
    [SerializeField]
    private GameObject target;

    private const float CLOSE_DISTANCE = 1f;
    private const float SPEED = 10.0f;

    [SerializeField]
    private bool flipLookDirection = false;

    void Start()
    {
        // Optional: Set target if not set in Inspector
        if (target == null)
        {
            target = endPoint;
        }
    }

    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0;

        float distance = direction.magnitude;

        if (distance > 0)
        {
            Quaternion rotation = flipLookDirection
                ? Quaternion.LookRotation(-direction, Vector3.up)
                : Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = rotation;
        }

        Vector3 normDirection = direction.normalized;
        transform.position += normDirection * SPEED * Time.deltaTime;

        if (distance < CLOSE_DISTANCE)
        {
            if (target.Equals(startPoint))
            {
                target = endPoint;
            }
            else
            {
                target = startPoint;
            }
        }
    }
}
