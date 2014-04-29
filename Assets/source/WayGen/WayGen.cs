using UnityEngine;
using System.Collections;

public class WayGen : MonoBehaviour {

	public float Horizon;
	private float Edge;
	public float GridSize;
	public float WaySpeed;
	public Vector3 WayShift;

	public GameObject WayBlock; 
	private GameObject LastBlock;
	private GameObject Parent;

	// Use this for initialization
	void Start () {
		Edge = gameObject.transform.position.z + Horizon;
		Parent = new GameObject ();
		Parent.transform.position = transform.position;

		FirstGenerate ();
	}
	
	// Update is called once per frame
	void Update () {
		Parent.transform.Translate(new Vector3(0,0,-WaySpeed*Time.deltaTime));
		Generate ();
	}

	private void Generate() {
		if ((LastBlock.renderer.bounds.extents.z + LastBlock.transform.position.z) < Edge) {
			LastBlock = GenBlockDefault();
		}
	}

	private void FirstGenerate() {
		LastBlock = GenBlockParams(transform.position);
		Vector3 pos = Vector3.zero;

		do 
		{
			pos += LastBlock.transform.position + new Vector3 (0, 0, LastBlock.renderer.bounds.extents.z);
			GameObject go = GenerateBlock();
			pos.z += go.renderer.bounds.extents.z;
			go.transform.position = pos;
		} while (pos.z < Horizon);

	}

	private GameObject GenerateBlock() {
		GameObject go = GameObject.Instantiate (WayBlock) as GameObject;
		go.transform.parent = Parent.transform;
		go.AddComponent<BlockManage> ();
		go.transform.rotation = transform.rotation;

		return go;
	}

	private GameObject GenBlockDefault() {
		GameObject go = GenerateBlock ();
		Vector3 pos = LastBlock.transform.position + new Vector3 (0, 0, LastBlock.renderer.bounds.extents.z + go.renderer.bounds.extents.z);
		go.transform.position = pos;

		return go;
	}

	private GameObject GenBlockParams(Vector3 position) {
		GameObject go = GenerateBlock ();
		go.transform.position = position;

		return go;
	}
}
