using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunDisplay : MonoBehaviour
{
    [SerializeField] int suns = 0;
    Text sunText;

    // Start is called before the first frame update
    void Start()
    {
        sunText = GetComponent<Text>();
        UpdateDisplay();
    }

    public bool HaveEnoughSuns(int amount)
    {
        return suns >= amount;
    }

    private void UpdateDisplay()
    {
        sunText.text = suns.ToString();
    }

    public void AddSuns(int amount)
    {
        suns += amount;
        UpdateDisplay();
    }

    public void SpendSuns(int amount)
    {
        if (suns >= amount)
        {
            suns -= amount;
            UpdateDisplay();
        }
    }
}
