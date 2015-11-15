using UnityEngine;
using System.Collections;

public class ScoreHUD : MonoBehaviour {

    public float TiempoScore = 0;
    public GameObject textoScore, hardcoreButton;

	// Use this for initialization
	void Start ()
    {
        hardcoreButton = GameObject.Find("HardcoreButton");
    }
	
	// Update is called once per frame
	void Update ()
    {
        hardcoreButton = GameObject.Find("HardcoreButton");
        if (!hardcoreButton || !hardcoreButton.activeSelf)
        {
            TiempoScore += Time.deltaTime;
            textoScore.GetComponent<TextMesh>().text = TiempoScore.ToString("F2") + " m";
        }
    }
}
