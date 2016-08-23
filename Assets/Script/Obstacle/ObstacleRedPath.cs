using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleRedPath : ObstacleMode {


	/*void SetRedPath(List<GameObject> bricks){
		int numBrick = 0;
		if (Random.Range (0, 100) > 50) {
			numBrick = 1;
		}
		bricks [numBrick].GetComponent<Brick> ().SetOpstacle ();
	}*/
	List<int> path = new List<int>();
	List<int> listPath = new List<int>();
	int indexPath = 0;


	int distance = -1;
	int currentDistance = 0;
	public override void GeneratePathObstacle ()
	{
		path.Clear ();
		distance = Random.Range (2, 5);
		currentDistance = 0;
		/*if (path.Count <= 0) {
			currentPath = Random.Range (0, 2);
			currentSide = currentPath;
			path.Add (currentPath);
			currentDistance++;
		}*/

		if (path.Count <= 0) {
			RegenerateListPath ();
			listPath.Remove (currentSide);
			currentPath = Utils.RandomBetween (listPath [0], listPath [1]);
			currentSide = currentPath;
			path.Add (currentPath);
			currentDistance++;
		}


		while (currentDistance < distance) {


			RegenerateListPath ();
			listPath.Remove (currentSide);  
			if (currentSide >= 0) {
				currentPath = -1;
				currentSide = -1;
			}else{
				
				currentPath = Random.Range (0, 2);
				currentSide = currentPath;
			}

			path.Add (currentPath);
			if (currentPath > -1) {
				currentDistance++;
			}



		}
		currentDistance = 0;
	}

	public override void SetObstacle (List<GameObject> bricks)
	{
		//base.SetObstacle (bricks);
		if (currentDistance < path.Count) {
			if (path [currentDistance] >= 0) {
				bricks [path [currentDistance]].GetComponent<Brick> ().SetObstacle ();
			}
		} else {
			Events.instance.CallSideObstacleDispatch (currentSide);
			Events.instance.CanCreateObstacleDispatch ();
		}
		currentDistance++;


	}
	void RegenerateListPath(){
		listPath.Clear ();
		listPath.Add (-1);
		listPath.Add (0);
		listPath.Add (1);
	}
}
