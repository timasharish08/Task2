using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Tracker : MonoBehaviour
{
    [SerializeField] private Signaling signaling;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        signaling.On();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        signaling.Off();
    }
}
