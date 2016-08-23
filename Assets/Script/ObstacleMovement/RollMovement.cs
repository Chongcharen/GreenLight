using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class RollMovement : MonoBehaviour {
	Transform currentTransform;
	Vector3 thispos;
	List<Vector3> posList = new List<Vector3>();
	Vector3[] posArray;
	public int index = 0;
	void Awake(){
		currentTransform = transform;
		thispos = currentTransform.position;
		posList.Add (new Vector3 (2, 2,0));
		posList.Add (new Vector3 (0, 4,0));
		posList.Add (new Vector3 (-2, 2,0));
		posList.Add (new Vector3 (0, 0,0));
		posArray = posList.ToArray ();
	}
	void OnEnable(){
		currentTransform.DOKill ();
		thispos = transform.position;
		//StartCoroutine ("GoMove");
		TuneMove();
	}
	void Disable(){
		currentTransform.DOKill ();
	}
	IEnumerator GoMove(){
		yield return new WaitForSeconds (1);
		Move ();
	}
	void Move(){
		//currentTransform.DOMove (new Vector3 (currentTransform.position.x + 2, currentTransform.position.y, currentTransform.position.z),1);
		//currentTransform.DOPath (posArray, 10);
		Vector3 newmove = new Vector3(posList[index].x,posList[index].y,posList[index].z);
		currentTransform.DOLocalMove(newmove,1).SetDelay(1).OnUpdate(CheckPlayerStandRoll).OnComplete(OnMoveComplete);
	}
	void CheckPlayerStandRoll(){
		
		if(GameManager.instance.player.transform.position.z == transform.position.z){
			Debug.Log("stand in roll");
		}
	}
	void TuneMove(){
		Vector3 newmove = new Vector3(posList[index].x,posList[index].y,posList[index].z);
		currentTransform.DOLocalMove(newmove,0).OnComplete(OnMoveComplete);
	}
	void OnMoveComplete(){
		if (index >= posList.Count - 1) {
			index = 0;
		} else {
			index++;
		}
		Move ();
	}
	void GetPlayerTrigger(){
		Debug.Log ("Player in trigger");
	}
}
