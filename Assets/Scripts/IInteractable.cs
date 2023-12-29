using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public GameObject  InteractVisual { get; set; }
    void Interact();
    void SetFocus(bool enable);
}
