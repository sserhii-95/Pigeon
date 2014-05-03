using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockManage : MonoBehaviour {

	private const float GridFactor = 3f;
	private Transform Root;
	private List<Vector3> cells = new List<Vector3>();
	public List<Vector3> Cells { get { return cells; } }

	// Use this for initialization
	void Start () {
		Root = GameObject.FindGameObjectWithTag ("Root").transform;
	}
	
	// Update is called once per frame
	void Update () {
		DecideToKill ();
	}

	public void PutBlock(Vector3 pos,GameObject obj) {
		obj = Instantiate (obj) as GameObject;
		obj.transform.parent = transform;
		obj.transform.localPosition = pos;
	}

	private void DecideToKill() {
		float z = transform.position.z - Root.position.z;
		if (Mathf.Abs(z) > renderer.bounds.size.z && z < 0)
			Destroy (gameObject);
	}

	private void GenerateGrid() {
		float cellSize = renderer.bounds.size.x / GridFactor;
		Vector3 pos = new Vector3 (-1, 1, -1);
		pos.x += cellSize/2f;
		pos.z += cellSize/2f;
		Vector3 curPos = pos;

		do {
			for (int i=0;i<GridFactor;++i) {
				cells.Add(curPos);
				curPos.x += cellSize;
			}
			curPos = pos;
			curPos.z += cellSize;
		} while (false);
	}
}
