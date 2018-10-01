using UnityEngine;
using System.Collections;

public class CountDisplay : MonoBehaviour {

	GUIText gui;

	// Use this for initialization
	void Start () {
	
		gui = GetComponent<GUIText> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		gui.text = "BOX Collected: " + BoxCollect.GetCount + "/" + OpenDoor.boxCount;
	}
}
