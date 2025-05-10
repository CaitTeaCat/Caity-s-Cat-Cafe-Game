using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.ScheduleTab
{
    public class Shift : MonoBehaviour
    {

        private int dayOfWeek;
        private string[,] employeeShift;

        public Shift()
        {
            dayOfWeek = 0;
            employeeShift = null;
        }
        public Shift(int day)
        {
            dayOfWeek = day;
            employeeShift = new string[2, 10];
        }

        public Shift(int day, string[,] eShift)
        {
            dayOfWeek = day;
            employeeShift = eShift;
            Employee employee = new Employee();
            employee.addShift(this, dayOfWeek);
        }

        public Shift createNullShift(int day)
        {
            Shift nullShift = new Shift(day);
            string[,] newShift = { { "8AM", "9AM", "10AM", "11AM", "12PM", "1PM", "2PM", "3PM", "4PM", "5PM" }, { "Not scheduled", "Not scheduled", "Not scheduled", "Not scheduled", "Not scheduled", "Not scheduled", "Not scheduled", "Not scheduled", "Not scheduled", "Not scheduled"}};
            nullShift.setShift(newShift);
            return nullShift;
        }


        public string[,] getShift()
        {
            return employeeShift;
        }

        public void setShift(string[,] eShift)
        {
            employeeShift = eShift;
        }
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
