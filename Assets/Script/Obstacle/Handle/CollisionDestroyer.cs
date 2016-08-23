using UnityEngine;
using System.Collections;

public class CollisionDestroyer : MonoBehaviour {
	void OnTriggerEnter(Collider other){
		if (other.tag == "Destroyer") {
			ObjectPool.instance.Recycle (this.gameObject);
		}
	}
}
