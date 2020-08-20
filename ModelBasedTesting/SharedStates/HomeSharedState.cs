using OpenQA.Selenium;
using FluentAssertions;
using System.Collections;
using ModelBasedTesting.Helpers;

namespace ModelBasedTesting.SharedStates
{
    public class HomeSharedState
    {
        public void e_Logout()
        {
            System.Console.WriteLine("      Executing the action e_Logout");
        }

        public void v_HomePage()
        {
            System.Console.WriteLine("      Testing the v_HomePage");
        }

        public void v_LoginPage()
        {
            System.Console.WriteLine("      Testing the v_LoginPage");
        }

    }
}