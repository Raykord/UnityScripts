using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
	public float Speed = 0.01f; // Скорость камеры
	public Transform Camera; // Для хранения объекта камеры
	public Transform Player; // Для хранения объекта игрока

	private void FixedUpdate()
	{
		var cameraPosition = Camera.position; // Передаём позицию камеры
		cameraPosition.x = Mathf.Lerp(cameraPosition.x, Player.position.x, Speed); // Меняем позицию по x
		cameraPosition.y = Mathf.Lerp(cameraPosition.y, Player.position.y, Speed); // Меняем позицию по y

		Camera.position = cameraPosition; // Обновляем позицию камеры
	}
}
