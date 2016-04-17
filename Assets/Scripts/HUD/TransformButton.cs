using UnityEngine;
using System.IO;

public class TransformButton
{

	public int x { get; set; }
	public int y { get; set; }
	public bool focus { get; set; }
	public string name { get; set; }

	// Actually creates the GUI button
	public void Create ()
	{
		if (focus) {
			name = name + "-focus";
		}

		Texture2D texture = LoadTransformImage (name);

		// There must be a better way to set the background stuff of the GUI, but fuck it for now
		Color origColor = GUI.backgroundColor;
		GUI.backgroundColor = Color.clear;

		GUI.Button (new Rect (x, y, 100, 100), texture);

		// Reset the original color
		GUI.backgroundColor = origColor;
	}

	// Load an image and turn it into a texture
	private Texture2D LoadTransformImage (string filename) {
		
		string path = "Assets/Resources/HUD/" + filename + ".png";
		Texture2D texture = new Texture2D (100, 100);

		byte[] file;

		if (File.Exists (path)) {
			file = File.ReadAllBytes (path);
			texture.LoadImage (file);
			texture.name = name;
		}

		return texture;

	}
}
