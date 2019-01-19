using UnityEngine;
using UnityEngine.UI;

public class CashBoxManager : MonoBehaviour
{
	public Text CashField;

	// Update is called once per frame
	private void Update ()
	{
		CashField.text = "$ " + (int) Player.Default.Credits;
	}
}
