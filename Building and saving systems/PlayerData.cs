using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position; //массив для координат

    public PlayerData(CharacterController player) //Конструктор класска который сохраняет в массив позицию игрока по xyz
    {
        position = new float[3];
        var playerPosition = player.transform.position;
        position[0] = playerPosition.x;
        position[1] = playerPosition.y;
        position[2] = playerPosition.z;
    }
}
