using System.Collections;
using UnityEngine;
using System;

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
        WaitForFixedUpdate wait = new WaitForFixedUpdate();

        StopCoroutine(OffAudio(wait));
        StartCoroutine(OnAudio(wait));
    }

    public void Off()
    {
        WaitForFixedUpdate wait = new WaitForFixedUpdate();

        StopCoroutine(OnAudio(wait));
        StartCoroutine(OffAudio(wait));
    }

    private IEnumerator OnAudio(WaitForFixedUpdate wait)
    {
        while (_audio.volume < 1)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, 1, Time.deltaTime / _volumeChangeTime);
            yield return wait;
        }
    }

    private IEnumerator OffAudio(WaitForFixedUpdate wait)
    {
        while (_audio.volume > 0)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, 0, Time.deltaTime / _volumeChangeTime);
            yield return wait;
        }
    }
}
