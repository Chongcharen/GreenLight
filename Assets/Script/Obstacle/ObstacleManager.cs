using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ObstacleManager : MonoBehaviour {
	public static ObstacleManager instance;
	int tick = 0;
	int limitTick = 100;
	bool canCreateObstacle = false;
	int currentSide = -1;
	ObstacleMode obstacleMode;
	void Awake(){
		instance = this;
	}
	void Start(){
		Events.OnCallBrick += Events_OnCallBrick;
		Events.CanCreateObstacle += Events_CanCreateObstacle;
		Events.CallSideObstacle += Events_CallSideObstacle;
		RandomTick ();
	}

	void Events_CallSideObstacle (int side)
	{
		currentSide = side;
	}

	void Events_CanCreateObstacle ()
	{
		canCreateObstacle = false;
		tick = 0;
		RandomTick ();

	}

	void Events_OnCallBrick ()
	{
		tick++;
		if (tick >= limitTick && !canCreateObstacle) {
			canCreateObstacle = true;
			obstacleMode = new ObstacleRedPath ();
			obstacleMode.GetCurrentSide (currentSide);
			obstacleMode.GeneratePathObstacle ();
		}
	}
	void RandomTick(){
		limitTick = Random.Range (2, 5);
	}



	public void ReciveBrick(List<GameObject> bricks){
		/*if (canCreateObstacle)
			SetRedBrick (bricks[Random.Range(0,bricks.Count)]);
			canCreateObstacle = false;*/
		if (canCreateObstacle) {
			obstacleMode.SetObstacle (bricks);
		}
	}

	void SetRedBrick(GameObject brick){
		brick.GetComponent<Brick> ().SetObstacle ();
	}
		



}
