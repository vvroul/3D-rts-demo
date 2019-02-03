using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static MouseManager Current;

    public MouseManager()
    {
        Current = this;
    }
    
    private readonly List<Interactive> _selections = new List<Interactive>();
    private GameObject[] _sameUnits = new GameObject[200];

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
            
            if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
            {
            
                foreach (var un in _sameUnits)
                {
                    if (un != null)
                    {
                        un.GetComponent<Interactive>().Deselect();
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
        
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            _sameUnits = GameObject.FindGameObjectsWithTag("Worker");
            foreach (var un in _sameUnits)
            {
                un.GetComponent<Interactive>().Select();
                _selections.Add(un.GetComponent<Interactive>());
            }
        }
        else
        { 
            _selections.Add(interact);
            interact.Select();
        }
        

    }
}