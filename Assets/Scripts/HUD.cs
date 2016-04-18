using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Timers;

public class HUD : MonoBehaviour {

	private string timerText = "";
	private int seconds = 0;
	private int focusIndex = 0;

	private Timer levelTimer;
	private Timer hideTransformOptions;

	ShapeManager shapeManager;

	private bool showTransformOptions = false;

	void Start () {

		// Start a new Timer to keep the level time
		levelTimer = new Timer ();
		levelTimer.Elapsed += new ElapsedEventHandler (OnTimerEvent);
		levelTimer.Interval = 1000;
		levelTimer.Start ();

		// Keep reference to the hide timer
		hideTransformOptions = new Timer ();
		hideTransformOptions.Interval = 2000;
		hideTransformOptions.Elapsed += new ElapsedEventHandler (OnHideTransformOptionsEvent);

        shapeManager = new ShapeManager ();
    }

	// Handles creating the GUI elements
	void OnGUI () {

		// Create the timer label
		GUI.Label (new Rect (10, 10, 100, 20), timerText);

		// Show transform options when needed
		if (showTransformOptions) {
			
			List<string> shapes = shapeManager.GetUnlockedShapes ();
			int idx = 0;

			shapes.ForEach (delegate (string name) {
				TransformButton but = new TransformButton {
					name = "transformation",
					x = CalculateTransformationLeft(idx, shapes.Count),
					y = 0,
					focus = focusIndex == idx,
					sprite = shapeManager.GetSpriteByName(name),
					spriteName = name
				};
				but.Create();

				idx++;
			});
		}
	}

	// Check if our shift key is displayed
	void Update () {
        if (showTransformOptions)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
		if (Input.GetKeyDown(KeyCode.LeftShift)) {


            // Needs to change when ShapeManager is available
            focusIndex += 1;
			if (focusIndex == shapeManager.GetUnlockedShapes ().Count) {
				focusIndex = 0;
			}

			OpenTransformOptions ();
		}
	}

	// Called when the Scene is destroyed
	void OnDestroy () {
		levelTimer.Stop ();
		levelTimer.Dispose ();
	}

	// Adds a second to the level timer every interval step
	void OnTimerEvent (object source, ElapsedEventArgs e) {
		seconds += 1;
		timerText = seconds.ToString ();
	}

	// Hides the transform options when the timer has elapsed
	void OnHideTransformOptionsEvent (object source, ElapsedEventArgs e) {
		showTransformOptions = false;
		hideTransformOptions.Stop();
	}

	// Open the transform options and start the timer
	private void OpenTransformOptions () {
		showTransformOptions = true;

		if (hideTransformOptions.Enabled) {
			hideTransformOptions.Stop ();
		}
		hideTransformOptions.Start ();
	}

	// Calculate what the left position of the transformation button should be
	private int CalculateTransformationLeft (int index, int count) {
		int totalWidth = (count * 110) - 10;
		int offset = (Screen.width - totalWidth) / 2;

		return offset + (index * 110);
	}
}
