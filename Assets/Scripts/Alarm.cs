using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private string AlarmActvator = "StartAlarm";
    [SerializeField] private string AlarmIdle = "Idle";

    [SerializeField] private float _timeChangeSound = 10f;
    [SerializeField] private AudioSource _audio = null;

    private float _currentVolume = 0f;
    private float _maxVolume = 1f;
    private bool _isActive = false;
    private bool _currentState = false;

    public void TurnOn()
    {
        _isActive = true;

        if (_currentState == false)
        {
            animator.Play(AlarmActvator);
            _audio.volume = 0f;
            _audio.Play();
            StartCoroutine(ChangeVolumeSound(_timeChangeSound));
        }
    }

    public void TurnOff()
    {
        _isActive = false;
    }

    private IEnumerator ChangeVolumeSound(float timeChangeSound)
    {
        float stepWait = 0.5f;
        _currentState = true;
        var waitHalfSecond = new WaitForSeconds(stepWait);

        while (_isActive)
        {
            for (int i = 0; i < Convert.ToInt32(_timeChangeSound / stepWait); i++)
            {
                _currentVolume = Mathf.MoveTowards(_currentVolume, _maxVolume, (1 / timeChangeSound) * stepWait);
                _audio.volume = _currentVolume;
                yield return waitHalfSecond;
            }

            for (int i = Convert.ToInt32(_timeChangeSound / stepWait); i > 0; i--)
            {
                _currentVolume = Mathf.MoveTowards(_currentVolume, _maxVolume, -(1 / timeChangeSound) * stepWait);
                _audio.volume = _currentVolume;
                yield return waitHalfSecond;
            }
        }

        _currentState = false;
        StopCoroutine(ChangeVolumeSound(_timeChangeSound));
        _audio.Stop();
        animator.Play(AlarmIdle);
    }
}
