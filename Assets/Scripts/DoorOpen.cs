using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private float _distance = 5f;
    [SerializeField] private string _isOpen = "IsOpen";

    private RaycastHit _hit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out _hit, _distance))
            {          
                if (_hit.collider.TryGetComponent<AnimatedDoor>(out AnimatedDoor animatedDoor))
                {
                    Animator animatorController = _hit.collider.GetComponentInParent<Animator>();
                    animatorController.SetBool(_isOpen, !animatorController.GetBool(_isOpen));
                }
            }
        }
    }
}
