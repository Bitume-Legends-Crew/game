using UnityEngine;

public class CarAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 FinalPosition;
    private Vector3 initialPosition;
    
    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, FinalPosition, 0.1f);
    }

    private void OnDisable()
    {
        transform.position = initialPosition;
    }
}