using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataSaveLoad : MonoBehaviour //Класс для передачи функций на кнопки
{
    [SerializeField] private CharacterController _characterController; //создаём объект класса CharacterController чтобы передать его данные в функцию

	public void SavePlayer()
    {
        BinarySavingSystem.SavePlayer(_characterController); //Передаём объект в функцию SavePlayer из скрипта BinarySavingSystem
	}

	public void LoadPlayer()
	{
		PlayerData data = BinarySavingSystem.LoadPlayer(); //Вызываем функицю LoadPlayer из класса BinarySavingSystem чтобы она передала данные в переменную data
		_characterController.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
	}
}
