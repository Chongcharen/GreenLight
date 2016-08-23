using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class ObjectPool : MonoBehaviour {
	public static ObjectPool instance;
	[SerializeField]GameObject objectPool,objectPrefab,terrain;
	[SerializeField]List<GameObject> bricks;
	[SerializeField]List<GameObject> specialBricks; 
	[SerializeField]List<GameObject> specialObstacle;
	public int numPool = 60;
	public int numspecialBrick = 5;
	public int SpecialBrickCount{get{ return specialObstacle.Count;}}
	void Awake(){
		instance = this;
	}
	void Start(){
		CreateBricks ();
	}
	void CreateBricks(){
		GameObject go;
		for (int i = 0; i < numPool; i++) {
			go = Instantiate (objectPrefab);
			go.transform.SetParent (objectPool.transform);
			bricks.Add (go);
			go.SetActive (false);
		}


		for (int i = 0; i < specialObstacle.Count; i++) {
			for (int j = 0; j < numspecialBrick; j++) {
				go = Instantiate (specialObstacle[i]);
				go.transform.SetParent (objectPool.transform);
				specialBricks.Add (go);
				go.SetActive (false);
			}
		}
	}
	public GameObject GetBrick(){
		foreach(GameObject brick in bricks){
			if (!brick.activeSelf) {
				brick.SetActive (true);
				return brick;
			}
		}
		return null;
	}
	public GameObject GetSpecialBrick(int id){
		GameObject target = specialObstacle [id];
		foreach (GameObject brick in specialBricks) {
			if (!brick.activeSelf && brick.tag == target.tag) {
				brick.SetActive (true);
				return brick;
			}
		}
		return null;
	}
	public void Recycle(GameObject obj){
		obj.transform.SetParent (objectPool.transform);
		obj.SetActive (false);

	}
}
