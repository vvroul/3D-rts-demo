using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class VisibilityManager : MonoBehaviour
{
    [FormerlySerializedAs("timeBetweenChecks")]
    public float TimeBetweenChecks = 1;

    [FormerlySerializedAs("visibleRange")] public float VisibleRange = 5;

    private float _waited = 10000;

    // Update is called once per frame
    private void Update()
    {
        _waited = Time.deltaTime;
        if (_waited <= TimeBetweenChecks)
            return;
        _waited = 0;
        var pBlips = new List<MapBlip>();
        var oBlips = new List<MapBlip>();

        foreach (var p in RtsManager.Current.Players)
        {
            foreach (var u in p.ActiveUnits)
            {
                var blip = u.GetComponent<MapBlip>();
                if (p == Player.Default) pBlips.Add(blip);
                else oBlips.Add(blip);
            }
        }

        foreach (var o in oBlips)
        {
            var active = false;
            foreach (var p in pBlips)
            {
                var distance = Vector3.Distance(o.transform.position, p.transform.position);
                if (!(distance <= VisibleRange)) continue;
                active = true;
                break;
            }

            o.Blip.SetActive(active);
            foreach (var r in o.GetComponentsInChildren<Renderer>())
                r.enabled = active;
        }
    }
}