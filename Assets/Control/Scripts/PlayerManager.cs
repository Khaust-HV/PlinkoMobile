using UnityEngine;
using Zenject;

public sealed class PlayerManager : MonoBehaviour, IPlayerAction
{
    [Header("Player Settings")]
    [SerializeField] private int _maxBallNumber;
    [SerializeField] private int _byDefaultCashNumber;

    [Inject] private IUIControlAction _iUIControlAction;
    [Inject] private IBallPoolAction _iBallPoolAction;
    [Inject] private ISpaceControl _iSpaceControl;

    private float _currentRateNumber = 0.3f;
    private float _currentCashNumber;

    // private PlayerState _playerState; // Can be used to switch between menus (Scenes)

    private void Start() {
        Physics2D.IgnoreLayerCollision(3, 3, true);
        _currentCashNumber = _byDefaultCashNumber;

        _iBallPoolAction.CreateBallPool(_maxBallNumber);
    }

    public void SetNewRateNumber(float rateNumber) {
        _currentRateNumber = rateNumber;
    }

    public void SetNewPinsNumber(int pinsNumber) {
        _iSpaceControl.SwitchPinsSet(pinsNumber);
    }

    public void ResetCash() {
        _currentCashNumber = _byDefaultCashNumber;
        _iUIControlAction.SetNewCashNumber(_currentCashNumber);
    }

    public void AddWinValue(float winValue) {
        _currentCashNumber += winValue;
        _iUIControlAction.SetNewCashNumber(_currentCashNumber);
    }

    public void CreateBall(ColorType colorType) {
        if (_iBallPoolAction.SpawnBall(colorType, _currentRateNumber)){
            _currentCashNumber -= _currentRateNumber;

            if (_currentCashNumber <= 0) _iUIControlAction.ActiveCashValueMenu();

            _iUIControlAction.SetNewCashNumber(_currentCashNumber);
        }
        else return;
    }
}

public interface IPlayerAction {
    public void SetNewRateNumber(float rateNumber);
    public void SetNewPinsNumber(int pinsNumber);
    public void AddWinValue(float winValue);
    public void CreateBall(ColorType colorType);
    public void ResetCash();
}

public enum PlayerState {
    MainMenu,
    Gameplay
}