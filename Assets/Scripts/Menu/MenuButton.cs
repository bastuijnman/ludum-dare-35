using UnityEngine;

public class MenuButton
{

	public int y { get; set; }
	public string text { get; set; }
	public Font textFont { get; set; }
	public System.Func<bool> callback { get; set; }

	public void Create () {
		Texture2D texture = (Texture2D)Resources.Load ("Images/menu-button");

		// There must be a better way to set the background stuff of the GUI, but fuck it for now
		Color origColor = GUI.backgroundColor;
		GUI.backgroundColor = Color.clear;

		if (GUI.Button (new Rect ((Screen.width - 307) / 2, y, 307, 100), texture)) {
			callback.Invoke ();
		}

		GUI.Label (new Rect ((Screen.width - 307) / 2, y, 307, 100), text, new GUIStyle {
			font = textFont,
			fontSize = 30,
			alignment = TextAnchor.MiddleCenter
		});

		// Reset the original color
		GUI.backgroundColor = origColor;
	}

}