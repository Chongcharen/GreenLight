using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleMode{
	public int currentSide = -1;
	public int currentPath = -1;
	public virtual void SetObstacle (List<GameObject> bricks){

	}
	public virtual void GeneratePathObstacle (){

	}
	public void GetCurrentSide(int side){
		currentSide = side;
	}
}
