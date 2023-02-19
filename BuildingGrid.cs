using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGrid : MonoBehaviour
{
    //public Vector2Int GridSize = new Vector2Int(10, 10);
	public Camera mainCamera;
	public GameObject Player;
	public int buildinDistanse = 2;

	//private BuildPlatform[,] grid;
	private BuildPlatform flyingBuilding;
	

	//private void Awake()
	//{
	//	grid = new BuildPlatform[GridSize.x, GridSize.y];
	//}

	public void StartPlacingBuilding(BuildPlatform buildprefab)
	{
		if (flyingBuilding != null)
		{
			Destroy(flyingBuilding);
		}

		flyingBuilding = Instantiate(buildprefab);
	}

	private void Update()
	{
		int maxPositionX = Mathf.RoundToInt(Player.transform.position.x) + buildinDistanse;
		int maxPositionY = Mathf.RoundToInt(Player.transform.position.y) + buildinDistanse;
		int minPositionX = Mathf.RoundToInt(Player.transform.position.x) - buildinDistanse;
		int minPositionY = Mathf.RoundToInt(Player.transform.position.y) - buildinDistanse;
		if (flyingBuilding != null)
		{
			Vector2 cursor = Input.mousePosition;
			cursor = Camera.main.ScreenToWorldPoint(cursor);

			int x = Mathf.RoundToInt(cursor.x);
			int y = Mathf.RoundToInt(cursor.y);
			flyingBuilding.transform.position = new Vector2(x,y);

			bool avaliable = true;
			if (x > maxPositionX || x < minPositionX) avaliable = false;
			if (y > maxPositionY || y < minPositionY) avaliable = false;

			flyingBuilding.SetTransperent(avaliable);

			if (Input.GetMouseButtonDown(0) && avaliable)
			{
				flyingBuilding.SetNormal();
				flyingBuilding = null;
			}
			else if (Input.GetMouseButtonDown(1))
			{
				flyingBuilding.Clear();
				flyingBuilding = null;
				
			}
		}
	}
}
