using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmAnimationActivate : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private string AlarmActvator = "StartAlarm";
    [SerializeField] private string AlarmIdle = "Idle";

    public void StartAlarm()
    {
        animator.Play(AlarmActvator);
    }

    public void StopAlarm()
    {
        animator.Play(AlarmIdle);
    }
}
