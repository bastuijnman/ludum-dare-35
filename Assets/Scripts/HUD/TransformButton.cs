using UnityEngine;
using System.IO;

public class TransformButton
{
	private Texture2D texture;

	private Texture2D textureNormal;
	private Texture2D textureFocus;

	public TransformButton (string name, int x, int y)
	{
		textureNormal = LoadTransformImage (name);
		textureFocus = LoadTransformImage (name + "-focus");

		texture = textureNormal;
		GUI.Button (new Rect (x, y, 100, 100), texture);

	}

	public void Focus () {
		texture = textureFocus;
	}

	public void Blur () {
		texture = textureNormal;
	}

	private Texture2D LoadTransformImage (string name) {
		Texture2D texture;
		byte[] file;

		file = File.ReadAllBytes ("Assets/Resources/HUD/" + name + ".png");
		texture = new Texture2D (100, 100);
		texture.LoadImage (file);

		return texture;

	}
}
