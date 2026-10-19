using Assignment_Course_2.Scripts.Static_Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Assignment_Course_2.Scripts.Text_Dictionary
{
    static class Print
    {
        //text Dictionary. Can be used to access existing text or to add and then access custom made text!
        public static Dictionary<string, string> text = new Dictionary<string, string>
        {

            ["Line"] = $"==========",
            ["Line Arrowed"] = $"<========>",
            ["Line Arrowed Left"] = $"<=========",
            ["Line Arrowed Right"] = $"=========>",
            ["Space"] = "          ",
            ["Line Thin"] = "----------",
            ["Line Thin Lower"] = "__________",

        };



        //
        public enum Variable
        {

            String,
            Int,
            Float,



        }



        //
        public enum Text
        {

            Write,
            WriteLine,


        }


        //Easy access to premade string texts!
        public static string Line = "==========";
        public static string Line_Arrowed = "<========>";
        public static string Line_Arrowed_Left = "<=========";
        public static string Line_Arrowed_Right = "=========>";
        public static string Line_Thin_Lower = "__________";
        public static string Space = "          ";



        //ERROR CODE!
        public static void ErrorCode(string ErrorMessage)
        {

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"ERROR! {ErrorMessage}");
            Console.ResetColor();

        }



        //Invalid Command message!
        public static void InvalidCommandBig()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("······························································\r\n:░▀█▀░█▀█░█░█░█▀█░█░░░▀█▀░█▀▄░░░█▀▀░█▀█░█▄█░█▄█░█▀█░█▀█░█▀▄░█:\r\n:░░█░░█░█░▀▄▀░█▀█░█░░░░█░░█░█░░░█░░░█░█░█░█░█░█░█▀█░█░█░█░█░▀:\r\n:░▀▀▀░▀░▀░░▀░░▀░▀░▀▀▀░▀▀▀░▀▀░░░░▀▀▀░▀▀▀░▀░▀░▀░▀░▀░▀░▀░▀░▀▀░░▀:\r\n······························································\n");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();

        }



        //Unavaiable Command message!
        public static void UnavaiableCommand()
        {



        }



        //Write and read Input and set it as User.Input!
        public static void AskQuestionAndReadInput(Variable VariableType, string Question)//Write a text and read User Input!
        {

            switch (VariableType)
            {
                default:
                    Print.ErrorCode("Faild to run ``AskQuestionAndReadInput´´ method!");
                    break;

                case Variable.String:
                    Console.Write($"{Question}: ");
                    User.ReadInput();
                    break;

                case Variable.Int:
                    Console.Write($"{Question}: ");
                    User.ReadInput_int();
                    break;


            }

        }



        //Write a line of a entered string!
        public static void CreateLine(Text WriteType, char LineType, int Length)//Create a Line of a character!
        {
            switch (WriteType)
            {

                //If Write, add characters!
                case Text.Write:

                    for (int i = 0; i < Length; i++)
                    {
                        Console.Write($"{LineType}");
                    }

                    break;

                //If WriteLine, add characters by making a new line!
                case Text.WriteLine:

                    Console.Write("\n");
                    for (int i = 0; i < Length; i++)
                    {
                        Console.Write($"{LineType}");
                    }

                    Console.Write("\n");

                    break;
            }

        }



        //Write strings from List and check Character amount!
        public static void ListByTextLength(List<string> List, int TextLineLenght)//Add a List and set how long a Text Line can be before making a new Line!

        {

            if (List.Count() < 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("ERROR! LIST NOT FOUND: ``List´´ is empty in ``ListByTextLength´´ Method!");
                Console.ResetColor();
                return;
            }

            else
            {

                int TextLength = 0;

                User.int_Input = 0;
                for (int i = 0; i < List.Count; i++)
                {

                    TextLength = TextLength + List[i].Count();

                    if (TextLength < TextLineLenght)
                    {
                        Console.Write($"{List[i]}  ");
                    }
                    else
                    {
                        Console.Write($"\n{List[i]}  ");
                        TextLength = List[i].Count();
                    }


                }
                User.int_Input = 0;

            }

        }//



        //Write string from List and check string Amount!
        public static void ListByStringAmount(List<string> List, int TextsInListBeforeNewLine)//Add a List and set how many strings from that List can be writen before making a new Line!
        {
            if (List.Count() < 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("ERROR! LIST NOT FOUND: ``List´´ is empty in ``ListByAmount´´ Method!");
                Console.ResetColor();
                return;
            }


            User.int_Input = 0;
            for (int i = 0; i < List.Count; i++)
            {
                //If printed 4 Commands, move Write down one line and set CommandCounts to 0!
                if (User.int_Input >= TextsInListBeforeNewLine)
                {
                    User.int_Input = 0;
                    Console.Write("\n \n");
                }

                User.int_Input++;
                Console.Write(i + 1 + "." + List[i] + "  ");

            }
            User.int_Input = 0;
        }//



        //Create Text Line from List strings!
        public static void ListToTextLine(List<string> List, int TextLineLength)
        {

            if (List.Count() < 1)
            {

                ErrorCode("LIST NOT FOUND: ``List´´ is empty in ``ListToTextLine´´ Method!");

            }

            if (TextLineLength < List.Sum(character => character.Count()))
            {

                TextLineLength = List.Sum(character => character.Count());

            }

            int Space = (TextLineLength - List.Sum(characters => characters.Count()));
            Space = Space / 4;


            foreach(string ListItem in List)
            {

                for (int i = 0; i < Space; i++ )
                {
                    Console.Write(" ");
                }

                Console.Write($"{ListItem}");

                for (int i = 0; i < Space; i++)
                {
                    Console.Write(" ");
                }

            }



        }//



        //
        public static void ListToTextBoxes(List<string> List, char LineType, char SideLineType, int BoxesBeforeCreatingNewLine, int WindowLenght)
        {

            //If List is empty!
            if (List.Count() <= 0)
            {

                ErrorCode("LIST EMPTY! List in ``ListToTextBoxes´´ is empty. Can't run method!");
                Console.ReadKey();
                return;

            }

            //Method Variables!
            User.int_Input = 0;                                                     //

            int BoxCharTotalSize = WindowLenght - BoxesBeforeCreatingNewLine - 1;   //
            BoxCharTotalSize = BoxCharTotalSize / BoxesBeforeCreatingNewLine;       //
            int Space = BoxCharTotalSize;                                           //

            
            
            //Write a Line at the top of the boxes!
            CreateLine(Text.Write, LineType, WindowLenght);
            Console.Write("\n");

            //While all Indexes in List are not used, run the loop!
            while (User.int_Input < List.Count())
            {

                //At the start of every new line, draw a SideLineType!
                Console.Write(SideLineType);

                //It Boxes Before Creating a New Line is less or equal to List.Count() run method as normal!
                if (User.int_Input + BoxesBeforeCreatingNewLine <= List.Count())
                {

                    //
                    for (int i = 0; i < BoxesBeforeCreatingNewLine; i++)
                    {

                        //
                        Space = (Space - List[User.int_Input].Count()) / 2;
                        

                        //
                        for (int whiteSpace = 0; whiteSpace < Space; whiteSpace++)
                        {
                            Console.Write(" ");
                        }

                        //
                        Console.Write(List[User.int_Input]);

                        //
                        for (int whiteSpace = 0; whiteSpace < Space; whiteSpace++)
                        {
                            Console.Write(" ");
                        }

                        Console.Write(SideLineType);

                        Space = BoxCharTotalSize;
                        User.int_Input++;

                    }
                    Console.Write("\n");
                    CreateLine(Text.Write, LineType, WindowLenght);
                    Console.Write("\n");
                }



                //It Boxes Before Creating a New Line is not less or equal to List.Count() run method for the remaining strings and leave the other boxes empty!
                else
                {

                    for (int i = 0; i < BoxesBeforeCreatingNewLine; i++)
                    {

                        //
                        if (User.int_Input < List.Count())
                        {

                            Space = (Space - List[User.int_Input].Count()) / 2;

                            //
                            for (int whiteSpace = 0; whiteSpace < Space; whiteSpace++)
                            {
                                Console.Write(" ");
                            }

                            //
                            Console.Write(List[User.int_Input]);

                            //
                            for (int whiteSpace = 0; whiteSpace < Space; whiteSpace++)
                            {
                                Console.Write(" ");
                            }

                        }

                        //
                        else
                        {
                            //
                            for (int whiteSpace = 0; whiteSpace < Space; whiteSpace++)
                            {
                                Console.Write(" ");
                            }

                        }


                        Console.Write(SideLineType);
                        Space = BoxCharTotalSize;
                        User.int_Input++;

                    }
                    Console.Write("\n");
                    CreateLine(Text.Write, LineType, WindowLenght);
                    Console.Write("\n");
                }

            }
            User.int_Input = 0;

        }//



        //
        public static void ListToGroupedWindow(List<string> List, char LineType, char SideLineType, int WindowLenght)//!!!!!!!!!Not Yeat Fuctional!!! Work in progress!!!!!!!
        {

            //If List is empty!
            if (List.Count() <= 0)
            {

                ErrorCode("LIST EMPTY! List in ``ListToGroupedWindow´´ is empty. Can't run method!");
                Console.ReadKey();
                return;

            }

            //Method Variables!
            User.int_Input = 0;

            int WindowCharTotalSize = WindowLenght - 2;

            int Space;

            int CharInLine = 0;

            CreateLine(Text.WriteLine,LineType,WindowLenght);

            int forLoops = 0;

            while (User.int_Input < List.Count())
            {
                //
                int forLoop = 0;

                Space = WindowCharTotalSize;

                //
                Console.Write(SideLineType);

                //
                for (CharInLine = 0; CharInLine + List[forLoops].Count() < WindowCharTotalSize; CharInLine++)
                {

                    CharInLine = CharInLine + List[forLoops].Count() - 1;
                    forLoops++;
                    forLoop++;

                }

                //
                Space = (Space - CharInLine) / forLoop;

                for (int Loops = 0; Loops < forLoop; Loops++)
                {
                    //
                    for (int whiteSpace = 0; whiteSpace < Space; whiteSpace++)
                    {
                        Console.Write(" ");
                    }

                    //
                    Console.Write(List[User.int_Input]);


                    //
                    for (int whiteSpace = 0; whiteSpace < Space; whiteSpace++)
                    {
                        Console.Write(" ");
                    }

                    User.int_Input++;

                }
                
                Console.Write($"{SideLineType}\n");



            }

            CreateLine(Text.Write,LineType,WindowLenght);
            Console.Write("\n");
            User.int_Input = 0;

        }


        //
        public static void ListToGroupedMultyWindows(List<string> List, char LineType, char SideLineType, int BoxesBeforeCreatingNewLine, int WindowLenght)
        {

            //If List is empty!
            if (List.Count() <= 0)
            {

                ErrorCode("LIST EMPTY! List in ``ListToGroupedMultyWindows´´ is empty. Can't run method!");
                Console.ReadKey();
                return;

            }

            //Method Variables!
            User.int_Input = 0;

            int BoxCharTotalSize = WindowLenght - BoxesBeforeCreatingNewLine - 1;
            BoxCharTotalSize = BoxCharTotalSize / BoxesBeforeCreatingNewLine;

            int Space = BoxCharTotalSize;



            //
            CreateLine(Text.Write, LineType, WindowLenght);
            Console.Write("\n");

            while (User.int_Input < List.Count())
            {

                //At the start of every new line, draw a SideLineType!
                Console.Write(SideLineType);

                //
                if (User.int_Input + BoxesBeforeCreatingNewLine <= List.Count())
                {

                    //
                    for (int i = 0; i < BoxesBeforeCreatingNewLine; i++)
                    {

                        //
                        Space = (Space - List[User.int_Input].Count()) / 2;


                        //
                        for (int whiteSpace = 0; whiteSpace < Space; whiteSpace++)
                        {
                            Console.Write(" ");
                        }

                        //
                        Console.Write(List[User.int_Input]);

                        //
                        for (int whiteSpace = 0; whiteSpace < Space; whiteSpace++)
                        {
                            Console.Write(" ");
                        }

                        Console.Write(SideLineType);

                        Space = BoxCharTotalSize;
                        User.int_Input++;

                    }
                    Console.Write("\n");
                }

                //
                else
                {

                    for (int i = 0; i < BoxesBeforeCreatingNewLine; i++)
                    {

                        //
                        if (User.int_Input < List.Count())
                        {

                            Space = (Space - List[User.int_Input].Count()) / 2;

                            //
                            for (int whiteSpace = 0; whiteSpace < Space; whiteSpace++)
                            {
                                Console.Write(" ");
                            }

                            //
                            Console.Write(List[User.int_Input]);

                            //
                            for (int whiteSpace = 0; whiteSpace < Space; whiteSpace++)
                            {
                                Console.Write(" ");
                            }

                        }

                        //
                        else
                        {
                            //
                            for (int whiteSpace = 0; whiteSpace < Space; whiteSpace++)
                            {
                                Console.Write(" ");
                            }

                        }


                        Console.Write(SideLineType);
                        Space = BoxCharTotalSize;
                        User.int_Input++;

                    }
                    Console.Write("\n");
                    CreateLine(Text.Write, LineType, WindowLenght);
                    Console.Write("\n");
                }

            }
            User.int_Input = 0;

        }//



        //Create Text Line from string!
        public static void CreateTextLine(string WriteText, int TextLineLength)//
        {

            if (WriteText == null || WriteText.IsWhiteSpace())
            {
                ErrorCode("STRING NOT FOUND: ``Text´´ is empty in ``StringToTextLine´´ Method!");
                return;
            }

            if (TextLineLength < WriteText.Count())
            {
                TextLineLength = WriteText.Count();
            }

            int Space = TextLineLength - WriteText.Count();
            Space = Space / 2;

            for (int i = 0; i < Space; i++)
            {
                Console.Write(" ");
            }

            Console.Write($"{WriteText}");

            for (int i = 0; i < Space; i++)
            {
                Console.Write(" ");
            }


        }



        //Create Text Window!
        public static void CreateTextWindow(string WriteText, char LineType, int WindowLength)//Create a text made window in console!
        {

            if (WriteText.Count() > WindowLength + 2)
            {
                WindowLength = WriteText.Count() + 2;
            }

            int Space = WindowLength - WriteText.Count();

            CreateLine(Text.WriteLine, LineType, WindowLength);

            Console.Write("|");
            for (int i = 0; i < WindowLength - 1; i++)
            {
                if (i < Space / 2)
                {
                    Console.Write(" ");
                }
                else if (i == Space / 2)
                {
                    Console.Write(WriteText);
                    i = i + WriteText.Count();
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.Write("|");
            CreateLine(Text.WriteLine, LineType, WindowLength);


        }//



        //Create Title Text!
        public static void CreateTitle(string TitleText, char LineType, int TitleLength)//
        {

            if (TitleText.Count() > TitleLength)
            {
                TitleLength = TitleText.Count();
            }

            int Space = TitleLength - TitleText.Count();

            for (int i = 0; i < TitleLength; i++)
            {
                if (i < Space / 2)
                {
                    Console.Write(LineType);
                }
                else if (i == Space / 2)
                {
                    Console.Write(TitleText);
                    i = i + TitleText.Count();
                }
                else
                {
                    Console.Write(LineType);
                }
            }
            Console.Write("\n");

        }



        //
        public static void CreateTextBox(string stringText, int BoxLength)
        {

        }




    }
}
