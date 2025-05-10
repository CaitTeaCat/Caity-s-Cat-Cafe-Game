using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamePlay.ScheduleTab;
using UnityEditor;

public class Employee : MonoBehaviour
{
    private string firstName;
    private string lastName;
    private int age;
    private string gender;
    private string workStyle;
    private int efficiency;

    private List<Shift> shifts;
    private string[,] shift;
    private Image employeeImage;

    private int dayOfWeek;

    public Employee()
    {
        firstName= null;
        lastName = null;
        age = 0;
        gender = null;
        workStyle = null;
        efficiency = 0;
        shifts = new List<Shift>();
        shift = new string[2, 10];
        employeeImage = null;

        createEmployee();
        ScheduleManager scheduleManager = new ScheduleManager();
        scheduleManager.addEmployee(this);

        dayOfWeek = 0; // Create Static Method in GameManeger to return day of weeek
    }

    public void createEmployee()
    {
        int temp = Random.Range(0, 2);
        if (temp == 0) {
            gender = "Female";
        }
        else
        {
            gender = "Male";
        }

        string[] maleNames = {"Liam", "Noah", "Oliver", "Elijah", "James", "William", "Benjamin", "Lucas", "Henry", "Theodore",
            "Jack", "Levi", "Alexander", "Jackson", "Mateo", "Daniel", "Michael", "Mason", "Sebastian", "Ethan",
            "Logan", "Owen", "Samuel", "Jacob", "Asher", "Aiden", "John", "Joseph", "Wyatt", "David",
            "Leo", "Luke", "Julian", "Hudson", "Grayson", "Matthew", "Ezra", "Gabriel", "Carter", "Isaac",
            "Jayden", "Luca", "Anthony", "Dylan", "Lincoln", "Thomas", "Maverick", "Elias", "Josiah", "Charles",
            "Caleb", "Christopher", "Ezekiel", "Miles", "Jaxon", "Isaiah", "Andrew", "Joshua", "Nathan", "Nolan",
            "Adrian", "Cameron", "Santiago", "Eli", "Aaron", "Ryan", "Angel", "Cooper", "Waylon", "Easton",
            "Kai", "Christian", "Landon", "Colton", "Roman", "Axel", "Brooks", "Jonathan", "Robert", "Jameson",
            "Ian", "Everett", "Greyson", "Wesley", "Jeremiah", "Hunter", "Leonardo", "Jordan", "Jose", "Bennett",
            "Silas", "Nicholas", "Parker", "Beau", "Weston", "Austin", "Connor", "Carson", "Dominic", "Xavier"};

        string[] femaleNames = {"Olivia", "Emma", "Ava", "Sophia", "Isabella", "Mia", "Amelia", "Harper", "Evelyn", "Abigail",
            "Emily", "Ella", "Elizabeth", "Camila", "Luna", "Sofia", "Avery", "Mila", "Aria", "Scarlett",
            "Penelope", "Layla", "Chloe", "Victoria", "Madison", "Eleanor", "Grace", "Nora", "Riley", "Zoey",
            "Hannah", "Hazel", "Lily", "Ellie", "Violet", "Lillian", "Zoe", "Stella", "Aurora", "Natalie",
            "Emilia", "Everly", "Leah", "Aubrey", "Willow", "Addison", "Lucy", "Audrey", "Bella", "Nova",
            "Brooklyn", "Paisley", "Savannah", "Claire", "Skylar", "Isla", "Genesis", "Naomi", "Elena", "Caroline",
            "Eliana", "Anna", "Maya", "Valentina", "Ruby", "Kennedy", "Ivy", "Ariana", "Aaliyah", "Cora",
            "Madelyn", "Alice", "Kinsley", "Hailey", "Gabriella", "Allison", "Gianna", "Serenity", "Samantha", "Sarah",
            "Autumn", "Quinn", "Eva", "Piper", "Sophie", "Sadie", "Delilah", "Josephine", "Nevaeh", "Adeline",
            "Arya", "Emery", "Lyla", "Clara", "Vivian", "Raelynn", "Melanie", "Melody", "Julia", "Athena"};

        string[] lastNames = {"Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
            "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin",
            "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson",
            "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores",
            "Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell", "Carter", "Roberts",
            "Gomez", "Phillips", "Evans", "Turner", "Diaz", "Parker", "Cruz", "Edwards", "Collins", "Reyes",
            "Stewart", "Morris", "Morales", "Murphy", "Cook", "Rogers", "Gutierrez", "Ortiz", "Morgan", "Cooper",
            "Peterson", "Bailey", "Reed", "Kelly", "Howard", "Ramos", "Kim", "Cox", "Ward", "Richardson",
            "Watson", "Brooks", "Chavez", "Wood", "James", "Bennett", "Gray", "Mendoza", "Ruiz", "Hughes",
            "Price", "Alvarez", "Castillo", "Sanders", "Patel", "Myers", "Long", "Ross", "Foster", "Jimenez",
            "Adeyemi", "Okonkwo", "Mensah", "Ndlovu", "Abebe", "Diop", "Kamau", "Tshabalala", "Chukwuma", "Jalloh",
            "Bakari", "Eze", "Osei", "Mwangi", "Diallo", "Obasi", "Amadi", "Makonnen", "Adebayo", "Zulu",
            "Kim", "Lee", "Park", "Choi", "Kang", "Nguyen", "Tran", "Pham", "Le", "Vo",
            "Chen", "Wang", "Li", "Zhang", "Liu", "Tanaka", "Yamamoto", "Kobayashi", "Patel", "Singh"};

        temp = Random.Range(0, 100);
        if (gender == "female")
        {
            firstName= femaleNames[temp];
        }
        else
        {
            firstName= maleNames[temp];
        }

        temp = Random.Range(0, 140);
        lastName = lastNames[temp];

        age = Random.Range(16, 97);

        string[] workStyles = {"Fast", "Lazy", "Slow", "Balanced", "Unreliable"};
        temp = Random.Range(0, 5);
        workStyle = workStyles[temp];

        if (workStyle == workStyles[0])
        {
            efficiency = Random.Range(40, 60);
        }
        else if(workStyle == workStyles[1])
        {
            efficiency = Random.Range(10, 45);
        }
        else if (workStyle == workStyles[2])
        {
            efficiency = Random.Range(50, 80);
        }
        else if (workStyle == workStyles[3])
        {
            efficiency = Random.Range(75, 95);
        }
        else if (workStyle == workStyles[4])
        {
            efficiency = Random.Range(20, 100);
        }

        createWeeklySchedule();

        shift = getCurrentShift(dayOfWeek);

        employeeImage = null;// Add images using if loop later
    }

    public void createWeeklySchedule()
    {
        Shift employeeShift;
        for (int i = 0; i < 6; i++)
        {
            employeeShift = new Shift(i);
            shifts.Add(employeeShift.createNullShift(i));
        }
    }

    public List<Shift> getWeeklySchedule()
    {
        return shifts;
    }

    public void addShift(Shift shift, int day)
    {
        shifts.RemoveAt(day);
        shifts.Insert(day, shift);
    }

    public void removeShift(int index)
    {
        shifts.RemoveAt(index);
        shifts.Insert(index, null);
    }

    public string[,] getCurrentShift(int day)
    {
        return shifts[day].getShift();
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }
}
