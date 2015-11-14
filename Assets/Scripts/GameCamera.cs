using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

	private Transform player;
	public float smoothing = 3f;
	private Vector3 lu;

		void Start () {
			player = GameObject.Find ("lu").transform;
		}

   void FixedUpdate() {
       if (player) {
           var playerPos = player.position;
           Vector3 trackPos = new Vector3(transform.position.x, playerPos.y, -10);

                lu = Vector3.Lerp(transform.position, trackPos, smoothing * Time.deltaTime);
								if (lu.x > 32f) {
									lu.x = 32f;
								}
								if (lu.x < -32f) {
									lu.x = -32f;
								}
								if (lu.y > 20f) {
									lu.y = 20f;
								}
								if (lu.y < -20f) {
									lu.y = -20f;
								}
								transform.position = lu;
       }
   }


}
