using UnityEngine;
using System.Collections;
using System.Timers;

public class HUD : MonoBehaviour {

	private string timerText = "";
	private int seconds = 0;
	private Timer levelTimer;

	void Start () {

		// Start a new Timer to keep the level time
		levelTimer = new Timer ();
		levelTimer.Elapsed += new ElapsedEventHandler (OnTimerEvent);
		levelTimer.Interval = 1000;
		levelTimer.Start ();
	}

	// Handles creating the GUI elements
	void OnGUI () {

		// Create the timer label
		GUI.Label (new Rect (10, 10, 100, 20), timerText);
	}

	// Called when the Scene is destroyed
	void OnDestroy () {
		levelTimer.Stop ();
		levelTimer.Dispose ();
	}

	void OnTimerEvent (object source, ElapsedEventArgs e) {
		seconds += 1;
		timerText = seconds.ToString ();
	}
}
