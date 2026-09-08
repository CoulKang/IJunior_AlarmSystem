using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField, Min(0)] private float _moveSpeed;
    [SerializeField] private Vector3 _moveDirection;

    private void Update()
    {
        transform.position += _moveSpeed * Time.deltaTime * _moveDirection;
    }
}
