using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SecureEntrances : MonoBehaviour
{
    [SerializeField] private string _name = null;   

    public string Name => _name;
    public bool IsNearEntrance { get; private set; }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsNearEntrance = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsNearEntrance = false;
        }
    }
}
