using UnityEngine;
using System.Collections;
using System.Timers;

public class HUD : MonoBehaviour {

	private string timerText = "";
	private int seconds = 0;
	private int focusIndex = 0;

	private Timer levelTimer;
	private Timer hideTransformOptions;

	private bool showTransformOptions = false;

	void Start () {

		// Start a new Timer to keep the level time
		levelTimer = new Timer ();
		levelTimer.Elapsed += new ElapsedEventHandler (OnTimerEvent);
		levelTimer.Interval = 1000;
		levelTimer.Start ();

		// Keep reference to the hide timer
		hideTransformOptions = new Timer ();
		hideTransformOptions.Interval = 5000;
		hideTransformOptions.Elapsed += new ElapsedEventHandler (OnHideTransformOptionsEvent);
	}

	// Handles creating the GUI elements
	void OnGUI () {

		// Create the timer label
		GUI.Label (new Rect (10, 10, 100, 20), timerText);

		// Show transform options when needed
		if (showTransformOptions) {
			
			// The whole .Create thing can be handled better via an own Configuration class in the constructor
			TransformButton but1 = new TransformButton { 
				name = "transformation", 
				x = CalculateTransformationLeft(0, 4), 
				y = 0, 
				focus = focusIndex == 0
			}; 
			but1.Create ();

			TransformButton but2 = new TransformButton { 
				name = "transformation", 
				x = CalculateTransformationLeft(1, 4), 
				y = 0, 
				focus = focusIndex == 1
			}; 
			but2.Create ();

			TransformButton but3 = new TransformButton { 
				name = "transformation", 
				x = CalculateTransformationLeft(2, 4), 
				y = 0, 
				focus = focusIndex == 2
			}; 
			but3.Create ();

			TransformButton but4 = new TransformButton { 
				name = "transformation", 
				x = CalculateTransformationLeft(3, 4), 
				y = 0, 
				focus = focusIndex == 3
			}; 
			but4.Create ();
		}
	}

	// Check if our shift key is displayed
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			OpenTransformOptions ();

			// Needs to change when ShapeManager is available
			focusIndex += 1;
			if (focusIndex > 3) {
				focusIndex = 0;
			}
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
