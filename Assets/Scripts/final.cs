using UnityEngine;
using System.Collections;

public class final : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("fin", 4);
	}

	// Update is called once per frame
	void fin () {
		Application.LoadLevel("Menu");
	}
}
