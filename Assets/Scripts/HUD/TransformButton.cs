using UnityEngine;

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

		name = "Assets/Resources/HUD/" + name + ".png";
		Texture2D texture = Utils.LoadImage (name, 100, 100);

		// There must be a better way to set the background stuff of the GUI, but fuck it for now
		Color origColor = GUI.backgroundColor;
		GUI.backgroundColor = Color.clear;

		GUI.Button (new Rect (x, y, 100, 100), texture);

		// Reset the original color
		GUI.backgroundColor = origColor;
	}
		
}
