using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private PlayerTrigger _playerTrigger;
    
    private List<IInteractable> _currentInteractables = new List<IInteractable>();
    
    private void OnEnable()
    {
        _playerTrigger.onTriggerEnter += OnInteractableEnter;
        _playerTrigger.onTriggerExit += OnInteractableExited;
    }
    
    private void OnDisable()
    {
        _playerTrigger.onTriggerEnter -= OnInteractableEnter;
        _playerTrigger.onTriggerExit -= OnInteractableExited;
    }

    private void Update()
    {
        if (_currentInteractables.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _currentInteractables[^1].Interact();
                if (_currentInteractables.Count > 0)
                {
                    _currentInteractables[^1].SetFocus(true);
                }
            }
        }
    }

    private void OnInteractableEnter(Transform obj)
    {
        IInteractable interactableToAdd = obj.GetComponent<IInteractable>();
        _currentInteractables.Add(interactableToAdd);
        for (int i = 0; i < _currentInteractables.Count; i++)
        {
            _currentInteractables[i].SetFocus(false);
        }
        if (_currentInteractables.Count > 0)
        {
            _currentInteractables[^1].SetFocus(true);
        }
    }
    
    private void OnInteractableExited(Transform obj)
    {
        IInteractable interactableToRemove = obj.GetComponent<IInteractable>();
        interactableToRemove.SetFocus(false);
        _currentInteractables.Remove(interactableToRemove);
        
        if (_currentInteractables.Count > 0)
        {
            _currentInteractables[^1].SetFocus(true);
        }
    }
}
