using UnityEngine;

public sealed class ToggleWindowAction : MonoBehaviour
{
    [SerializeField] private GameObject _window;

    public void ToggleWindowSwitch() {
        _window.SetActive(!_window.activeSelf);
    }
}