using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar
{
    public float MaxValue { get; private set; }
    public float CurrentValue { get; private set; }
    public GameObject BarObject { get; private set; }

    readonly RectTransform rectBar;
    readonly float maxBarWidth;

    public Bar(float maxVal, GameObject barObj)
    {
        MaxValue = maxVal;
        BarObject = barObj;
        rectBar = BarObject.GetComponent<RectTransform>();
        CurrentValue = MaxValue;
        maxBarWidth = rectBar.rect.width;
    }

    public bool IsFull()
    {
        if (CurrentValue == MaxValue) return true;
        else return false;
    }

    public void Restart()
    {
        CurrentValue = MaxValue;
    }

    public void GiveValue(int amount)
    {
        if (CurrentValue >= 0 && CurrentValue <= MaxValue) CurrentValue += amount;
        if (CurrentValue < 0) CurrentValue = 0;
        if (CurrentValue > MaxValue) CurrentValue = MaxValue;

        rectBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, CurrentValue * maxBarWidth / MaxValue);
    }

    public void GiveValue(float amount)
    {
        if (CurrentValue >= 0 && CurrentValue <= MaxValue) CurrentValue += amount;
        if (CurrentValue < 0) CurrentValue = 0;
        if (CurrentValue > MaxValue) CurrentValue = MaxValue;

        rectBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, CurrentValue * maxBarWidth / MaxValue);
    }
}
