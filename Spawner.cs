using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject[] obj;
	private float spawnX;
	private Vector2 whereToSpawn;
	public float spawnRate = 2f;
	private float nextSpawn = 0.0f;
	int index;

	private void Start()
	{
		spawnX= transform.position.x;
	}

	private void Update()
	{
		if (Time.time > nextSpawn)
		{
			index = Random.Range(0, obj.Length);
			nextSpawn = Time.time + spawnRate;
			spawnX += Random.Range(3, 6f);

			whereToSpawn = new Vector2(spawnX, transform.position.y);
			Instantiate(obj[index], whereToSpawn, Quaternion.identity);
		}
	}
}
