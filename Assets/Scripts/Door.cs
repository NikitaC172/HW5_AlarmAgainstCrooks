using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private string _isOpen = "IsOpen";

    public void Use()
    {
        Animator animatorController = GetComponentInParent<Animator>();
        animatorController.SetBool(_isOpen, !animatorController.GetBool(_isOpen));
    }
}
