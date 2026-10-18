using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_Course_2.Scripts.Text_Dictionary
{
    static class User
    {
        //User Values!
        public static string Input;                                              //string value. Type User.Input to access it!
        public static int int_Input;                                             //int value. Type User.int_Input to access it!
        
        


        //Read ``string´´ Input!
        public static void ReadInput()                                     //Read whatever the Input is. Made this because I don't want to type ``User.Input = Console.ReadLine()´´ all the time!
        {
            Input = Console.ReadLine();                                          //Read what User entered and set it as User Input!
            while(Input.IsWhiteSpace())                                          //While User Input is empty or only space!
            {
                Console.WriteLine("Empty Input! Type something!");               //Tell that the User has entered a empty Input and that they need to try again!
                Input = Console.ReadLine();                                      //Read what User entered and set it as User Input!
            }

        }



        //Read ``int´´ Input!
        public static void ReadInput_int()                                 //Start method to read User Input and check if it can be used as an int variable!
        {

            //Check if the user has entered a whole number!
            string Num = Console.ReadLine();                                     //Read what User entered and set it as Num!
            while (!int.TryParse(Num, out int_Input))                            //While loop if the Input is not able to convert into a number!
            {
                Console.WriteLine("Invalied Input. Need to be a whole number!"); //If Num is not a whole number or have entered other then number characters, print this text!
                Num = Console.ReadLine();                                        //Ask the User to enter a new Input!
            }

            int_Input = int.Parse(Num);                                          //Input is able to become a int variable. Set Num as int_Input!

        }




        //Read if ``Yes´´ Or ``No´´ Input!
        public static void Is_Yes_Or_No_Input()                            //Start method to check User Inupt if it's ``Yes´´ or ``No´´ 
        {

            while (Input.ToLower() != "yes" && Input.ToLower() != "no")                  //While loop if the Input is not ``Yes´´ or ``No´´!
            {

                Console.WriteLine("Invalied Command! \nType ``Yes´´ or ``No´´!");//If Input is not a ``Yes´´ or ``No´´, print this text!
                ReadInput();                                                     //Read what User entered and set it as User Input!

            }
        }



        //
        public static void WriteAndReadInput(Print.Variable VariableType, string Question)//Write a text and read User Input!
        {

            switch (VariableType)
            {
                default:
                    Console.Write($"{Question}: ");
                    ReadInput();
                    break;

                case Print.Variable.String:
                    Console.Write($"{Question}: ");
                    ReadInput();
                    break;

                case Print.Variable.Int:
                    Console.Write($"{Question}: ");
                    ReadInput_int();
                    break;

            }

        }


    }
}
