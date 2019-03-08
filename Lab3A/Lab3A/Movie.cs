/*
  Class:     Movie.cs
  Author:    Jess Nguyen
  Date:      November 05, 2018
  Purpose:   This Movie class represents a Movie object of a media type. Because it implements the IEncryptable interface, it is able to decrypt the encrypted summary.
  Authorship: I, Jess Nguyen, 000747411 certify that this material is my original work. No other person's work has been used without due acknowledgement.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    public class Movie : Media, IEncryptable
    {
        private string Director { get; }// Director of the Movie.         
        private string Summary { get; }//The summary of the Movie.

        /// <summary>
        /// Constructor sets the 4 properties that all Movie objects have
        /// </summary>
        /// <param name="title">The title of the Movie object</param>
        /// <param name="year">The year of release</param>
        /// <param name="director">The Director of the Movie</param>
        /// <param name="summary">The summary of the Movie</param>
        public Movie(string title, int year, string director, string summary) : base(title, year)
        {
            Director = director;
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
        /// Over writes the ToString method of parent class to display information about Movie class.
        /// </summary>
        /// <returns>Title, Year, and Director</returns>
        public override string ToString()
        {
            return $"Movie Title: {Title,-10} ({Year,4}) \nDirector: {Director,-20}";
        }
    }
}
