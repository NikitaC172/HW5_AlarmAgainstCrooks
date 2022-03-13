using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlledAreaAlarm : MonoBehaviour
{
    private UnityEvent _entered = new UnityEvent();
    private UnityEvent _exited = new UnityEvent();

    private bool isInside;

    public bool IsInsade => isInside;

    public event UnityAction Entered
    {
        add => _entered.AddListener(value);
        remove => _entered.RemoveListener(value);
    }

    public event UnityAction Exited
    {
        add => _exited.AddListener(value);
        remove => _exited.RemoveListener(value);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {            
            isInside = true;
            _entered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {            
            isInside = false;
            _exited?.Invoke();
        }
    }
}
