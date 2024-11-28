using UnityEngine;
using UnityEngine.UI;

public sealed class HoleWithValues : MonoBehaviour
{
    [Header("Square Text Settings")]
    [SerializeField] Text _greenSquareText;
    [SerializeField] Text _yellowSquareText;
    [SerializeField] Text _redSquareText;
    [SerializeField] float _greenSquareValue;
    [SerializeField] float _yellowSquareValue;
    [SerializeField] float _redSquareValue;
    [Header("Square Animation Settings")]
    [SerializeField] Animator _greenSquareAnimator;
    [SerializeField] Animator _yellowSquareAnimator;
    [SerializeField] Animator _redSquareAnimator;

    // private PlayerManager Interface

    // private void Start() {
    //     _greenSquareText.text = _greenSquareValue.ToString();
    //     _yellowSquareText.text = _yellowSquareValue.ToString();
    //     _redSquareText.text = _redSquareValue.ToString();
    // }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ball")) {
            Ball ball = other.GetComponent<Ball>();

            float result;

            switch(ball.ColorBall) {
                case ColorType.GreenBall:
                    result = ball.RateValue * _greenSquareValue;
                break;

                case ColorType.YellowBall:
                    result = ball.RateValue * _yellowSquareValue;
                break;

                case ColorType.RedBall:
                    result = ball.RateValue * _redSquareValue;
                break;
            }

            //PlayerManager(result, colorType) Interface
            Debug.Log("Rate value = " + ball.RateValue + "ColorType = " + ball.ColorBall);

            ball.DisableBall();
        }
    }
}
