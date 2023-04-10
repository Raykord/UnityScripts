using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SceneDataSaveLoad : MonoBehaviour //Класс для передачи функций на кнопки
{
	public GameObject goToSpawn;
	[SerializeField] private Transform _savingEnvironment;

	public void SaveScene()
	{
		BinarySavingSystem.SaveScene(_savingEnvironment); //Из клааса BinarySavingSystem вызываем метод SaveScene
	}

	public void LoadScene()
	{
		for (int i = 0; i < _savingEnvironment.childCount; i++) //Очищаем предыдущие сохранения
		{
			Destroy(_savingEnvironment.GetChild(i).gameObject);
		}
		SceneData data = BinarySavingSystem.LoadScene(); //Передаём в переменную data данные которые вернёт метод BinarySavingSystem.LoadScene()
		for (int i = 0; i < data.objectNames.Length; i++) //расставляем каждый обект из data по местам
		{

			var prefabName = GetPrefabName(data, i); //Получаем имя префаба

			//GameObject goToSpawn = Resources.Load<GameObject>($"ItemPrefabs/{prefabName}"); //Ищем префаб с таким названием в проекте я убрал, так как у меня всего один объект
			Vector3 spawnPosition = new Vector3(data.objectPosition[i].x, data.objectPosition[i].y, data.objectPosition[i].z); //Достаем координаты из data
			GameObject sceneObject = Instantiate(goToSpawn, spawnPosition, Quaternion.identity); //Ставим нужный префаб на его координаты

			sceneObject.transform.SetParent(_savingEnvironment); //Делаем дочерним объектом
		}
	}

	private static string GetPrefabName(SceneData data, int i) //Метод для получения имени префаба из data
	{
		string prefabName = "";
		if (data.objectNames[i].IndexOf(" ") > 0)
		{
			int whitespaceIndex = data.objectNames[i].IndexOf(" ");
			int length = data.objectNames[i].Length;
			prefabName = data.objectNames[i].Remove(whitespaceIndex, data.objectNames[i].Length - whitespaceIndex);
		}
		else
		{
			prefabName = data.objectNames[i];
		}

		return prefabName;
	}
}
