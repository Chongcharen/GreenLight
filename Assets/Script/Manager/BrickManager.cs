using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BrickManager : MonoBehaviour {
	public static BrickManager instance;
	[SerializeField]ObjectPool pool;
	[SerializeField]GameObject land;
	int jump = 0;
	GameObject brick;
	Vector3 currentPos = new Vector3(0,0,0);
	float up = 0;
	float currentUp = 0;
	Turn currentTurn = Turn.FORWARD;
	// สวิต brick อันที่แล้ว
	bool currentSwitch = false;

	[SerializeField]public List<GameObject> brickList = new List<GameObject>();
	public Vector3[] posList;
	int gap = 2;
	int wayCount = 0;
	int ladderCount = 0;

	int left = 0;
	int right = 1;

	// list design ของ switch
//	SwitchDesign levelDesign = new SwitchDesign();
	int[] switchSlot;
	int indexArray = 0;
	int limitIndex = 0;
	int delayShowSwitch = 0;

	public List<GameObject> leftBrick = new List<GameObject>();
	public List<GameObject> rightBrick = new List<GameObject>();
	public List<GameObject> handleBrick = new List<GameObject> ();
	GameObject targetBrick;
	int tick = 0;
	int speicalDelay = 0;
	bool currentCreateSpeical = false;
	bool prepareCreateSpeical = false;

	void Awake(){
		instance = this;
	}
	void Start(){
		Events.OnCallBrick += Events_OnCallBrick;
	}


	void OnPoolCreate(){
		//GenerateBrick (10,true,Turn.FORWARD);
	}
	void GenerateBrick(int numBrick,bool lockTurn ,Turn turn){
		for (int i = 0; i < numBrick; i++) {
			CreateBrick (lockTurn,turn,left);
		}
	}
	public static void AutoGenerate(){
		GameObject brick;
		for (int i = 0; i <10; i++) {
			brick = instance.CreateBrick (true, Turn.FORWARD,instance.left,false);
			brick = instance.CreateBrick (true, Turn.FORWARD,instance.right,false);
			instance.NextColumn ();
			instance.tick++;
		}
	}
	/*public void CreateBrick(bool lockTurn ,Turn turn){

		brick = pool.GetBrick ();
		brick.transform.SetParent (land.transform);

		if (!lockTurn) {
			if (wayCount <= 0) {
				wayCount = Random.Range (1, 10);
				ladderCount = Random.Range (0, wayCount-1);
				if (Random.Range (0, 100) > 50 && currentTurn != Turn.FORWARD) {
					currentTurn = Turn.FORWARD;
				}else if(currentTurn == Turn.FORWARD){
					currentTurn = (Turn)Random.Range (0, 3);
				}
				up = Random.Range (-1, 2);
				if (up > 0) {
					currentUp = up - 0.5f;
				} else if (up < 0) {
					currentUp = up + 0.5f;
				}
			}
			if (ladderCount > 0) {
				ladderCount--;
			} else {
				currentUp = 0;
			}
		}

		switch (currentTurn) {
		case Turn.FORWARD:
			brick.transform.position = new Vector3 (currentPos.x+gap, currentPos.y+currentUp,currentPos.z);
			break;
		case Turn.LEFT:
			brick.transform.position = new Vector3 (currentPos.x, currentPos.y+currentUp,currentPos.z+gap);
			break;
		case Turn.RIGHT:
			brick.transform.position = new Vector3 (currentPos.x, currentPos.y+currentUp,currentPos.z-gap);
			break;
		}
		if(lockTurn){
			currentTurn = turn;
		}else{
			wayCount--;
		}
		if (!lockTurn) {
			GenerateSwitch ();
		} else {
			currentSwitch = false;
		}


		currentPos = brick.transform.position;
		brick.GetComponent<Brick> ().turn = currentTurn;
		brick.GetComponent<Brick> ().currentPos = currentPos;
		brick.GetComponent<Brick> ().Show ();

		brickList.Add (brick);
	}*/
	 GameObject CreateBrick(bool lockTurn , Turn turn,int side,bool show = true){
		brick = pool.GetBrick ();
		brick.transform.SetParent (land.transform);

		switch (currentTurn) {
		case Turn.FORWARD:
			brick.transform.position = new Vector3 (currentPos.x+side, currentPos.y,currentPos.z);
			break;
		case Turn.LEFT:
			brick.transform.position = new Vector3 (currentPos.x+side, currentPos.y,currentPos.z);
			break;
		case Turn.RIGHT:
			brick.transform.position = new Vector3 (currentPos.x+side, currentPos.y,currentPos.z);
			break;
		}

		currentPos = brick.transform.position;
		brick.GetComponent<Brick> ().turn = turn;
		brick.GetComponent<Brick> ().currentPos = currentPos;
		brick.GetComponent<Brick> ().Show (show);
		brickList.Add (brick);
		if (side == 0) {
			/*if (leftBrick.Count >= 2) {
				leftBrick.RemoveAt (0);
			}*/
			leftBrick.Add (brick);
		} else {
			/*if (rightBrick.Count >= 2) {
				rightBrick.RemoveAt (0);
			}*/
			rightBrick.Add (brick);
		}

		return brick;
	}

	void GenerateSwitch(){
		// แบบสลับ
		/*if (!currentSwitch) {
			if (indexArray >= limitIndex) {
				//switchSlot = SwitchDesign.testDesign;
				if (delayShowSwitch <= 0) {
					switchSlot = levelDesign.GetLevel ();
					limitIndex = switchSlot.Length;
					indexArray = 0;
					delayShowSwitch = Random.Range (0, 5);
				} else {
					delayShowSwitch--;
				}
			} else {
				brick.GetComponent<Brick> ().SetSwitch ((SwitchColor)switchSlot[indexArray]);
				currentSwitch = true;
				indexArray++;
			}

		} else {
			brick.GetComponent<Brick> ().ShowItem ();
			currentSwitch = false;
		}*/
		/*if (indexArray >= limitIndex) {
			//switchSlot = SwitchDesign.testDesign;
			if (delayShowSwitch <= 0) {
				switchSlot = levelDesign.GetLevel ();
				limitIndex = switchSlot.Length;
				indexArray = 0;
				delayShowSwitch = Random.Range (0, 5);
			} else {
				delayShowSwitch--;
				brick.GetComponent<Brick> ().ShowItem ();
			}
		} else {
			brick.GetComponent<Brick> ().SetSwitch ((SwitchColor)switchSlot[indexArray]);
			indexArray++;
		}*/

	}
	public void RemoveBrick(){
		/*brickList [0].GetComponent<Brick> ().Hide(GameManager.instance.playerSpeed);
		//pool.Recycle (brickList [0]);
		brickList.Remove (brickList [0]);*/
		if (leftBrick.Count > 10) {
			leftBrick.RemoveAt (leftBrick.Count - 1);
		}
		if (rightBrick.Count > 10) {
			rightBrick.RemoveAt (leftBrick.Count - 1);
		}
		
	}
	public Vector3[] GetBrickArrayList(){
		posList = new Vector3[brickList.Count];
		int count = 0;
		foreach (GameObject obj in brickList) {
			posList [count] = obj.transform.position;
			count++;
		}
		return posList;
	}
	public Vector3[] waypoints(){
		posList = new Vector3[]{ new Vector3(brickList[0].transform.position.x,brickList[0].transform.position.y+0.75f,brickList[0].transform.position.z) };
		return posList;
	}
	void OnLevelUp(){
		//levelDesign.LevelUp ();
	}

	public void NextColumn(int next = 1){
		currentPos = new Vector3 (0, 0,currentPos.z+next);
		if (tick > 2) {
			if (Random.Range (0, 10) > 5) {

			}
		}
	}

	void Events_OnCallBrick ()
	{
		RemoveBrick ();
		if (!prepareCreateSpeical) {

			handleBrick.Clear ();	
			targetBrick = CreateBrick (true, Turn.FORWARD, instance.left);
			handleBrick.Add (targetBrick);
			targetBrick = CreateBrick (true, Turn.FORWARD, instance.right);
			handleBrick.Add (targetBrick);
			if (Random.Range (0, 100) > 10 || speicalDelay > 0) {
			
				if (currentCreateSpeical) {
					currentCreateSpeical = false;
				} else {
					ObstacleManager.instance.ReciveBrick (handleBrick);
				}
				
			} else {
				prepareCreateSpeical = true;
			}
			instance.NextColumn ();
			speicalDelay--;
		} else {
			prepareCreateSpeical = false;
			currentCreateSpeical = true;
			targetBrick = RandomSpeicalBrick ();
			ObstacleVariable variable = targetBrick.GetComponent<ObstacleVariable> (); 
			speicalDelay = Random.Range (variable.minDelay, variable.maxDelay);
			NextColumn (variable.nextBridge);
		}
	}
	GameObject CreateSpeicalBrick(){
		brick = pool.GetSpecialBrick ((int)SpecialBrick.Door);
		brick.transform.SetParent (land.transform);
		brick.transform.position = new Vector3(0,0,currentPos.z);
		return brick;
	}
	GameObject RandomSpeicalBrick(){
		brick = pool.GetSpecialBrick (Mathf.FloorToInt (Random.Range (0, pool.SpecialBrickCount)));
		brick.transform.SetParent (land.transform);
		brick.transform.position = new Vector3(0,0,currentPos.z);
		return brick;
	}
}
