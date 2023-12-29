using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public Action<Transform> onTriggerEnter;
    public Action<Transform> onTriggerExit;
	
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            onTriggerEnter?.Invoke(other.transform);
        }
    }
	
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            onTriggerExit?.Invoke(other.transform);
        }
    }
}
