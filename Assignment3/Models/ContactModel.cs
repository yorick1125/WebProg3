/*
    Course: Web Programming 3
    Assessment: Assignment 3
    Created by: Yorick-Ntwari Niyonkuru
    Date:  12 November 2022
    Class Name: ContactModel.cs
*/

using Assignment3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment3.Models
{
    public class ContactModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "First Name cannot contain numbers. ")]
        [Display(Name ="First Name")]
        [MaxLength(50, ErrorMessage = "First Name can only be maximum 50 letters long. ")]
        [MinLength(2, ErrorMessage = "First Name can only be minimum 2 letters long. ")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "Last Name cannot contain numbers. ")]
        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "Last Name can only be maximum 50 letters long. ")]
        [MinLength(2, ErrorMessage = "Last Name can only be minimum 2 letters long. ")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        // https://stackoverflow.com/questions/1146202/canadian-postal-code-validation
        [RegularExpression("[ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy][0-9][ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvwxyz] ?[0-9][ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvwxyz][0-9]", ErrorMessage = "Error! Must be a valid postal code (X1X 1X1).")]
        [Display(Name = "PostalCode")]
        public string PostalCode { get; set; }
        

        [Required]
        // https://stackoverflow.com/questions/44673600/regex-to-restrict-special-characters-in-the-beginning-of-an-email-address
        [DataType(DataType.EmailAddress)]
        [MaxLength(50, ErrorMessage = "Email can only be maximum 50 letters long. ")]
        [MinLength(2, ErrorMessage = "Email can only be minimum 2 letters long. ")]
        //[RegularExpression(@" ^[^\W_](?:[\w.-] *[^\W_])?@(?:\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{ 1,3}\.| (?:[\w -] +\.)+)(?:[a - zA - Z]{ 2,3}|[0 - 9]{ 1,3})\]? ", ErrorMessage = "Please enter a valid email address. ")]
        [RegularExpression(@".*@.*\.\w{2,}", ErrorMessage = "Please enter a valid email address. ")]
        public string Email { get; set; }

        [Required]
        public string Topic { get; set; }

        public static List<string> Topics 
        {
            get 
            {
                List<string> topics = new List<string>();
                topics.Add("My order");
                topics.Add("Feedback");
                topics.Add("Product questions");
                topics.Add("Customer Service and feedback");
                topics.Add("Technical questions, specifications, geometry, sizing and historical information");
                topics.Add("Warranty");
                topics.Add("Registration");
                topics.Add("Catalogue requests");
                topics.Add("Owner's manuals");
                topics.Add("Media enquiries");
                topics.Add("Sponsorship and donations");


                return topics;
            }
        }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone. ")]
        public string Phone { get; set; }



        [Required]
        [DataType(DataType.MultilineText)]
        [MaxLength(300)]
        public string Comments { get; set; }

        public DateTime CreationDate { get; set;  }


    }
}
