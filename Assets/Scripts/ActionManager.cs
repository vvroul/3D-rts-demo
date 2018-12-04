using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.Experimental.UIElements.Image;

public class ActionManager : MonoBehaviour
{
    public static ActionManager Current;
    public Button[] Buttons;

    private readonly List<Action> _actionCalls = new List<Action>();

    public ActionManager()
    {
        Current = this;
    }

    public void ClearButtons()
    {
        foreach (var b in Buttons)
        {
            b.gameObject.SetActive(false);
        }

        _actionCalls.Clear();
    }

    public void AddButton(Sprite pic, Action onClick)
    {
        var index = _actionCalls.Count;
        Buttons[index].gameObject.SetActive(true);
        Buttons[index].GetComponent<UnityEngine.UI.Image>().sprite = pic;
        _actionCalls.Add(onClick);
    }

    public void OnButtonClick(int index)
    {
        _actionCalls[index]();
    }

    // Use this for initialization
    private void Start()
    {
        for (var i = 0; i < Buttons.Length; i++)
        {
            var index = i;
            Buttons[index].onClick.AddListener(delegate { OnButtonClick(index); });
        }

        ClearButtons();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}