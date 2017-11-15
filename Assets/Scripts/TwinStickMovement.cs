using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinStickMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;

    private Rigidbody2D _rb;

    private float _xAxisInput;
    private float _yAxisInput;

    private Vector2 _movement;

    // Use this for initialization
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _xAxisInput = Input.GetAxis("Horizontal");
        _yAxisInput = Input.GetAxis("Vertical");

        _movement = new Vector2(_xAxisInput, _yAxisInput);

        if (_movement.magnitude > 1)
        {
            _movement.Normalize();
        }

        if (_movement != Vector2.zero)
        {
            // My trig is rusty so I'm not sure what this math is doing really...I'd like to actually understand this code though.
            // Subtract 90 degrees since the art asset is pointing up and not to the right.
            float angle = Mathf.Atan2(_movement.y, _movement.x) * Mathf.Rad2Deg - 90;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movement * _speed;
    }
}
