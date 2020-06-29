using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidTap : MonoBehaviour
{
	[SerializeField] private float timeBetweenDrops = .4f;
	[SerializeField] private Rigidbody2D dropletPrefab = null;

	[SerializeField] private Vector2 outputDirection;
	[SerializeField] private float initialSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
		InvokeRepeating("SpawnDroplet", 0, timeBetweenDrops);
		
    }

	private void SpawnDroplet() {
		Quaternion spawnRot = Quaternion.LookRotation(Vector3.forward, Vector3.Cross(outputDirection, Vector3.forward));
		Rigidbody2D droplet = Instantiate<Rigidbody2D>(dropletPrefab, transform.position, spawnRot);
		droplet.AddForce(outputDirection*initialSpeed);
	}

	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(transform.position, transform.position + (Vector3)outputDirection);
	}
}

