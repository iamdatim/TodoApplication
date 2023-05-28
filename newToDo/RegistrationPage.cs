using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using ToDoApp_Methods;

namespace newToDo
{
    internal class RegistrationPage
    {
        public static void Registration(List<User> Users)
        {

            User user = new User();
            Header.HeaderDisplay("Registration Page");

            MenuMessage.DisplayActionMessage("Please enter your Full Name: ");
            string fullname = Console.ReadLine();
            int namevalue;
            while (Validation.EmptyString(fullname) || !Validation.TryParseInt(fullname, out namevalue) || !Validation.IsSpecialCharacter(fullname))
            {
                if (Validation.EmptyString(fullname))
                {
                    MenuMessage.DisplayErrorMessage("Name Shouldn't not be empty", "Please enter a valid Full Name:");
                    fullname = Console.ReadLine();
                }

                else if(!Validation.TryParseInt(fullname, out namevalue))
                {
                    MenuMessage.DisplayErrorMessage("Name Shouldn't not contain number", "Please enter a valid username:");
                    fullname = Console.ReadLine();
                }

                else
                {
                    MenuMessage.DisplayErrorMessage("Name Shouldn't not contain special character", "Please enter a valid username:");
                    fullname = Console.ReadLine();
                }
            }
            Console.Clear();

            Header.HeaderDisplay("Registration Page");
            MenuMessage.DisplayActionMessage("Please enter your username: ");
            string username = Console.ReadLine();

            int value;
            while (Validation.EmptyString(username) || !Validation.TryParseInt(username, out value) || Users.Exists(x => x.Username == username))
            {
                if (Validation.EmptyString(username))
                {
                    MenuMessage.DisplayErrorMessage("Username Shouldn't not be empty", "Please enter a valid username:");
                    username = Console.ReadLine();
                }

                else if (!Validation.TryParseInt(username, out value))
                {
                    MenuMessage.DisplayErrorMessage("Name Shouldn't not contain number", "Please enter a valid username:");
                    username = Console.ReadLine();
                }

                else
                {
                    MenuMessage.DisplayErrorMessage("Username Already Exist", "Please enter another username:");
                    username = Console.ReadLine();
                }
            }
            Console.Clear();

            Header.HeaderDisplay("Registration Page");
            MenuMessage.DisplayActionMessage("Please enter your Email: ");
            string email = Console.ReadLine();
            while (Validation.EmptyString(email) || !Validation.IsValidEmail(email) || Users.Exists(x => x.Email == email))
            {
                if (Validation.EmptyString(email))
                {
                    MenuMessage.DisplayErrorMessage("email Shouldn't not be empty", "Please enter a valid email:");
                    email = Console.ReadLine();
                }

                else if (!Validation.IsValidEmail(email))
                {
                    MenuMessage.DisplayErrorMessage("Not a valid email format", "Please enter a valid email:");
                    email = Console.ReadLine();
                }

                else
                {
                    MenuMessage.DisplayErrorMessage("Email Already Exist", "Please enter another username:");
                    email = Console.ReadLine();
                }
            }
            Console.Clear();

            Header.HeaderDisplay("Registration Page");
            MenuMessage.DisplayActionMessage("Please enter your Password: ");
            string password = Validation.GetMaskedPassword();
            while (Validation.EmptyString(password) || !Validation.IsValidPassword(password))
            {
                if (Validation.EmptyString(password))
                {
                    MenuMessage.DisplayErrorMessage("Password Shouldn't not be empty", "Please enter a valid password:");
                    password = Validation.GetMaskedPassword();
                }

                else if (!Validation.IsValidPassword(password))
                {
                    MenuMessage.DisplayErrorMessage("Password Requiremnet not met, Your Password must contain \nat least 1 Uppercase, Lowercase and Number", "Please enter a valid password:");
                    password = Validation.GetMaskedPassword();
                }
            }

            Header.HeaderDisplay("Registration Page");
            MenuMessage.DisplayActionMessage("Please confirm your Password: ");
            string ConfirmPassword = Validation.GetMaskedPassword();
            while (ConfirmPassword != password)
            {
                MenuMessage.DisplayErrorMessage("Password does not match", "Please enter the correct password:");
                ConfirmPassword = Validation.GetMaskedPassword();
            }



            if (Validation.UserExists(Users, user))
            {
                Console.WriteLine("User already exists!");
            }

            //if(ConfirmPassword != password)
            //{

            //}

            User newUser = user.Register(Users, fullname, username, email, password);

            WriteToJson writeToJson = new WriteToJson();
            writeToJson.WriteToJsons(Users);

            Header.HeaderDisplay("To do List Application");
            MenuMessage.DisplaySucessMessage("Registration Sucessful\n\n");
        }
    }
}
