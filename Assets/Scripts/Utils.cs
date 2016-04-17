using UnityEngine;
using System.Collections;
using System.IO;

public static class Utils
{

	// Load an image and turn it into a texture
	public static Texture2D LoadImage (string filename, int width, int height) {
		
		Texture2D texture = new Texture2D (width, height);

		byte[] file;

		if (File.Exists (filename)) {
			file = File.ReadAllBytes (filename);
			texture.LoadImage (file);
		}

		return texture;

	}

}

