using UnityEngine;
using System.Collections;

public class BlockManage : MonoBehaviour {

	private Transform Root;

	// Use this for initialization
	void Start () {
		Root = GameObject.FindGameObjectWithTag ("Root").transform;
	}
	
	// Update is called once per frame
	void Update () {
		DecideToKill ();
	}

	private void DecideToKill() {
		float z = transform.position.z - Root.position.z;
		if (Mathf.Abs(z) > renderer.bounds.size.z && z < 0)
			Destroy (gameObject);
	}
}
