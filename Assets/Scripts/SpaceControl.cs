using UnityEngine;

public sealed class SpaceControl : MonoBehaviour, ISpaceControl
{
    [SerializeField] GameObject[] _pinsSets;
    public void SwitchPinsSet(int pinsNumber) { // Simplification
        foreach (var pinsSet in _pinsSets) {
            pinsSet.SetActive(false);
        }

        switch (pinsNumber) {
            case 12:
                _pinsSets[0].SetActive(true);
            break;

            case 14:
                _pinsSets[1].SetActive(true);
            break;

            case 16:
                _pinsSets[2].SetActive(true);
            break;
        }
    }
}

public interface ISpaceControl {
    public void SwitchPinsSet(int pinsNumber);
}