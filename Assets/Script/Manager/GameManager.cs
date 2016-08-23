using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public float playerSpeed = 0.35f;
	public float currentSpeed = 0.35f;
	public float minSpeed = 0.1f;
	public float maxSpeed = 0.35f;
	public bool gameStart = false;
	public bool hasStar = false;
	public int _score = 0;
	public int level = 0;
	public Player player;
	public int score{
		get{ return _score;}
		set{ 
			_score = value;
			if (_score % 20 == 0 && _score != 0) {
				LevelUp ();
			}
		}
	}

	void Awake(){
		instance = this;
	}
	public void GameStart(bool isStart){
		gameStart = isStart;
		GameObject.Find ("Player").SendMessage ("OnGameStart");
	}
	public void GameOver(){
		gameStart = false;
	}
	void DumpSpeed(){
		currentSpeed -= 0.01f;
		playerSpeed = currentSpeed;
	}
	void LevelUp(){
		level++;
		if (level % 2 == 0 & playerSpeed > 0.25f) {
			DumpSpeed ();
		}
	}

	///speed 2.5 กำลังตึงมือเลย
}
