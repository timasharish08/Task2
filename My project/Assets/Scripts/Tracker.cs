using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Tracker : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rogue>(out Rogue rogue))
            _signaling.TurnOn();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rogue>(out Rogue rogue))
            _signaling.TurnOff();
    }
}
