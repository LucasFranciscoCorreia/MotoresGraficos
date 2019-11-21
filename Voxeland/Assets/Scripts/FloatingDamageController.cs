using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingDamageController : MonoBehaviour
{
    public GameObject popup;
    public Canvas canvas;

    public void CreateFloatingDamage(string damage, Transform location)
    {
        GameObject popup = Instantiate(this.popup, canvas.transform, false);
        popup.GetComponentInChildren<FloatingDamage>().SetText(damage);
        Vector2 screenpos = Camera.main.WorldToScreenPoint(location.position);
        popup.transform.position = screenpos;

    }
}
