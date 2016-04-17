using UnityEngine;

public class TransformButton
{

	public int x { get; set; }
	public int y { get; set; }
	public bool focus { get; set; }
	public string name { get; set; }
	public Sprite sprite { get; set; }

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

		Texture spriteTexture = sprite.texture;
		Rect spriteRect = sprite.textureRect;
		Rect drawRect = new Rect(
			spriteRect.x / spriteTexture.width, 
			spriteRect.y / spriteTexture.height, 
			spriteRect.width / spriteTexture.width, 
			spriteRect.height / spriteTexture.height 
		);

		float ratio = spriteRect.width / spriteRect.height;
		float targetWidth = 70;
		float targetHeight = 70;

		if (ratio < 1) {
			targetWidth = targetWidth * ratio;
		} else {
			targetHeight = targetWidth / ratio;
		}

		GUI.DrawTextureWithTexCoords(new Rect(x + 15 + ((70 - targetWidth) / 2), y + 15, targetWidth, targetHeight), spriteTexture, drawRect);

		// Reset the original color
		GUI.backgroundColor = origColor;
	}
		
}
