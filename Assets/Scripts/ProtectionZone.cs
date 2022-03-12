using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProtectionZone : MonoBehaviour
{
    [SerializeField] private GameObject _parrentProtectionZone = null;
    [SerializeField] private UnityEvent _houseAlarmSetOn = new UnityEvent();
    [SerializeField] private UnityEvent _houseAlarmSetOff = new UnityEvent();

    private ControlledAreaAlarm[] _areas;

    private bool _isInsade = false;
    private bool _сurrentState = false;

    public event UnityAction AlarmSetOn
    {
        add => _houseAlarmSetOn.AddListener(value);
        remove => _houseAlarmSetOn.RemoveListener(value);
    }

    public event UnityAction AlarmSetOff
    {
        add => _houseAlarmSetOff.AddListener(value);
        remove => _houseAlarmSetOff.RemoveListener(value);
    }

    private void СheckAlarm()
    {
        _isInsade = false;

        foreach (var area in _areas)
        {
            if (area.IsInsade)
            {
                _isInsade = true;                
            }
        }

        if (_isInsade != _сurrentState)
        {
            if (_isInsade)
            {                
                _сurrentState = true;
                _houseAlarmSetOn?.Invoke();
            }
            else
            {                
                _сurrentState = false;
                _houseAlarmSetOff?.Invoke();
            }
        }

    }

    private void OnEnable()
    {
        _areas = _parrentProtectionZone.GetComponentsInChildren<ControlledAreaAlarm>();

        foreach (var area in _areas)
        {            
            area.Entered += Area_Entered;
            area.Exited += Area_Exited;
        }
    }

    private void Area_Exited()
    {
        СheckAlarm();
    }

    private void Area_Entered()
    {
        if (_isInsade)
        {
            return;
        }
        else
        {
            СheckAlarm();
        }
    }

    private void OnDisable()
    {
        foreach (var area in _areas)
        {            
            area.Entered -= Area_Entered;
            area.Exited -= Area_Exited;
        }
    }
}
