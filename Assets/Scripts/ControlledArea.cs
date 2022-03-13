using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlledArea : MonoBehaviour
{
    private UnityEvent _entered = new UnityEvent();
    private UnityEvent _exited = new UnityEvent();

    public bool IsInside { get; private set; }

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
            IsInside = true;
            _entered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsInside = false;
            _exited?.Invoke();
        }
    }
}
