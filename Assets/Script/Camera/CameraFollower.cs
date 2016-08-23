using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

	public Transform target;
	public float distance;

	void Start(){
		distance = target.position.z - transform.position.z;

	}
	void Update(){

		this.transform.position = new Vector3 (transform.position.x, transform.position.y, target.position.z - distance);
	}

}
