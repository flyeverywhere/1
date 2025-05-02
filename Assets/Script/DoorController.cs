using UnityEngine;

public class CafeDoor : MonoBehaviour
{
    public float openAngle = 90f;             // Angle to open
    public float openSpeed = 2f;              // Speed of door opening
    public KeyCode openKey = KeyCode.E;       // Key to trigger
    private bool isPlayerNearby = false;
    private bool isOpen = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    void Start()
    {
        initialRotation = transform.localRotation;
        targetRotation = Quaternion.Euler(transform.localEulerAngles + new Vector3(0, openAngle, 0));
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(openKey))
        {
            isOpen = !isOpen;
        }

        // Smooth rotate to open/close
        if (isOpen)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * openSpeed);
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, initialRotation, Time.deltaTime * openSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
