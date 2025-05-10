using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScheduleClickHandler : MonoBehaviour
{
    public Image buttonBackground;

    public void ScheduleButtonHandler()
    {
        Color selectedColor = new Color(0.3548f, 0.1637f, 8113f, 1f);
        Color unselectedColor = new Color(0.937255f, 0.937255f, 0.937255f, 1f);
        if (buttonBackground.color == selectedColor)
        {
            buttonBackground.color = unselectedColor;
        }
        else
        {
            buttonBackground.color = selectedColor;
        }
    }
}
