using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    public void AttempToPlaceDefenderAt(Vector2 gridPos)
    {
        var sunDisplay = FindObjectOfType<SunDisplay>();
        var defenderCost = defender.GetSunCost();
        if (sunDisplay.HaveEnoughSuns(defenderCost))
        {
            SpawnDefender(gridPos);
            sunDisplay.SpendSuns(defenderCost);
        }
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    public Vector2 GetSquareClicked()
    {
        var clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        var gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        var newX = Mathf.RoundToInt(rawWorldPos.x);
        var newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void OnMouseDown()
    {
        var gridPos = GetSquareClicked();
        if (defender)
        {
            AttempToPlaceDefenderAt(gridPos);
        }
    }

    private void SpawnDefender(Vector2 gridPos)
    {
        Instantiate(defender, gridPos, Quaternion.identity);
    }
}
