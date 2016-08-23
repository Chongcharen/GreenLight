using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
public class ObstacleRoll : SpecialObstacle {
	public List<GameObject> bricks = new List<GameObject>();

	int numRed = 0;
	void Start(){
		numRed = Random.Range (1, bricks.Count - 1);
		bricks = Utils.Shuffle (bricks);
		for(int i = 0; i < numRed ; i++){
			bricks[i].GetComponent<Brick>().SetObstacle();
		}
	}

}
