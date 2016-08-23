using UnityEngine;
using System.Collections;

public class Events : MonoBehaviour {
	public static Events instance;
	public delegate void CallBrickEvent();
	public static event CallBrickEvent OnCallBrick;

	public delegate void CanCreateObstacleEvent();
	public static event CanCreateObstacleEvent CanCreateObstacle;

	public delegate void CallSideObstacleEvent(int side);
	public static event CallSideObstacleEvent CallSideObstacle;

	void Awake(){
		instance = this;
	}


	public void CallBrickDispatch(){
		OnCallBrick ();
	}

	public void CanCreateObstacleDispatch(){
		CanCreateObstacle ();
	}

	public void CallSideObstacleDispatch(int side){
		CallSideObstacle (side);
	}
}
public enum Turn{
	FORWARD,LEFT,RIGHT
}
public enum SpecialBrick{
	Roll = 0,Door=1
}