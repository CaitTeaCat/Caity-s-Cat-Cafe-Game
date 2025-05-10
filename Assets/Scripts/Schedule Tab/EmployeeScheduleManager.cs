using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using GamePlay.ScheduleTab;

public class EmployeeScheduleManager : MonoBehaviour
{
    public Button saveButton;
    public List<Transform> scheduleButtons;
    public string[,] shift;

    private int dayOfWeek;
    private TMP_Dropdown ddDay;

    // Start is called before the first frame update
    void Start()
    {
        saveButton = GameObject.Find("btnSave").GetComponent<Button>();
        saveButton.onClick.AddListener(SaveButtonHandler);
        shift = new string[2, 10]; // 2 rows, 10 columns. First row is label name, second row is scheduling.

        ddDay = GameObject.Find("ddDay").GetComponent<TMP_Dropdown>();
        dayOfWeek = ddDay.value;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Sets the schedule of an employee
    public void SaveButtonHandler()
    {
        scheduleButtons.Clear();
        foreach (Transform child in transform)
        {
            scheduleButtons.Add(child);
        }

        Image buttonImage = null;
        int i = 0;
        foreach (Transform button in scheduleButtons)
        {
            buttonImage = button.gameObject.transform.GetChild(0).GetComponent<Image>();

            // Adds name to array
            shift[0, i] = buttonImage.name;

            // Adds employee's scheduling status
            if (buttonImage.color == new Color(0.3548f, 0.1637f, 8113f, 1f))
            {
                shift[1, i] = "Scheduled";
            }
            else
            {
                shift[1, i] = "Not scheduled";
            }
            i++;
        }

        // Checks if schedule is valid (no gap between scheduled times).
        bool scheduled = false;
        bool valid = true;
        for (i = 0; i < (shift.Length / 2); i++)
        {
            if (i > 0)
            {
                if (shift[1, i] == "Scheduled" && shift[1, i - 1] != "Scheduled" && scheduled == true)
                {
                    valid = false;
                }
            }

            if (scheduled == false && shift[1, i] == "Scheduled")
            {
                scheduled = true;
            }
        }

        if (valid == false)
        {
            Debug.Log("Schedule is invalid");
        }
        else
        {
            Debug.Log("Schedule is valid");
            dayOfWeek = ddDay.value;
            Shift shift = new Shift(dayOfWeek, this.shift);
        }

        clearTable();
    }

    public void clearTable()
    {
        Image buttonImage = null;
        Color scheduledColor = new Color(0.6509804f, 0.8431373f, 0.9843137f, 1f);
        Color unselectedColor = new Color(0.937255f, 0.937255f, 0.937255f, 1f);

        foreach (Transform button in scheduleButtons)
        {
            buttonImage = button.gameObject.transform.GetChild(0).GetComponent<Image>();
            if (buttonImage.color == new Color(0.3548f, 0.1637f, 8113f, 1f))
            {
                buttonImage.color = scheduledColor;
            }
            else
            {
                buttonImage.color = unselectedColor;
            }
            
        }
    }
}


