using UnityEngine;
using UnityEngine.UI;

public class MapBlip : MonoBehaviour
{
	public GameObject Blip { get; private set; }

	// Use this for initialization
	private void Start ()
	{
		Blip = Instantiate(Map.Current.BlipPrefab);
		Blip.transform.SetParent(Map.Current.transform);
		var color = GetComponent<Player>().Info.AccentColor;
		Blip.GetComponent<Image>().color = color;
	}
	
	// Update is called once per frame
	private void Update ()
	{
		Blip.transform.position = Map.Current.WorldPositionToMap(transform.position);
	}

	private void OnDestroy()
	{
		Destroy(Blip);
	}
}