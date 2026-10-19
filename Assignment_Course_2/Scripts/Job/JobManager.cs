using Assignment_Course_2.Scripts.Static_Class;
using Assignment_Course_2.Scripts.Text_Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment_Course_2.Scripts.Job
{
    public class JobManager
    {
        //Note: I have on purpes desided to try to reuse Variables as much as I can to not needing to create a Variable for every value that I'm going to use. That is why you will see a lot of User.ReadInput and/or User.Input in this scripts!

        //Class Variable
        bool LoopMethod = false;

        public List<Application> Applications = new List<Application>()
        {
            //Already added Job Applications inside of Applications!
            new Application ()
            {
                CompanyName = "Microsoft",
                PositionTitle = "Software Enginer",
                Status = Application.ApplicationStatus.Applied,
                ApplicationDate = new DateTime(2026,09,20),
                ResponseDate = new DateTime(0001,01,01),
                SalaryExpectaion = 35000
            },

            new Application ()
            {

                CompanyName = "Google",
                PositionTitle = "Housekeeper",
                Status = Application.ApplicationStatus.Applied,
                ApplicationDate = new DateTime(2026,10,5),
                ResponseDate = new DateTime(0001,01,01),
                SalaryExpectaion = 25500

            },
                        
            new Application ()
            {

                CompanyName = "Sony",
                PositionTitle = "Office Worker",
                Status = Application.ApplicationStatus.Rejected,
                ApplicationDate = new DateTime(2026,10,05),
                ResponseDate = new DateTime(2026,10,10),
                SalaryExpectaion = 31500

            },
                     
            new Application ()
            {

                CompanyName = "Apple",
                PositionTitle = "Office Worker",
                Status = Application.ApplicationStatus.Interview,
                ApplicationDate = new DateTime(2026,10,05),
                ResponseDate = new DateTime(2026,10,09),
                SalaryExpectaion = 32500

            },
         
            new Application ()
            {

                CompanyName = "Max",
                PositionTitle = "Chef",
                Status = Application.ApplicationStatus.Rejected,
                ApplicationDate = new DateTime(2026,09,27),
                ResponseDate = new DateTime(2026,10,05),
                SalaryExpectaion = 29000

            },


        };

        

        //Create and add a Application to Applications list!
        public void AddJobApplication()
        {
            //Creating a Job Application!
            Application JobApp = new Application();

            LoopMethod = true;

            //Print Add Application Menu!
            Print.ListToTextBoxes(new List<string> { "<:Add Application:> ", $"(You got {Applications.Count()} applications)", "<=:Base Info:=> " }, '-','|',2,Program_Values.TitleLength - 1);

            //Newer code ^ Version 3
            //Older code v Version 2

            //Print.CreateLine(Print.Text.Write, '-', 92);
            //Console.Write("\n");
            //Console.Write("|");
            //Print.CreateTextLine("<:Add Application:>", 45);
            //Console.Write("|");
            //Print.CreateTextLine($"(You got {Applications.Count()} applications)", 45);
            //Console.Write("|");
            //Console.Write("\n");
            //Print.CreateLine(Print.Text.Write, '-', 92);
            //Print.CreateTextWindow("<=:Base Info:=>", '-', 47);


            //Ask for Company Name!
            User.WriteAndReadInput(Print.Variable.String, "Company Name");
            JobApp.CompanyName = User.Input;//Add Company Name to Application!

            //
            User.WriteAndReadInput(Print.Variable.String, "Position Title");
            JobApp.PositionTitle = User.Input;//Add Position Title to Application!

            //
            User.int_Input = 0;
            User.WriteAndReadInput(Print.Variable.Int, "Salary Expectation");

            //
            while (User.int_Input <=0)
            {
                Print.ErrorCode("Invalid input! Enter a positive number!");
                User.WriteAndReadInput(Print.Variable.Int, "Salary Expectation");
            }
            //
            JobApp.SalaryExpectaion = User.int_Input;//Add Salary Expectation to Application!


            //
            Print.CreateTextWindow("<=:Date when applied:=>", '-', 47);

            //
            User.int_Input = 0;
            User.WriteAndReadInput(Print.Variable.Int, "Year");
            while (User.int_Input > DateTime.Now.Year || User.int_Input < 1900)
            {
                Print.ErrorCode($"Invalied year! Type a year between 1900 and {DateTime.Now.Year}!");
                User.WriteAndReadInput(Print.Variable.Int, "Year");
            }
            JobApp.ApplicationDate = JobApp.ApplicationDate.AddYears(User.int_Input - 1);

            //
            User.int_Input = 0;
            User.WriteAndReadInput(Print.Variable.Int, "Month");
            while (User.int_Input > DateTime.Now.Month && JobApp.ApplicationDate.Year == DateTime.Now.Year || User.int_Input < 1 || User.int_Input > 12)
            {
                if (User.int_Input > DateTime.Now.Month && JobApp.ApplicationDate.Year == DateTime.Now.Year)
                {
                    Print.ErrorCode($"Invalied month! Type a month between 1 and {DateTime.Now.Month}!");
                    User.WriteAndReadInput(Print.Variable.Int, "Month");
                }
                else
                {
                    Print.ErrorCode($"Invalied month! Type a month between 1 and 12!");
                    User.WriteAndReadInput(Print.Variable.Int, "Month");
                }
            
            }
            JobApp.ApplicationDate = JobApp.ApplicationDate.AddMonths(User.int_Input - 1);

            //Check how many days there are in the month of a year that has been chosen by JobApp.Month!
            //Made it into a Variable because the line where so long and made the comming while check long and messy to read! 😓
            int MaxDayRange = DateTime.DaysInMonth(JobApp.ApplicationDate.Year, JobApp.ApplicationDate.Month);

            User.int_Input = 0;
            User.WriteAndReadInput(Print.Variable.Int, "Day");
            //Check if the User have entered a value higher then 0 and that the number is not higher then MaxDayRange and that
            while (User.int_Input <= 0 || User.int_Input > MaxDayRange || User.int_Input > DateTime.Now.Day && JobApp.ApplicationDate.Year == DateTime.Now.Year && JobApp.ApplicationDate.Month == DateTime.Now.Month)
            {
                if (JobApp.ApplicationDate.Year == DateTime.Now.Year && JobApp.ApplicationDate.Month == DateTime.Now.Month && MaxDayRange > DateTime.Now.Day)
                {
                    Print.ErrorCode($"Invalied day! Type a day between 1 and {DateTime.Now.Day}!");
                    User.WriteAndReadInput(Print.Variable.Int, "Day");
                }

                else
                {
                    Print.ErrorCode($"Invalied day! Type a day between 1 and {MaxDayRange}!");
                    User.WriteAndReadInput(Print.Variable.Int, "Day");
                }

            }
            JobApp.ApplicationDate = JobApp.ApplicationDate.AddDays(User.int_Input - 1);

            //Set the JobApplication Status!
            Print.CreateTextWindow("<=:Job Application Status:=>", '-', Program_Values.LineLenght);  //Create Function Window!
            List<string> StatusOptions = new List<string>()                 //List of Commands for Application Status!
            {
                "(Applied)",
                "(Interviewed)",
                "(Offered)",
                "(Rejected)"
            };
            Print.ListByStringAmount(StatusOptions,2);
            Print.CreateLine(Print.Text.WriteLine, '.', 45);
            Console.Write("\n");
            Print.AskQuestionAndReadInput(Print.Variable.String, "Input");

            switch (User.Input.ToLower())
            {

                case "1":
                case "applied":
                    JobApp.Status = Application.ApplicationStatus.Applied;
                    break;

                case "2":
                case "interview":
                    JobApp.Status = Application.ApplicationStatus.Interview;
                    break;

                case "3":
                case "offer":
                    JobApp.Status = Application.ApplicationStatus.Offer;
                    break;

                case "4":
                case "rejected":
                    JobApp.Status = Application.ApplicationStatus.Rejected;
                    break;

            }

            //If anything but Status == Applied, ask when they resived a response. If Applied, you have yeat resived a response!
            if (JobApp.Status != Application.ApplicationStatus.Applied)
            {
                Print.CreateTextWindow("<=:When did you get a response?:=>", '-', 47);
                User.int_Input = 0;
                User.WriteAndReadInput(Print.Variable.Int, "Year");

                //
                while (JobApp.ApplicationDate.Year > User.int_Input || DateTime.Now.Year < User.int_Input)
                {
                    Print.ErrorCode($"Invalied year! Type a year between {JobApp.ApplicationDate.Year} or {DateTime.Now.Year}!");
                    User.WriteAndReadInput(Print.Variable.Int, "Year");
                }

                JobApp.ResponseDate = JobApp.ResponseDate.AddYears(User.int_Input - 1);


                //
                User.int_Input = 0;
                User.WriteAndReadInput(Print.Variable.Int, "Month");

                while (User.int_Input < JobApp.ApplicationDate.Month && JobApp.ApplicationDate.Year == JobApp.ResponseDate.Year || User.int_Input > DateTime.Now.Month || User.int_Input > 12 || User.int_Input < 1)
                {
                    if(JobApp.ApplicationDate.Month > User.int_Input)
                    {
                        Print.ErrorCode($"Invalied month! Type a month same as {DateTime.Now.Month} or higher!");
                        User.WriteAndReadInput(Print.Variable.Int, "Month");
                    }

                    else
                    {
                        Print.ErrorCode($"Invalied month! Type a month that is past or the same as the application month!");
                        User.WriteAndReadInput(Print.Variable.Int, "Month");
                    }

                }
                
                JobApp.ResponseDate = JobApp.ResponseDate.AddMonths(User.int_Input - 1);


                //
                User.int_Input = 0;
                User.WriteAndReadInput(Print.Variable.Int, "Day");

                while (User.int_Input < 1 || User.int_Input > MaxDayRange || User.int_Input > DateTime.Now.Day && JobApp.ApplicationDate.Year == DateTime.Now.Year && JobApp.ApplicationDate.Month == DateTime.Now.Month || JobApp.ApplicationDate.Day > User.int_Input)
                {
                    if (JobApp.ApplicationDate.Year == DateTime.Now.Year && JobApp.ApplicationDate.Month == DateTime.Now.Month && MaxDayRange > DateTime.Now.Day)
                    {
                        Print.ErrorCode($"Invalied day! Type a day between 1 and {DateTime.Now.Day}!");
                        User.WriteAndReadInput(Print.Variable.Int, "Day");
                    }

                    else
                    {
                        Print.ErrorCode($"Invalied day! Type a day between 1 and {MaxDayRange}!");
                        User.WriteAndReadInput(Print.Variable.Int, "Day");
                    }

                }
                JobApp.ResponseDate = JobApp.ResponseDate.AddDays(User.int_Input - 1);

            }

            //Add Application to Applications List!
            Applications.Add(JobApp);

            Console.Clear();
            Print.CreateTitle(": Assignment :", '=', Program_Values.TitleLength);
            Print.ListToTextBoxes(new List<string> { "<:Add Application:> ", $"(You got {Applications.Count()} applications)", "<=:Base Info:=> " }, '-', '|', 2, Program_Values.TitleLength - 2);
            Print.CreateTextWindow("Job Application has been added!", '.', 47);

            Console.ReadKey();

        }//Finish running task!



        //UpdateStatus of a Application!
        public void UpdateStatus()
        {
            //Print Update Status Menu!
            Print.ListToTextBoxes(new List<string> { "<:Update Application Status:> ", $"(You got {Applications.Count()} applications)", "<=:Applications:=>" }, '-', '|', 2, Program_Values.TitleLength - 1);

            //If no application in Applications!
            if (Applications.Count < 1)
            {
                Console.WriteLine("You have no available Applications!");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            //If application/ applications exist in Applications!
            else
            {
                //Place Holder! WriteLine (ESC)!
                Console.WriteLine("(Esc)");

                //Print the Job Applications name so the user can see them!
                User.int_Input = 0;
                foreach (var application in Applications)
                {
                    //Write Company Name!
                    Console.Write($"({application.CompanyName})   ");
                    User.int_Input++;

                    //If User Int is greater then 3, create new line!
                    if (User.int_Input > 3)
                    {
                        Console.Write("\n");
                        User.int_Input = 0;
                    }

                }
                //Print Line!
                Print.CreateLine(Print.Text.WriteLine, ':', 47);
                Console.WriteLine("");
                User.int_Input = 0;


                //Ask User for input!
                User.WriteAndReadInput(Print.Variable.String, "Input");

                switch (User.Input.ToLower())
                {

                    case "esc":
                        Console.Clear();
                        break;


                    default:

                        //
                        if (Applications.Exists(application => application.CompanyName.ToLower() == User.Input.ToLower()))
                        {

                            //
                            var AppIndex = Applications.FindIndex(application => application.CompanyName.ToLower() == User.Input.ToLower());

                            //
                            Print.CreateTextWindow("<=:What is the new status?:=>", '-', 47);
                            Console.Write("|");
                            Print.ListToTextLine(new List<string>{"1.(Applied)  ","2.(Interviewed) " }, 45);
                            Console.Write("|\n|");
                            Print.ListToTextLine(new List<string> { "3.(Offered) ", "4.(Rejected) " }, 46);
                            Console.Write("|\n");
                            Print.CreateLine(Print.Text.WriteLine, '-', 47);
                            User.WriteAndReadInput(Print.Variable.String, "Input");

                            //
                            switch (User.Input.ToLower())
                            {

                                default:
                                    Print.ErrorCode("Invalie Input!");
                                    break;

                                case "1":
                                case "applied":
                                    Applications[AppIndex].Status = Application.ApplicationStatus.Applied;
                                    break;

                                case "2":
                                case "interviewed":
                                case "interview":
                                    Applications[AppIndex].Status = Application.ApplicationStatus.Interview;
                                    break;

                                case "3":
                                case "offered":
                                case "offer":
                                    Applications[AppIndex].Status = Application.ApplicationStatus.Offer;
                                    break;

                                case "4":
                                case "rejected":
                                case "reject":
                                    Applications[AppIndex].Status = Application.ApplicationStatus.Rejected;
                                    break;

                            }

                            //
                            Console.WriteLine("Status has been updated!");
                            Console.ReadKey();
                        }

                        //
                        else
                        {
                            Console.WriteLine("Name NOT found!");
                        }

                        break;
                }

            }

        }//Finish running task!



        //Show Applications!
        public void ShowApplications()
        {

            LoopMethod = true;

            //Print Show Applications Menu!
            Print.ListToTextBoxes(new List<string> { "<:Show Applications:> ", $"(You got {Applications.Count()} applications)", "<=:Applications:=>" }, '-', '|', 2, Program_Values.TitleLength - 1);

            Console.WriteLine($"(All)  (Esc)  ");
            User.int_Input = 0;
            foreach (var application in Applications)
            {
                Console.Write($"({application.CompanyName})  ");
                User.int_Input++;

                if (User.int_Input >= 4)
                {
                    Console.Write("\n");
                    User.int_Input = 0;
                }
            }
            User.int_Input = 0;

            Print.CreateLine(Print.Text.WriteLine, '-', 46);


            Print.AskQuestionAndReadInput(Print.Variable.String,"Input");


            if (User.Input.ToLower() == "all" || User.Input.ToLower() == "esc")
            {

                switch (User.Input.ToLower())
                {

                    case "all":

                        Console.Clear();
                        Print.CreateTitle(": Assignment :", '=', Program_Values.TitleLength);
                        Print.ListToTextBoxes(new List<string> { "<:Show Applications:> ", $"(You got {Applications.Count()} applications)", "<=:All Applications:=>" }, '-', '|', 2, Program_Values.TitleLength - 1);

                        foreach (var application in Applications)
                        {

                            application.GetSummary();

                        }
                        LoopMethod = false;
                        break;


                    case "esc":
                        Console.Clear();
                        return;


                }

            }

            //If User.Input == Existing Application, print that Job Application!
            else if (Applications.Exists(application => application.CompanyName.ToLower() == User.Input.ToLower()))
            {

                User.int_Input = Applications.FindIndex(application => application.CompanyName.ToLower() == User.Input.ToLower());
                int Num = User.int_Input;

                Console.Clear();
                Print.CreateTitle(": Assignment :", '=', Program_Values.TitleLength);
                Print.ListToTextBoxes(new List<string> { "<:Show Application:>", $"(You got {Applications.Count()} applications)", $"Application for {Applications[User.int_Input].CompanyName}" }, '-', '|', 2, Program_Values.TitleLength - 1);

                Applications[Num].GetSummary();
                Console.WriteLine("");
                LoopMethod = false;
            }

            //If User.Input don't == anything, type that it's a Invalied Command!
            else
            {
                Console.WriteLine("Invalied Command!");
            }

            Console.ReadKey();
            if (LoopMethod == false)
            {
                return;
            }

        }//Finish running task!



        //Show Applications By Status!
        public void ShowApplicationsByStatus()
        {

            //var AppSortByStatus = Applications.OrderBy(a => a.Status);

            var AppSortByStatus = Applications.
                GroupBy(status => status.Status).
                OrderBy(status => status.Key);

            //
            Print.ListToTextBoxes(new List<string> { "<:Show Application By Status:>", $"(You got {Applications.Count()} applications)", "<=:Applications:=>" }, '-', '|', 2, Program_Values.TitleLength - 1);

            //
            foreach (var application in AppSortByStatus)
            {

                //Console.WriteLine("");
                Console.Write($"{application.Key}:");
                foreach (var App in application)
                {
                    Console.Write($" ({App.CompanyName}) ");
                }
                Console.Write("\n");

            }
            Print.CreateLine(Print.Text.WriteLine, '~', Program_Values.LineLenght - 2);

            Console.ReadKey();
            Console.Clear();


        }//Finish running task!



        //Show Applications By Date!
        public void ShowApplicationsByDate()
        {

            //
            var AppSortByStatus = Applications
                .GroupBy(date => date.ApplicationDate)
                .OrderBy(date => date.Key)
                .Reverse();

            //
            Print.ListToTextBoxes(new List<string> { "<:Show Application By Date:>", $"(You got {Applications.Count()} applications)", "<=:Applications:=>" }, '-', '!', 2, Program_Values.TitleLength - 1);


            foreach (var application in AppSortByStatus)
            {

                Console.WriteLine("");
                Console.Write($"{application.Key.Year}/ {application.Key.Month}/ {application.Key.Day}:");
                foreach (var app in application)
                {
                    Console.Write($" ({app.CompanyName}) ");
                }

            }

            Print.CreateLine(Print.Text.WriteLine, '.', Program_Values.LineLenght - 2);

            Console.ReadKey();
            Console.Clear();


        }//Finish running task!



        //Remove Application!
        public void RemoveApplication()
        {
            //Print Remove Application Menu!
            Print.ListToTextBoxes(new List<string> { "<:Remove Application:>", $"(You got {Applications.Count()} applications)", "<=:Applications:=>" }, '-', 'x', 2, Program_Values.TitleLength - 1);

            //Creating a Queue variable!
            Queue<string> CommandsQueue = new Queue<string>(["All", "Esc", "Rejected", "Older Then X Days"]);

            //Adding all Application Company Names to the Queue!
            foreach (var application in Applications)
            {
                CommandsQueue.Enqueue(application.CompanyName);
            }

            //Write the Avalabiel commands, all the strings inside of CommandsQueue!
            int CommandRange = 4;
            User.int_Input = 1;

            foreach (string application in CommandsQueue)
            {
                //
                User.int_Input++;//Adding 1 Command!

                if (User.int_Input <= CommandRange)
                {

                    Console.Write($"({application})  ");

                }

                //
                else
                {

                    Console.Write($"\n({application})  ");
                    User.int_Input = 1;

                }


            }

            Console.Write("\n");

            Print.CreateTextWindow($"What Application would you like to Remove?", '~',47);

            //
            User.WriteAndReadInput(Print.Variable.String, "Input");

            //
            switch (User.Input.ToLower())
            {
                //
                case "all":
                    Console.WriteLine("Are you sure you want to Remove All Applications?");
                    Console.WriteLine("(Yes)     (No)");
                    User.WriteAndReadInput(Print.Variable.String, "Input");

                    //Check if User.Input == Yes or No. Tell user that the Input is invaled if not true!
                    User.Is_Yes_Or_No_Input();

                    //If 
                    switch (User.Input.ToLower())
                    {

                        //
                        case "yes":
                            Applications = new List<Application>();
                            Console.WriteLine("Application list is now clean! \nAll applications have been Removed!");
                            break;

                        //
                        case "no":
                            Console.WriteLine("Canceling Removel of All Applications!");
                            break;

                    }

                    break;//

                //
                case "rejected":
                    Console.WriteLine("Are you sure you want to remove Rejected Applications?");
                    Console.WriteLine("(Yes)     (No)");

                    User.WriteAndReadInput(Print.Variable.String, "Input");

                    //Check if User input is Yes or No!
                    User.Is_Yes_Or_No_Input();

                    switch (User.Input.ToLower())
                    {
                        case "yes":
                            //var SelectedTargets = Applications.GroupBy(application => application.Status == JobApplication_Class.ApplicationStatus.Rejected);

                            Applications.RemoveAll(application => application.Status == Application.ApplicationStatus.Rejected);
                            break;


                        case "no":
                            Console.WriteLine($"Canceling Removel of Rejeccted Applications!");
                            break;


                    }

                    break;//

                //Set how many days old a application can be. If the application is older then X days ago, remove them from Applications list!
                case "older then x days":
                case "older":
                case "x days":
                case "x":
                    Console.WriteLine("How many days back?");
                    User.WriteAndReadInput(Print.Variable.Int, "Input");

                    Applications.RemoveAll(application => application.ApplicationDate.Date < DateTime.Now.AddDays( - User.int_Input).Date);
                    Console.WriteLine($"Allications older then {User.int_Input} has been Removed!");

                    break;//

                //
                case "esc":
                    Console.WriteLine("Going back to Main Menu!");
                    return;

                //If non of the main Commands, check if User.Input == Application.CompanyName. If not tell the User that they typed a invalied command!
                default:

                    //
                    if (Applications.Exists(application => application.CompanyName.ToLower() == User.Input.ToLower()))
                    {
                        //
                        string SelectedApplication = User.Input;
                        Console.WriteLine($"Are you sure you want to remove ({SelectedApplication})?");
                        Console.WriteLine("(Yes)     (No)");

                        User.WriteAndReadInput(Print.Variable.String, "Input");

                        User.Is_Yes_Or_No_Input();

                        switch (User.Input.ToLower())
                        {

                            //If User type Yes, Remove application from Applications!
                            case "yes":
                                Applications.RemoveAll(application => application.CompanyName.ToLower() == SelectedApplication.ToLower() );
                                Console.WriteLine($"{SelectedApplication} has been Removed from Applications list!");
                                break;


                            //If User type No, cancel the process!
                            case "no":
                                Console.WriteLine($"Canceling Removel of {SelectedApplication}!");
                                break;
                        }

                    }

                    //
                    else
                    {

                        Console.WriteLine("Invalied Command!");

                    }
                    break;//

            }

            Console.ReadKey();
            Console.Clear();

        }//Finish running task!



        //Show Statistics
        public void ShowStatistics()
        {

            var GroupBy = Applications
                .GroupBy(application => application.Status)
                .OrderBy(application => application.Key);


            //Print Application Statistics Menu!
            Print.ListToTextBoxes(new List<string> { "<:Application Statistics:>", $"(You got {Applications.Count()} applications)", "<=:Applications:=>" }, '-', 'I', 2, Program_Values.TitleLength - 1);


            if (Applications.Count > 0)
            {

                //
                foreach (var application in GroupBy)
                {
                    
                    Console.Write($":{application.Count()} {application.Key}  |");//
                    
                    //
                    foreach (var app in application)
                    {

                        Console.Write($"   ({app.CompanyName})");
                        app.GetDaysSinceApplied();

                    }
                    Console.Write("\n");
                }

                Print.CreateLine(Print.Text.WriteLine, '-', 47);

                var ResponseDays = Applications.
                    Where(application => application.ResponseTimeDays >= 0).
                    Average(application => (application.ResponseDate - application.ApplicationDate).TotalDays);


                //
                if (ResponseDays > 0)
                {
                    Console.WriteLine($"Average Response Time: {((int) ResponseDays)} days");
                    Print.CreateLine(Print.Text.WriteLine, '-', 47);
                }

                //
                else
                {
                    Console.WriteLine("Average Response Time: Have Not Resived any responses!");
                    Print.CreateLine(Print.Text.WriteLine, '-', 47);
                }

            }

            else
            {
                Console.WriteLine("You got no Applications!");
            }


            Console.ReadKey();



        }//Finish running task!

    }
}
