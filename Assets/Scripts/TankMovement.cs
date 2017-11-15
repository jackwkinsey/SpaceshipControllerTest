using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [SerializeField]
    private float _thrustSpeed = 10f;

    [SerializeField]
    private float _rotationSpeed = 3f;

    private Rigidbody2D _rb;

    private float _yAxisInput;
    private float _xAxisInput;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        _xAxisInput = Input.GetAxis("Horizontal");
        _yAxisInput = Input.GetAxis("Vertical");

        transform.Rotate(0, 0, _xAxisInput * -_rotationSpeed);
    }

    private void FixedUpdate()
    {
        if (_yAxisInput != 0)
        {
            _rb.velocity = transform.up * _thrustSpeed;
            //_rb.AddForce(transform.up * _thrustSpeed);
        } else
        {
            _rb.velocity = new Vector2(0, 0);
        }
    }
}
