using System.Collections;
using System.Linq;
using UnityEngine;

public class Rogue : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _waitTime;

    private Vector3[] _positions;
    private int _currentPosition;

    private bool _isMoving;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _positions = GetComponentsInChildren<Transform>().Select(child => child.position).ToArray();
        _rigidbody = GetComponent<Rigidbody2D>();
        _isMoving = true;
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            _rigidbody.position = Vector3.MoveTowards(_rigidbody.position, _positions[_currentPosition], _speed * Time.deltaTime);

            if (transform.position == _positions[_currentPosition])
            {
                _currentPosition = ++_currentPosition % _positions.Length;
                _isMoving = false;
                StartCoroutine(Wait());
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_waitTime);
        _isMoving = true;
    }
}