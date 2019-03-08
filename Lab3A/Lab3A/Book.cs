/*
  Class:     Book.cs
  Author:    Jess Nguyen
  Date:      November 05, 2018
  Purpose:   This Book class represents a Book object of a media type. Because it implements the IEncryptable interface, it is able to decrypt the encrypted summary.
  Authorship: I, Jess Nguyen, 000747411 certify that this material is my original work. No other person's work has been used without due acknowledgement.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    public class Book : Media, IEncryptable
    {
        private string Author { get; } // Author of the Book. 
        /// <summary>
        /// 
        /// </summary>
        private string Summary { get; } //The summary of the Book.

        /// <summary>
        /// Constructor sets the 4 properties that all Book objects have
        /// </summary>
        /// <param name="title">The title of the Book object</param>
        /// <param name="year">The year of publication</param>
        /// <param name="author">The author of the Book</param>
        /// <param name="summary">The summary of the Book</param>
        public Book(string title, int year, string author, string summary) : base(title, year)
        {
            Author = author;
            Summary = summary;
        }

        /// <summary>
        /// Encrypts data
        /// </summary>
        /// <returns>NotImplementedException</returns>
        public string Encrypt()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decrypts the summary
        /// </summary>
        /// <returns>normal</returns>
        public string Decrypt()
        {
            string normal = ""; //Variable to hold the decrypted char.
            for (int i = 0; i < Summary.Length; i++) //Loop to go through each letter, space and characters in the summary.
            {                
                if (Summary[i] >= 'a' && Summary[i] <= 'z')//If char is lowercase a-z, check if char is bigger than 'm' to move -13 otherwise +13.
                {
                    if (Summary[i] > 'm')
                    {
                        normal += (char)(Summary[i] - 13);
                    }
                    else
                    {
                        normal += (char)(Summary[i] + 13);
                    }
                }
                else if (Summary[i] >= 'A' && Summary[i] <= 'Z') //If char is uppercase A-Z, check if char is bigger than 'M' to move -13 otherwise +13.
                {
                    if (Summary[i] > 'M')
                    {
                        normal += (char)(Summary[i] - 13);
                    }
                    else
                    {
                        normal += (char)(Summary[i] + 13);
                    }
                }
                else //If it is anything but a letter keep it the char the way it is.
                {
                    normal += Summary[i];
                }
            }
            return normal;
        }

        /// <summary>
        /// Over writes the ToString method of parent class to display information about Book class.
        /// </summary>
        /// <returns>Title, Year, and Author</returns>
        public override string ToString()
        {
            return $"Book Title: {Title,-10} ({Year,4}) \nAuthor: {Author,-20}";
        }
    }
}
