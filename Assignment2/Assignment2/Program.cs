/*
* Course: Web Programming 3
* Assessment: 	Assignment 2
* Created by: 	Yorick-Ntwari Niyonkuru
* Date: 		25 September 2022
* Class Name: 	Course.cs
* Description: Runs the SchoolViewModel that allows the user to view Student and Staff data and output certain queries to a txt file. 
    */

using System;
using System.Collections.Generic;
using static System.Console;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {

            SchoolViewModel vm = new SchoolViewModel();
            do
            {
                // Keep returning to main menu until user decides to exit
                vm.WelcomeMessage();
                vm.PromptUserSelection();
                vm.RunCurrentSelection();

                // Clear the console
                Clear();
            } while (vm.currentSelection != SchoolViewModel.Selection.Exit);

        }
    }
}
