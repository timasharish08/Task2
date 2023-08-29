using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Tracker : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rogue")
            _signaling.TurnOn();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Rogue")
            _signaling.TurnOff();
    }
}
