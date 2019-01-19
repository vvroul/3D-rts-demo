using UnityEngine;

public class CameraCradle : MonoBehaviour
{

	public float Speed = 20;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (
			Input.GetAxis ("Horizontal") * Speed * Time.deltaTime,
            Input.GetAxis("Vertical") * Speed * Time.deltaTime,
           0);

	}
}
