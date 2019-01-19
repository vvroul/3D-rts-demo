using Definitions;
using UnityEngine;

public class Earnings : MonoBehaviour
{
	public float CreditsPerSecond = 1;
	private PlayerSetupDefinition _player;

	// Use this for initialization
	private void Start ()
	{
		_player = GetComponent<Player>().Info;
	}
	
	// Update is called once per frame
	private void Update ()
	{
		_player.Credits += CreditsPerSecond * Time.deltaTime;
	}
}
