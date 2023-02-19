
using UnityEngine;

public class BuildPlatform : MonoBehaviour
{
    //public Vector2Int Size = Vector2Int.one;
	public SpriteRenderer MainRenderer;


	private void Awake()
	{
		MainRenderer= GetComponent<SpriteRenderer>();
		GetComponent<BoxCollider2D>().enabled = false;
	}
	public void SetTransperent(bool aveliable)
	{
		if (aveliable)
		{
			MainRenderer.color = Color.green;
		}
		else
		{
			MainRenderer.color = Color.red;
		}
	}
	
	public void SetNormal()
	{
		GetComponent<BoxCollider2D>().enabled = true;
		MainRenderer.color = Color.white;
		
	}

	public void Clear()
	{
		Destroy(this.gameObject);
	}

}
