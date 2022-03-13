using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    [SerializeField] private GameObject _entrancesParent = null;
    [SerializeField] private GameObject _houseAlarm = null;
    [SerializeField] private Text _textEntranceEnter = null;
    [SerializeField] private Text _textEntranceExit = null;

    private SecureEntrances[] _entrances;
    private ProtectionZone _houseAlarmObject;

    private void OnEnable()
    {
        _entrances = _entrancesParent.GetComponentsInChildren<SecureEntrances>();
        _houseAlarmObject = _houseAlarm.GetComponent<ProtectionZone>();
        _houseAlarmObject.AlarmSetOn += ChangeTextEnter;
        _houseAlarmObject.AlarmSetOff += ChangeTextExit;

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

    private void ChangeTextExit()
    {        
        string name = FindEnrance();

        _textEntranceExit.text = name;
    }

    private void ChangeTextEnter()
    {
        _textEntranceExit.text = null;
        string name = FindEnrance();
        _textEntranceEnter.text = name;
    }

    private void OnDisable()
    {
            _houseAlarmObject.AlarmSetOn -= ChangeTextEnter;
            _houseAlarmObject.AlarmSetOff -= ChangeTextExit;
    }
}
