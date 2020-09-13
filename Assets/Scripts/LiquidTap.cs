using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidTap : MonoBehaviour
{
	[SerializeField] private float timeBetweenDrops = .4f;
	[SerializeField] private Rigidbody2D dropletPrefab = null;
	[SerializeField] private int maxDrops = 100;

	[SerializeField] private Vector2 outputDirection;
	[SerializeField] private float initialSpeed = 10f;

	private int dropsExpelled = 0;

    // Start is called before the first frame update
    void Start()
    {
		Init();
		
    }

	public void Init() {
		dropsExpelled = 0;
		InvokeRepeating("SpawnDroplet", 0, timeBetweenDrops);
	}

	private void SpawnDroplet() {

		if (maxDrops > 0 && dropsExpelled == maxDrops)
		{
			CancelInvoke("SpawnDroplet");
			return;
		}

		Quaternion spawnRot = Quaternion.LookRotation(Vector3.forward, Vector3.Cross(outputDirection, Vector3.forward));
		Rigidbody2D droplet = Instantiate<Rigidbody2D>(dropletPrefab, transform.position, spawnRot);
		droplet.AddForce(outputDirection*initialSpeed);

		dropsExpelled++;
	}

	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(transform.position, transform.position + (Vector3)outputDirection);
	}
}

