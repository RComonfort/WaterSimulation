using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorObject : MonoBehaviour
{
	[SerializeField] private float rpm = 60;

    // Update is called once per frame
    void Update()
    {
		float rotSpeed = rpm * 6 * Time.deltaTime; // deg / frame
        transform.Rotate(Vector3.forward * rotSpeed, Space.Self);
    }
}
