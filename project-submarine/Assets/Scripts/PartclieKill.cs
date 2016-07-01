using UnityEngine;
using System.Collections;

public class PartcileKill : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Invoke ("Kill",2f);
	}

	void Kill()
	{
		Destroy (gameObject);
	}
}