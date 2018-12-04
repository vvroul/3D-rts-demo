using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements.StyleSheets;
using UnityEngine.UI;
using Image = UnityEngine.Experimental.UIElements.Image;

public class InfoManager : MonoBehaviour
{
	private static InfoManager _current;
	public UnityEngine.UI.Image ProfilePic;
	public Text Line1, Line2, Line3;

	public InfoManager()
	{
		_current = this;
	}

	public void SetLines(string line1, string line2, string line3)
	{
		Line1.text = line1;
		Line2.text = line2;
		Line3.text = line3;
	}

	public void ClearLines()
	{
		SetLines("", "", "");
	}

	public void SetPic(Sprite pic)
	{
		ProfilePic.sprite = pic;
		ProfilePic.color = Color.white;
	}

	public void ClearPic()
	{
		ProfilePic.color = Color.clear;
	}

	// Use this for initialization
	private void Start ()
	{
		ClearLines();
		ClearPic();
	}
}
