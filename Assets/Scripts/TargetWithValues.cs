using UnityEngine;
using Zenject;

public sealed class TargetWithValues : MonoBehaviour
{
    [Header("Square Text Settings")]
    [SerializeField] private TextMesh _greenSquareText;
    [SerializeField] private TextMesh _yellowSquareText;
    [SerializeField] private TextMesh _redSquareText;
    [SerializeField] private float _greenSquareValue;
    [SerializeField] private float _yellowSquareValue;
    [SerializeField] private float _redSquareValue;
    [Header("Square Animation Settings")]
    [SerializeField] private Animator _greenSquareAnimator;
    [SerializeField] private Animator _yellowSquareAnimator;
    [SerializeField] private Animator _redSquareAnimator;

    [Inject] private IPlayerAction _iPlayerAction;
    [Inject] private IUIControlAction _iUIControlAction;

    private void Start() {
        _greenSquareText.text = _greenSquareValue.ToString();
        _yellowSquareText.text = _yellowSquareValue.ToString();
        _redSquareText.text = _redSquareValue.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ball")) {
            Ball ball = other.GetComponent<Ball>();

            float result = 0;

            switch(ball.ColorBall) {
                case ColorType.GreenBall:
                    result = ball.RateValue * _greenSquareValue;
                    _greenSquareAnimator.Play("InteractionWithObject", 0, 0f);
                break;

                case ColorType.YellowBall:
                    result = ball.RateValue * _yellowSquareValue;
                    _yellowSquareAnimator.Play("InteractionWithObject", 0, 0f);
                break;

                case ColorType.RedBall:
                    result = ball.RateValue * _redSquareValue;
                    _redSquareAnimator.Play("InteractionWithObject", 0, 0f);
                break;
            }

            _iUIControlAction.SetWinCashNumber(result);

            _iPlayerAction.AddWinValue(result);

            ball.DisableBall();
        }
    }
}