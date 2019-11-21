using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingDamage : MonoBehaviour
{
    public GameObject parent;

    public void DestroyPopup()
    {
        Destroy(parent);
    }

    public void SetText(string text)
    {
        GetComponent<Text>().text = text;
    }
}
