using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoAway : MonoBehaviour
{
	private float dirrection = -1.0f;
	private void Update()
	{
		transform.Translate(0.1f * dirrection, 0, 0);
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		//if (collision.gameObject.tag == "ChancheDirrection")
		//{
			dirrection *= -1;
		//}
	}
}
