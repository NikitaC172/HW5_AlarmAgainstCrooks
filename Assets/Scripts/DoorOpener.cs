using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private float _distance = 5f;
    //[SerializeField] private string _isOpen = "IsOpen";

    private RaycastHit _hit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out _hit, _distance))
            {          
                if (_hit.collider.TryGetComponent<Door>(out Door Door))
                {
                    Door.Use();
                }
            }
        }
    }
}
