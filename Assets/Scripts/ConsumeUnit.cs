using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeUnit : MonoBehaviour {
	
	private List<GameObject> _workers = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (var p in RtsManager.Current.Players)
		{
			if (p.IsAi) continue;
			foreach (var u in p._activeUnits)
			{
				if (u.CompareTag("Worker"))
					_workers.Add(u);
			}

			if (p.Credits > 150)
			{
				Destroy(_workers[0]);
			}
		}
	}
}
