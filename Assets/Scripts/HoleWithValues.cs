using UnityEngine;

public sealed class HoleWithValues : MonoBehaviour
{
    [Header("Square Text Settings")]
    [SerializeField] TextMesh _greenSquareText;
    [SerializeField] TextMesh _yellowSquareText;
    [SerializeField] TextMesh _redSquareText;
    [SerializeField] float _greenSquareValue;
    [SerializeField] float _yellowSquareValue;
    [SerializeField] float _redSquareValue;
    [Header("Square Animation Settings")]
    [SerializeField] Animator _greenSquareAnimator;
    [SerializeField] Animator _yellowSquareAnimator;
    [SerializeField] Animator _redSquareAnimator;

    // private PlayerManager Interface

    private void Start() {
        _greenSquareText.text = _greenSquareValue.ToString();
        _yellowSquareText.text = _yellowSquareValue.ToString();
        _redSquareText.text = _redSquareValue.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ball")) {
            Ball ball = other.GetComponent<Ball>();

            float result;

            switch(ball.ColorBall) {
                case ColorType.GreenBall:
                    result = ball.RateValue * _greenSquareValue;
                    _greenSquareAnimator.Play("InteractionWithObject");
                break;

                case ColorType.YellowBall:
                    result = ball.RateValue * _yellowSquareValue;
                    _yellowSquareAnimator.Play("InteractionWithObject");
                break;

                case ColorType.RedBall:
                    result = ball.RateValue * _redSquareValue;
                    _redSquareAnimator.Play("InteractionWithObject");
                break;
            }

            //PlayerManager(result, colorType) Interface
            Debug.Log("Rate value = " + ball.RateValue + " ColorType = " + ball.ColorBall);

            ball.DisableBall();
        }
    }
}
