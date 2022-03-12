using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SecureEntrances : MonoBehaviour
{
    [SerializeField] private string _name = null;

    private bool isNearEntrance = false;

    public string Name => _name;
    public bool IsNearEntrance => isNearEntrance;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            isNearEntrance = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            isNearEntrance = false;
        }
    }
}
