using UnityEngine;
using System.Collections;

public class DungeonCamera : MonoBehaviour {
	public GameObject target;
	public float damping = 1;
	[SerializeField]Vector3 offset;
	Vector3 newTarget;
	void Start() {
		offset = transform.position - target.transform.position;
	}

	void LateUpdate() {
		Vector3 desiredPosition = target.transform.position + offset;
		//desiredPosition = new Vector3 (desiredPosition.x, Camera.main.transform.position.y, Camera.main.transform.position.;
		Vector3 newPos = new Vector3(desiredPosition.x,transform.position.y,desiredPosition.z);
		Vector3 position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * damping);
		transform.position = position;
		//newTarget = new Vector3 (target.transform.position.x,0,target.transform.position.z);
		//transform.LookAt(target.transform);
	}
}
