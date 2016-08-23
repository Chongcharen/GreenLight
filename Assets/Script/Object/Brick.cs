using UnityEngine;
using System.Collections;
using DG.Tweening;

/*public enum SwitchColor{
	RED = 0 , GREEN = 1 , BLUE = 2
}*/
public class Brick : MonoBehaviour {
	Material mat;
	int indexColor;
	[SerializeField]public Vector3 nextPosition,currentPos;
	[SerializeField]public Turn turn;
	[SerializeField]public GameObject redSwitch,blueSwitch,greenSwitch,gold,star;
	[SerializeField]bool openSwitch = false;
	bool isRed = false;
	//[SerializeField]SwitchColor switchColor;
	void Awake(){
		
	}
	void Start(){
		mat = GetComponent<MeshRenderer> ().material;
		//indexColor = Random.Range (0, 2);
		//ChangeColor ();

	}
	void ChangeColor(){
		/*switch (indexColor) {
		case 0:
			mat.color = Color.red;
			break;
		case 1:
			mat.color = Color.green;
			break;
		case 2:
			mat.color = Color.blue;
			break;
		}*/
	}
	public void Hide(float delay){
		openSwitch = false;
		GetComponent<BoxCollider> ().enabled = false;
//		transform.DOLocalMoveY (transform.position.y - 5, 0.2f).SetDelay(delay*2).OnComplete(ToRecycle);
		mat.DOFade (0, 0.2f).SetDelay(delay*2);
	//	mat.DOColor (new Color32 ((byte)mat.color.r,(byte)mat.color.g, (byte)mat.color.b, 0),1);
	}

	public void Show(bool born = false){
		if (born) {
			transform.DOLocalMoveY (-3, 0);
			transform.DOLocalMoveY (0, 0.2f);
		}
	}
	public Turn GetTurn(){
		return this.turn;
	}
/*	public void ShowItem(){
		if (Random.Range (0, 100) > 80) {
			gold.GetComponentInChildren<Gold> ().Show ();
		} else {
			if (Random.Range (0, 100) > 80 && !GameManager.instance.hasStar) {
				GameManager.instance.hasStar = true;
				star.GetComponentInChildren<Star> ().Show ();
			}
		}
	}
	void ShowSwitch(){
		if (!openSwitch)
			return;
			switch (switchColor) {
			case SwitchColor.Red:
				redSwitch.GetComponentInChildren<ObjectSwitch> ().Show ();
				break;
			case SwitchColor.Green:
				greenSwitch.GetComponentInChildren<ObjectSwitch> ().Show ();
				break;
			case SwitchColor.Blue:
				blueSwitch.GetComponentInChildren<ObjectSwitch> ().Show ();
				break;
			}
	}
	public void SetSwitch(SwitchColor color){
		switchColor = color;
		openSwitch = true;
	}
	void ToRecycle(){
		ObjectPool.instance.Recycle (this.gameObject);
	}
*/

	//123 321   12123   321

	void OnTriggerEnter(Collider other){
		if (other.tag == "Destroyer") {
			ObjectPool.instance.Recycle (this.gameObject);
			GetComponent<MeshRenderer> ().material = AssetManager.instance.dicMaterial [MaterialName.LIGHT_GREEN];
			isRed = false;
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			if (isRed) {
				Debug.Log ("RED HIT");
			}
		}
	}
	public void SetObstacle(){
		GetComponent<MeshRenderer> ().material = AssetManager.instance.dicMaterial [MaterialName.LIGHT_RED];
		isRed = true;
	}
}
