using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static MouseManager Current;

    public MouseManager()
    {
        Current = this;
    }
    
    private readonly List<Interactive> _selections = new List<Interactive>();

    // Update is called once per frame
    private void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            return;
        }

        var es = UnityEngine.EventSystems.EventSystem.current;
        if (es != null && es.IsPointerOverGameObject())
        {
            return;
        }

        if (_selections.Count > 0)
        {
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            {
                foreach (var sel in _selections)
                {
                    if (sel != null)
                    {
                        sel.Deselect();
                    }
                }

                _selections.Clear();
            }
        }

        // ReSharper disable once Unity.InefficientCameraMainUsage
        if (Camera.main == null) return;
        // ReSharper disable once Unity.InefficientCameraMainUsage
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit))
        {
            return;
        }

        var interact = hit.transform.GetComponent<Interactive>();
        if (interact == null)
        {
            return;
        }

        _selections.Add(interact);
        interact.Select();
    }
}