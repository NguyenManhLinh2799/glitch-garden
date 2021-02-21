using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    Text costText;

    private void Start()
    {
        costText = GetComponentInChildren<Text>();
        if (costText)
        {
            costText.text = defenderPrefab.GetSunCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (var button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(80, 80, 80, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
