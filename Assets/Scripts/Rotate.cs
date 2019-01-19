using UnityEngine;
using UnityEngine.Serialization;

public class Rotate : MonoBehaviour {

    [FormerlySerializedAs("rotation")] public Vector3 Rotation = Vector3.zero;
	
	// Update is called once per frame
	private void Update ()
    {
        transform.Rotate(Rotation * Time.deltaTime);	
	}
}
