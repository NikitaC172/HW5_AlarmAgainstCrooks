using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    [SerializeField] private GameObject _parrentSecureEntrances = null;
    [SerializeField] private GameObject _houseAlarm = null;
    [SerializeField] private GameObject _textEntranceEnter = null;
    [SerializeField] private GameObject _textEntranceExit = null;

    private SecureEntrances[] _entrances;
    private ProtectionZone _houseAlarmObject;

    private void OnEnable()
    {
        _entrances = _parrentSecureEntrances.GetComponentsInChildren<SecureEntrances>();
        _houseAlarmObject = _houseAlarm.GetComponent<ProtectionZone>();
        _houseAlarmObject.AlarmSetOn += _houseAlarmObject_AlarmSetOn;
        _houseAlarmObject.AlarmSetOff += _houseAlarmObject_AlarmSetOff;

    }

    private string FindEnrance()
    {
        string name = "Неизвестно как!";

        foreach (var entrance in _entrances)
        {
            if (entrance.IsNearEntrance)
            {
                name = entrance.Name;
            }
        }

        return name;
    }

    private void _houseAlarmObject_AlarmSetOff()
    {
        var textExit = _textEntranceExit.GetComponent<Text>();
        string name = FindEnrance();

        textExit.text = name;
    }

    private void _houseAlarmObject_AlarmSetOn()
    {
        var textEnter = _textEntranceEnter.GetComponent<Text>();
        var textExit = _textEntranceExit.GetComponent<Text>();
        textExit.text = null;
        string name = FindEnrance();
        textEnter.text = name;
    }

    private void OnDisable()
    {
            _houseAlarmObject.AlarmSetOn -= _houseAlarmObject_AlarmSetOn;
            _houseAlarmObject.AlarmSetOff -= _houseAlarmObject_AlarmSetOff;
    }
}
