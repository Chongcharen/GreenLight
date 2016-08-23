using UnityEngine;
using System.Collections;
using DG.Tweening;
public class SpecialObstacle : MonoBehaviour {

	void OnEnable(){
		Show (true);
	}

	public void Show(bool born = false){
		if (born) {
			transform.DOLocalMoveY (-3, 0);
			transform.DOLocalMoveY (0, 0.2f);
		}
	}
}
