using UnityEngine;

public class CarAnimation : MonoBehaviour
{
    private readonly Vector3 _finalPosition = new Vector3(569, 16.8f, 40);
    private Vector3 _initialPosition;

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _finalPosition, 0.1f);
    }

    private void OnDisable()
    {
        transform.position = _initialPosition;
    }
}