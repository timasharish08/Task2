using System.Collections;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private float _volumeChangeTime;
    [SerializeField] private bool _isOn;

    private AudioSource _audio;
    private Coroutine _audioChanger;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void TurnOn()
    {
        if (_audioChanger != null)
            StopCoroutine(_audioChanger);

        _audioChanger = StartCoroutine(ChangeAudioVolume(1));
    }

    public void TurnOff()
    {
        if (_audioChanger != null)
            StopCoroutine(_audioChanger);

        _audioChanger = StartCoroutine(ChangeAudioVolume(0));
    }

    private IEnumerator ChangeAudioVolume(float targetVolume)
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();

        while (_audio.volume != targetVolume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, targetVolume, Time.deltaTime / _volumeChangeTime);
            yield return wait;
        }
    }
}
