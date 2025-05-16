using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamePlay.ScheduleTab;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;

public class ScheduleManager : MonoBehaviour
{
    private int weekNum;
    private int dayOfWeek;
    private List<Employee> employees;

    public Transform txtHead;
    public Text txtName;
    public Transform schedulePane;
    public GameObject employeeColumn;

    private TMP_Dropdown ddDay;

    public ScheduleManager()
    {
        weekNum = 0;
        dayOfWeek = 0;
        employees = new List<Employee>();
    }

    public ScheduleManager(int week, int day)
    {
        weekNum = week;
        dayOfWeek = day;
        employees = new List<Employee>();
    }

    // Populates the schedule table with a column for each employee.
    public void populateSchedule()
    {
        foreach (Employee employee in employees)
        {
            txtName = Instantiate(txtName, txtHead) as Text;
            txtName.text = employee.getFirstName();
            Instantiate(employeeColumn, schedulePane, false);
        }
    }


    public void addEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public void removeEmployee(Employee employee)
    {
        employees.Remove(employee);
    }

    // Start is called before the first frame update
    void Awake()
    {
        employees = new List<Employee>();

        Employee employee = new Employee();
        employees.Add(employee);
        employee = new Employee();
        employees.Add(employee);

        populateSchedule();
        Debug.Log(this.ToString());
    }
     
    // Update is called once per frame
    void Start()
    {
        ddDay = GameObject.Find("ddDay").GetComponent<TMP_Dropdown>();
        dayOfWeek = ddDay.value;
    }

    public override string ToString()
    {
        string returnVal = null;
        foreach (Employee employee in employees)
        {
            returnVal = employee.getFirstName() + " is scheduled to work on " + dayOfWeek + " at:";
            for (int i = 0; i < employee.getCurrentShift(dayOfWeek).Length; i++)
            {
                returnVal += employee.getCurrentShift(dayOfWeek)[1, i] + "/n";
            }
            returnVal += "/n";

        }
        return returnVal;
    }
}

/*
 * Problems with Schedule Tab Scripts (to fix later)
 * - read dropdown in ScheduleManager and EmployeeScheduleManager Script
 * - Get the ToString() above work.
 */

