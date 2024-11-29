using UnityEngine;
using UnityEngine.UI;
using Zenject;

public sealed class ButtonWithValue : MonoBehaviour
{
    [Header("Button Control")]
    [SerializeField] private Text _textButton;
    [SerializeField] private float _betNumber;
    [SerializeField] private MenuType _menuType;
    [SerializeField] private int _buttonId;

    private Image _image;
    private IUIControlAction _iUIControlAction;

    [Inject]
    private void Construct(IUIControlAction iUIControlAction) {
        _iUIControlAction = iUIControlAction;
        SubToButtonToDarken();
    }

    private void SubToButtonToDarken() {
        switch (_menuType) {
            case MenuType.BetMenu:
                _iUIControlAction.BetMenuButtonsToDarken += IsToDarkenColor;
            break;

            case MenuType.PinsMenu:
                _iUIControlAction.PinMenuButtonsToDarken += IsToDarkenColor;
            break;
        }
    }

    private void Start() {
        _textButton.text = _betNumber.ToString();
    }

    public void ButtonActionSetNewRate() {
        _iUIControlAction.SetNewRateNumberOnId(_buttonId);
        IsToDarkenColor(false);
    }

    public void ButtonActionSetNewPins(int pinsNumber) {
        _iUIControlAction.SetNewPinsNumber(pinsNumber);
        IsToDarkenColor(false);
    }

    public float GetBetNumber() {
        return _betNumber;
    }

    public void IsToDarkenColor(bool isToDarken) {
        if (_image == null) _image = GetComponent<Image>();

        if (isToDarken) {
            _image.color = new Color32(67, 37, 128, 255);
        }
        else {
            _image.color = new Color32(140, 69, 255, 255);
        }
    }
}

public enum MenuType {
    BetMenu,
    PinsMenu
}