using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AssetManager : MonoBehaviour {
	public static AssetManager instance;
	public Dictionary<string,Material> dicMaterial = new Dictionary<string, Material>();
	void Awake(){
		instance = this;
		LoadAsset ();
	}



	void LoadAsset(){
		Material[] mats = Resources.LoadAll <Material>("Material");
		for (int i = 0; i < mats.Length; i++) {
			dicMaterial.Add (mats [i].name, mats [i]);
		}
	}
}

public class MaterialName{
	public const string LIGHT_GREEN = "lightGreen";
	public const string LIGHT_RED = "lightRed";
}
