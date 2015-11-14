using UnityEngine;
using System.Collections;

public class MoveBackground : MonoBehaviour {

	public float scrollSpeed;
  private Vector2 savedOffset;
  public Texture textura;

  void Start() {
    savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
    //GetComponent<Renderer>().material.mainTexture = textura;
  }

  void Update() {
    float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
    Vector2 offset = new Vector2(x, savedOffset.y);
    GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
  }

  void OnDisable()  {
      GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
  }
}
