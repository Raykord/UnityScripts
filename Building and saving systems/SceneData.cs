using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

[System.Serializable]
public class SceneData
{
	public AlternativeVector3[] objectPosition; //Массив объектов класса AlternativeVector3 для сохранения координат
	public string[] objectNames; //Массив строк для сохранения названий сохраняемых префабов
	public SceneData(Transform parentTransform) //Консруктор класса SceneData получающий на вход родительский объект, дочерние объекты которого будут сохраняться
	{
		var childCount = parentTransform.childCount; //Считаем сколько у parentTransform дочерних объектов
		objectPosition = new AlternativeVector3[childCount]; //Выделяем память под массив, в зависсимости от колличества дочерних объектов
		objectNames = new string[childCount]; //Выделяем память под массив, в зависсимости от колличества дочерних объектов

		for (int i = 0; i < parentTransform.childCount; i++) //Проходимся по дочерним объектам и заполняем их координатами массив векторов
		{
			Transform currentObject = parentTransform.GetChild(i);

			objectNames[i] = currentObject.name;

			var position = currentObject.position;
			objectPosition[i] = new AlternativeVector3(position.x, position.y, position.z);

		}
	}

	[System.Serializable]
	public class AlternativeVector3 //Класс для сохранения координат
	{
		public float x;
		public float y;
		public float z;

		public AlternativeVector3(float x, float y, float z) //Конструктор класса, чтобы передавать данные в поля класса при создании объекта
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
	}
}
