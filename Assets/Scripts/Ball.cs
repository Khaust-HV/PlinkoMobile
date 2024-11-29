using UnityEngine;

public sealed class Ball : MonoBehaviour
{
    [Header("Spawn Position")]
    [SerializeField] Vector2 _pointA;
    [SerializeField] Vector2 _pointB;

    public ColorType ColorBall { get; private set; }
    public float RateValue { get; private set; }
    public bool IsEnableBall { get; private set; }

    private SpriteRenderer _srBall;

    // private void Start() {
    //     _srBall = GetComponent<SpriteRenderer>();
    // }

    public void EnableBall(ColorType colorType, float rateValue) {
        float spawnPoint = Random.Range(_pointA.x, _pointB.x);

        transform.position = new Vector2(spawnPoint, _pointA.y);

        _srBall = GetComponent<SpriteRenderer>();

        _srBall.color = colorType switch
        {
            ColorType.GreenBall => Color.green,
            ColorType.YellowBall => Color.yellow,
            ColorType.RedBall => Color.red,
            _ => _srBall.color
        };

        RateValue = rateValue;
        ColorBall = colorType;
        IsEnableBall = true;

        gameObject.SetActive(true);
    }

    public void DisableBall() {
        gameObject.SetActive(false);

        IsEnableBall = false;
    }
}

public enum ColorType {
    GreenBall,
    YellowBall,
    RedBall
}