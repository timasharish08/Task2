using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private float _volumeChangeTime;
    [SerializeField] private bool _isOn;

    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void On()
    {
        print("on");
        StopCoroutine(OffAudio());
        StartCoroutine(OnAudio());
    }

    public void Off()
    {
        print("off");
        StopCoroutine((OnAudio()));
        StartCoroutine(OffAudio());
    }

    private IEnumerator OnAudio()
    {
        WaitForFixedUpdate wait = new WaitForFixedUpdate();

        while (_audio.volume < 1)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, 1, Time.deltaTime / _volumeChangeTime);
            yield return wait;
        }
    }

    private IEnumerator OffAudio()
    {
        WaitForFixedUpdate wait = new WaitForFixedUpdate();

        while (_audio.volume > 0)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, 0, Time.deltaTime / _volumeChangeTime);
            yield return wait;
        }
    }
}
