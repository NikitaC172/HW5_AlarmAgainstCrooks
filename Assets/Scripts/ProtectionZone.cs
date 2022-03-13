using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProtectionZone : MonoBehaviour
{
    [SerializeField] private GameObject _alarmActivationAreaParent = null;
    [SerializeField] private UnityEvent _entered = new UnityEvent();
    [SerializeField] private UnityEvent _exited = new UnityEvent();

    private ControlledArea[] _areas;

    private bool _isInside = false;
    private bool _currentAlarmState = false;

    public event UnityAction AlarmSetOn
    {
        add => _entered .AddListener(value);
        remove => _entered .RemoveListener(value);
    }

    public event UnityAction AlarmSetOff
    {
        add => _exited.AddListener(value);
        remove => _exited.RemoveListener(value);
    }

    private void ChangeAlarmStatus()
    {
        _isInside = false;

        foreach (var area in _areas)
        {
            if (area.IsInside)
            {
                _isInside = true;                
            }
        }

        if (_isInside != _currentAlarmState)
        {
            if (_isInside)
            {                
                _currentAlarmState = true;
                _entered ?.Invoke();
            }
            else
            {                
                _currentAlarmState = false;
                _exited?.Invoke();
            }
        }

    }

    private void OnEnable()
    {
        _areas = _alarmActivationAreaParent.GetComponentsInChildren<ControlledArea>();

        foreach (var area in _areas)
        {            
            area.Entered += EnteredArea;
            area.Exited += ExitedArea;
        }
    }

    private void ExitedArea()
    {
        ChangeAlarmStatus();
    }

    private void EnteredArea()
    {
        if (_isInside)
        {
            return;
        }
        else
        {
            ChangeAlarmStatus();
        }
    }

    private void OnDisable()
    {
        foreach (var area in _areas)
        {            
            area.Entered -= EnteredArea;
            area.Exited -= ExitedArea;
        }
    }
}
