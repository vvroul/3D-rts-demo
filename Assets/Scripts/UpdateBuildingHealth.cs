using System.Collections;
using System.Collections.Generic;
using Interactions;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBuildingHealth : MonoBehaviour 
{
	[Header("Unity Stuff")] public Image HealthBar;

	private void Update()
	{
		HealthBar.fillAmount = gameObject.GetComponent<ShowUnitInfo>().CurrentHealth /
		                       gameObject.GetComponent<ShowUnitInfo>().MaxHealth;
		if (gameObject.GetComponent<ShowUnitInfo>().CurrentHealth <= 0) Destroy(gameObject);
	}
}
