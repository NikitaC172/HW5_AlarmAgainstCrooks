using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAlarm : MonoBehaviour
{
    [SerializeField] private float _timeChangeSound = 10f;
    [SerializeField] private AudioSource _audio = null;

    private float currentVolume = 0f;
    private float maxVolume = 1f;
    private bool isActive;


    public void StartCoroutine()
    {
        isActive = true;
        _audio.volume = 0f;
        _audio.Play();
        StartCoroutine(ChangeVolumeSound(_timeChangeSound));
    }

    public void StopCoroutine()
    {
        isActive = false;
    }

    private IEnumerator ChangeVolumeSound(float timeChangeSound)
    {
        float stepWait = 0.5f;
        var waitHalfSecond = new WaitForSeconds(stepWait);

        while (isActive)
        {
            for (int i = 0; i < Convert.ToInt32(_timeChangeSound / stepWait); i++)
            {
                currentVolume = Mathf.MoveTowards(currentVolume, maxVolume, (1 / timeChangeSound) * stepWait);
                _audio.volume = currentVolume;
                yield return waitHalfSecond;
            }

            for (int i = Convert.ToInt32(_timeChangeSound / stepWait); i > 0; i--)
            {
                currentVolume = Mathf.MoveTowards(currentVolume, maxVolume, -(1 / timeChangeSound) * stepWait);
                _audio.volume = currentVolume;
                yield return waitHalfSecond;
            }
        }

        StopCoroutine(ChangeVolumeSound(_timeChangeSound));
    }
}
