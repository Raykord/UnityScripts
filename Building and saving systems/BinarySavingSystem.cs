using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class BinarySavingSystem 
{
    public static void SavePlayer(CharacterController player)
    {
        BinaryFormatter formatter = new BinaryFormatter(); //Открываем кодировщик
        string path = Application.persistentDataPath + "/player.b"; //Открывает путь к месту хранения 
        FileStream stream = new FileStream(path, FileMode.Create); //Открываем поток данных по указанному пути
        PlayerData data = new PlayerData(player); //Создаем объект с данными игрока
        formatter.Serialize(stream, data); //Сериализуем данные игрока в папку
        stream.Close(); //Закрываем поток
    }
	public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.b"; //Находим путь
        if (File.Exists(path)) //Если файл существует
        {
            BinaryFormatter formatter = new BinaryFormatter(); //Отерываем кодировщик
            FileStream stream = new FileStream(path, FileMode.Open); //Открываем поток
            PlayerData data = (PlayerData)formatter.Deserialize(stream); //Загружаем данные
            stream.Close(); //Закрываем поток
            return data; //Возвращаем данные
        }
        else
        {
            Debug.LogError("Save file not foudn in " + path);
            return null;
        }
    }

	public static void SaveScene(Transform parentObject)
	{
		BinaryFormatter formatter = new BinaryFormatter(); //Открываем кодировщик
		string path = Application.persistentDataPath + "/scene.b"; //Открывает путь к месту хранения 
		FileStream stream = new FileStream(path, FileMode.Create); //Открываем поток данных по указанному пути
		SceneData data = new SceneData(parentObject); //Создаем объект с данными родительского объекта
		formatter.Serialize(stream, data); //Сериализуем данные игрока в папку
		stream.Close(); //Закрываем поток
	}

	public static SceneData LoadScene()
	{
		string path = Application.persistentDataPath + "/scene.b";
		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			SceneData data = formatter.Deserialize(stream) as SceneData;
			stream.Close();

			return data;
		}
		else
		{
			Debug.LogError("Save file not found in " + path);
			return null;
		}
	}

}
