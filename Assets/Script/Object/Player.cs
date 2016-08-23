using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using DG.Tweening;

public class Player : MonoBehaviour {
	List<Vector3> path = new List<Vector3>();
	List<Vector3> rotate = new List<Vector3>();
	Vector3 currentPos;
	Vector3 currentRotate;
	Turn turn = Turn.RIGHT;

	void Start(){
		currentPos = transform.localPosition;
		GameManager.instance.player = this;
	}







	void Jump(Turn turn){

		if (this.turn == turn) {
			currentPos = new Vector3 (currentPos.x, currentPos.y, currentPos.z+1);
			currentRotate = new Vector3 (0, 0, 0);
			path.Add (currentPos);
			rotate.Add (currentRotate);
			Forward (path [0], rotate [0]);
		} else {

			if (turn == Turn.LEFT) {
				currentPos = new Vector3 (currentPos.x - 1, currentPos.y, currentPos.z);
				currentRotate = new Vector3 (0, -90, 0);
			} else if (turn == Turn.RIGHT) {
				currentPos = new Vector3 (currentPos.x + 1, currentPos.y, currentPos.z);
				currentRotate = new Vector3 (0, 90, 0);
			}
			this.turn = turn;
			path.Add (currentPos);
			rotate.Add (currentRotate);
			Move (path [0], rotate [0]);
		}
	}
	void Update(){
		/*if (CrossPlatformInputManager.GetButton ("Left")) {
			Debug.Log ("Left");
			Jump (Side.Left);
		}else if(CrossPlatformInputManager.GetButton ("Right")){
			Jump (Side.Right);
			Debug.Log ("Right");
		}*/
		if (Input.GetKeyDown (KeyCode.A)) {
			Jump (Turn.LEFT);
		} else if (Input.GetKeyDown (KeyCode.D)) {
			Jump (Turn.RIGHT);
		}

		if (CrossPlatformInputManager.GetButtonDown ("Left")) {
			Jump (Turn.LEFT);
		} else if (CrossPlatformInputManager.GetButtonDown ("Right")) {
			Jump (Turn.RIGHT);
		}
	}

	void Move(Vector3 pathWay,Vector3 rotateWay){
		transform.DOLocalJump (pathWay, 1, 1, 0.2f);
		transform.DORotate (rotateWay, 0);
		path.Remove (pathWay);
		rotate.Remove (rotateWay);
	}
	void Forward(Vector3 pathWay,Vector3 rotateWay){
		transform.DOLocalJump (pathWay, 1, 1, 0.2f);
		transform.DORotate (rotateWay, 0);
		path.Remove (pathWay);
		rotate.Remove (rotateWay);
		Events.instance.CallBrickDispatch ();
	}
}
