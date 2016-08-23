using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Utils : MonoBehaviour {
	public static List<GameObject> Shuffle (List<GameObject>aList)
	{  
		System.Random _random = new System.Random ();

		GameObject myGO;

		int n = aList.Count;
		for (int i = 0; i < n; i++)
		{
			// NextDouble returns a random number between 0 and 1.
			// ... It is equivalent to Math.random() in Java.
			int r = i + (int)(_random.NextDouble() * (n - i));
			myGO = aList[r];
			aList[r] = aList[i];
			aList[i] = myGO;
		}
		return aList;
	}
	public static int RandomBetween(int num1 , int num2){
		return (Random.Range (0, 100) > 50) ? num1 : num2;
	}
}
