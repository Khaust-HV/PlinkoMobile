using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIControl : MonoBehaviour, IUIControlAction
{
    [Header("UI Settings")]
    [SerializeField] private Text _rateNumber;
    [SerializeField] private Text _pinsNumber;
    [SerializeField] private Text _cashNumber;
    [SerializeField] private Text _addCashNumber;
    [SerializeField] private Animator _addCashAnim;
    [SerializeField] private GameObject _resetCashValueMenu;
    [SerializeField] private ButtonWithValue[] _buttonsWithValue;

    public event Action<bool> BetMenuButtonsToDarken;
    public event Action<bool> PinMenuButtonsToDarken;

    [Inject] private IPlayerAction _iPlayerAction;
    private int currentRateId = 2;

    public void SetWinCashNumber(float cashNumber) {
        _addCashNumber.text = "+" + cashNumber.ToString();

        _addCashAnim.Play("Fading", 0, 0f);
    }

    public void ButtonSetNewRateNumber(string addOrDecrease) {
        switch (addOrDecrease) {
            case "+":
                if (currentRateId + 1 >= _buttonsWithValue.Length) return;
                currentRateId++;
            break;

            case "-":
                if (currentRateId <= 0) return;
                currentRateId--;
            break;
        }

        SetNewRateNumber(_buttonsWithValue[currentRateId].GetBetNumber());

        _buttonsWithValue[currentRateId].IsToDarkenColor(false);
    }

    public void SetNewRateNumberOnId(int buttonId) {
        currentRateId = buttonId;

        SetNewRateNumber(_buttonsWithValue[currentRateId].GetBetNumber());
    }

    private void SetNewRateNumber(float rateNumber) {
        _iPlayerAction.SetNewRateNumber(rateNumber);

        _rateNumber.text = rateNumber.ToString();

        BetMenuButtonsToDarken?.Invoke(true);
    }

    public void SetNewPinsNumber(int pinsNumber) {
        _iPlayerAction.SetNewPinsNumber(pinsNumber);

        _pinsNumber.text = "Pins: " + pinsNumber.ToString();

        PinMenuButtonsToDarken?.Invoke(true);
    }

    public void ActiveCashValueMenu() {
        _resetCashValueMenu.SetActive(true);
    }

    public void ResetCash() {
        _iPlayerAction.ResetCash();
    }

    public void SetNewCashNumber(float cashNumber) {
        _cashNumber.text = cashNumber.ToString();
    }

    public void PlaceBet(string color) {
        ColorType colorType = color switch {
            "Green" => ColorType.GreenBall,
            "Yellow" => ColorType.YellowBall,
            "Red" => ColorType.RedBall,
            _ => ColorType.GreenBall
        };

        _iPlayerAction.CreateBall(colorType);
    }
}

public interface IUIControlAction {
    public event Action<bool> BetMenuButtonsToDarken;
    public event Action<bool> PinMenuButtonsToDarken;
    public void SetNewRateNumberOnId(int buttonId);
    public void SetNewPinsNumber(int pinsNumber);
    public void SetNewCashNumber(float cashNumber);
    public void SetWinCashNumber(float cashNumber);
    public void ActiveCashValueMenu();
}