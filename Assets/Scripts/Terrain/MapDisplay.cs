using UnityEngine;
using System.Collections;

public class MapDisplay : MonoBehaviour 
{

	public Renderer textureRender;

	public void DrawTexture(Texture2D texture) 
	{

		textureRender.sharedMaterial.mainTexture = texture;
		textureRender.transform.localScale = new Vector3(texture.width, texture.height, 1);

	}
	
}