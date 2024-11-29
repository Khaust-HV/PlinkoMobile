using System.Collections.Generic;
using UnityEngine;

public sealed class BallPool : MonoBehaviour, IBallPoolAction
{
    [Header("BallPool Settings")]
    [SerializeField] GameObject _ballPrefab;

    private List<Ball> _ballList = new List<Ball>();

    public void CreateBallPool(int ballNumber) {
        for (int i = 0; i < ballNumber; i++) {
            Ball ball = Instantiate(_ballPrefab, transform).GetComponent<Ball>();
            
            ball.BallInit();

            _ballList.Add(ball);
        }
    }

    public bool SpawnBall(ColorType colorType, float rateValue) {
        foreach (Ball ball in _ballList) {
            if (!ball.IsEnableBall) {
                ball.EnableBall(colorType, rateValue);
                return true;
            }
        }
        return false;
    }
}

public interface IBallPoolAction {
    public void CreateBallPool(int ballNumber);
    public bool SpawnBall(ColorType colorType, float rateValue);
}