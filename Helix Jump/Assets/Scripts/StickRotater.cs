using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickRotater : MonoBehaviour
{
    public float rotateSpeed;
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X");

        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0f, horizontal * rotateSpeed * Time.fixedDeltaTime * -1, 0f);
        }
    }
}
