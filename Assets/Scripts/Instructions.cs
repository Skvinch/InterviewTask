using UnityEngine;

public class Instructions : MonoBehaviour
{
    [SerializeField] private GameObject _instructionsPanel;
    
    public void OpenInstructionsPanel() => _instructionsPanel.SetActive(true);
    public void CloseInstructionsPanel() => _instructionsPanel.SetActive(false);
}
