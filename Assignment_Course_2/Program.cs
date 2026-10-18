using Assignment_Course_2.Scripts.Job;
using Assignment_Course_2.Scripts.Static_Class;
using Assignment_Course_2.Scripts.Text_Dictionary;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment_Course_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Progam Variables!\\
            bool RunProgram = true;

            //Objects!
            JobManager JobManager = new JobManager();
            Scripts.Job.Application JobApplication = new Scripts.Job.Application();


            //Program Commands List!
            List<string> Commands = new List<string>
            {
                "1.(Add Application)",
                "2.(Show Applications)",
                "3.(Sort by Status)",
                "4.(Sort by Date)",
                "5.(Show Statistics)",
                "6.(Update Application Status)",
                "7.(Remove Application)",
                "8.(Exit Program)"

            };


            //While Program is running, Loop Program!
            while (RunProgram == true)
            {

                //Print Title text!
                Print.CreateTitle(": Assignment :", '=', Program_Values.TitleLength);

                //Print Menu!
                Print.ListToTextBoxes(new List<string> {"<:Main Menu:> ", $"(You got {JobManager.Applications.Count} applications)", "<=:Available Commands:=>" }, '-', '|', 2, Program_Values.TitleLength - 1);

                //Write Commands!
                Print.ListByTextLength(Commands, 45);
                Print.CreateLine(Print.Text.WriteLine, '-', Program_Values.LineLenght);


                //Ask for user input!
                User.WriteAndReadInput(Print.Variable.String, "Input: ");


                //Respond based on User Input!
                switch (User.Input)
                {
                    //If User Input == ``no case found´´ tell the user that is a Invalid Command and go back to start in while!
                    default:
                        Console.Clear();
                        Print.CreateTitle(": Assignment :", '=', Program_Values.TitleLength);//Create Title!
                        Print.InvalidCommandBig();
                        break;


                    //Add Job Application to Applications list!
                    case "1":
                        Console.Clear();
                        Print.CreateTitle(": Assignment :", '=', Program_Values.TitleLength);//Create Title!
                        JobManager.AddJobApplication();
                        Console.Clear();
                        break;


                    //Show All Job Applications!
                    case "2":
                        Console.Clear();
                        Print.CreateTitle(": Assignment :", '=', Program_Values.TitleLength);//Create Title!
                        JobManager.ShowApplications();
                        Console.Clear();
                        break;


                    //Show All Job Applications By Status!
                    case "3":
                        Console.Clear();
                        Print.CreateTitle(": Assignment :", '=', Program_Values.TitleLength);//Create Title!
                        JobManager.ShowApplicationsByStatus();
                        Console.Clear();

                        break;


                    //Show Applications By Status!
                    case "4":
                        Console.Clear();
                        Print.CreateTitle(": Assignment :", '=', Program_Values.TitleLength);//Create Title!
                        JobManager.ShowApplicationsByDate();
                        Console.Clear();
                        break;


                    //Show Applications By Statistics!
                    case "5":
                        Console.Clear();
                        Print.CreateTitle(": Assignment :", '=', Program_Values.TitleLength);//Create Title!
                        JobManager.ShowStatistics();
                        Console.Clear();
                        break;


                    //Update Status of a Job Application!
                    case "6":
                        Console.Clear();
                        Print.CreateTitle(": Assignment :", '=', Program_Values.TitleLength);//Create Title!
                        JobManager.UpdateStatus();
                        Console.Clear();
                        break;


                    //Remove Application!
                    case "7":
                        Console.Clear();
                        Print.CreateTitle(": Assignment :", '=', Program_Values.TitleLength);//Create Title!
                        JobManager.RemoveApplication();
                        Console.Clear();
                        break;


                    //End Program!
                    case "8":
                        RunProgram = false;
                        break;

                }
            }
        }
    }
}
