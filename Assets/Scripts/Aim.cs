using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public bool _mouseEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (_mouseEnabled)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position);
        } else
        {
            float rx = Input.GetAxis("RightHorizontal");
            float ry = Input.GetAxis("RightVertical");

            Debug.Log(rx + "," + ry);

            if (rx != 0 || ry != 0)
            {
                Vector3 axisPosition = new Vector3(rx, ry, 0) + transform.position;

                transform.rotation = Quaternion.LookRotation(Vector3.forward, axisPosition - transform.position);
            } else
            {
                transform.rotation = transform.parent.rotation;
            }
        }
    }
}
