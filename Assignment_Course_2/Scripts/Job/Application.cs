using Assignment_Course_2.Scripts.Static_Class;
using Assignment_Course_2.Scripts.Text_Dictionary;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Assignment_Course_2.Scripts.Job
{
    public class Application
    {
        //Class Variables
        public string? CompanyName = null;
        public string? PositionTitle = null;
        public enum ApplicationStatus
        {
            Applied,
            Interview,
            Offer,
            Rejected,
            Unknown
        }
        public ApplicationStatus Status = ApplicationStatus.Unknown;
        public DateTime ApplicationDate = new DateTime (0001,01,01);
        public DateTime ResponseDate = new DateTime (0001, 01, 01);
        public int? ResponseTimeDays = null;
        public int? SalaryExpectaion = null;



        //Get Days Since Applied and Recived a Response!
        public void GetDaysSinceApplied()
        {

            TimeSpan DaySpan = ResponseDate - ApplicationDate;
            ResponseTimeDays = DaySpan.Days;

        }


        //Get Application Summary!
        public void GetSummary()
        {
            GetDaysSinceApplied();

            //Run DaysSinceApplied(); method!
            Print.CreateLine(Print.Text.WriteLine, '-', Program_Values.LineLenght - 2);

            //
            Console.WriteLine($"Company Name        :({CompanyName})");
            Console.WriteLine($"Job Position        :({PositionTitle})");
            Console.WriteLine($"Current Status      :({Status})");
            Console.WriteLine($"Application Date    :({ApplicationDate.Year}/{ApplicationDate.Month}/{ApplicationDate.Day})");

            //Write Response Date if >= 0!
            if (ResponseTimeDays >= 0 )
            {
                Console.WriteLine($"Response time       :({ResponseTimeDays} days)");

            }
            else
            {
                Console.WriteLine($"Response time       :(Response NOT received)");
            }//


            //Console.WriteLine(ResponseDate);
            Console.WriteLine($"Salary Expectation  :({SalaryExpectaion}) sek");
            Print.CreateLine(Print.Text.WriteLine, '-', Program_Values.LineLenght - 2);

        }

    }
}
