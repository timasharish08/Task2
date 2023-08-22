using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private float _volumeChangeTime;
    [SerializeField] private bool _isOn;

    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isOn)
            _audio.volume = Mathf.MoveTowards(_audio.volume, 1, Time.deltaTime / _volumeChangeTime);
        else
            _audio.volume = Mathf.MoveTowards(_audio.volume, 0, Time.deltaTime / _volumeChangeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isOn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isOn = false;
    }
}
