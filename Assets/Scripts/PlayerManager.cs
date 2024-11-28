using System.Collections;
using UnityEngine;

public sealed class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject _ballPrefab;
    private void Start() {
        StartCoroutine(TestSpawnBall());
    }

    IEnumerator TestSpawnBall() {
        while(true) {
            Ball ball = Instantiate(_ballPrefab).GetComponent<Ball>();

            ball.EnableBall(ColorType.RedBall, Random.Range(0.1f, 0.5f));

            yield return new WaitForSeconds(1f);
        }
    }
}
