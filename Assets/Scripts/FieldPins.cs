using UnityEngine;

public sealed class FieldPins : MonoBehaviour
{
    [Header("Field Settings")]
    [SerializeField] GameObject _pinPrefab;
    [SerializeField] int _rowsNumber;
    [SerializeField] float _distance;
    [SerializeField] float _pinSize;

    void Start()
    {
        PlacePins();
    }

    void PlacePins()
    {
        int totalRows = _rowsNumber + 2; 

        for (int i = 2; i < totalRows; i++) {
            float y = -(i - 2) * _distance;

            for (int j = 0; j <= i; j++) {
                float x = j * _distance - (i * _distance) / 2;

                Vector3 position = new Vector3(x, y, 0);

                Instantiate (
                    _pinPrefab, 
                    position, 
                    Quaternion.identity, 
                    transform
                ).transform.localScale = new Vector3(_pinSize, _pinSize, _pinSize);
            }
        }
    }
}
