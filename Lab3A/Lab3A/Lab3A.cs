/*
  Class:     Lab3A.cs
  Author:    Jess Nguyen
  Date:      November 05, 2018
  Purpose:   To read data.txt file, process list of media, and to show display menu.
  Authorship: I, Jess Nguyen, 000747411 certify that this material is my original work. No other person's work has been used without due acknowledgement.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab3A
{
    class Lab3A
    {
        /// <summary>
        /// Reads data.txt file and process list of media then closes application.
        /// </summary>
        /// <param name="args">Receive command lines</param>
        static void Main(string[] args)
        {
            List<Media> entertainments = ReadData();
            Process(entertainments);
            return;
        }

        /// <summary>
        /// Processing the list of media object to be outputed for display and displays menu.
        /// </summary>
        /// <param name="entertainments"> List of Media objects</param>
        private static void Process(List<Media> entertainments)
        {
            bool exitEnter = false; //Boolean to know if user wants to exit the program.

            //While the user still wants to user the program, the boolean exitEnter is false.
            while (exitEnter == false)
            {
                DisplayMenu();
                try //try to convert string into integer, otherwise output message and try again.
                {
                    string userInput = Console.ReadLine(); // Get the user's input and assign it to userInput.          
                    switch (Convert.ToInt32(userInput))//Finds out which option the user input.
                    {
                        case 1://lists all books
                            foreach (Media m in entertainments)
                            {
                                if (m is Book ) {
                                    Console.WriteLine(m.ToString() + "\n--------------------");
                                }
                            }
                            break;
                        case 2://lists all movies
                            foreach (Media m in entertainments)
                            {
                                if (m is Movie)
                                {
                                    Console.WriteLine(m.ToString() + "\n--------------------");
                                }
                            }
                            break;
                        case 3://lists all songs
                            foreach (Media m in entertainments)
                            {
                                if (m is Song)
                                {
                                    Console.WriteLine(m.ToString() + "\n--------------------");
                                }
                            }
                            break;
                        case 4://lists all media
                            foreach (Media m in entertainments)
                            {                                
                                Console.WriteLine(m.ToString() + "\n--------------------");                                
                            }
                            break;
                        case 5://search through all media
                            Console.WriteLine("Please enter a search key: ");
                            string query = Console.ReadLine();//Gets the search key from user and sets as query variable.
                            foreach (Media m in entertainments)//for each media in entertainments check if it matches query and then find out what kind of media it is to display information.
                                if (m.Search(query))
                                {
                                    if (m is Book)
                                    {
                                        Console.WriteLine(m.ToString() + "\n" + ((Book)m).Decrypt() + "\n--------------------");//display title, author, year and decrypted summary.
                                    }
                                    else if (m is Movie)
                                    {
                                        Console.WriteLine(m.ToString() + "\n" + ((Movie)m).Decrypt() + "\n--------------------");//display title, director, year and decrypted summary.
                                    }
                                    else if (m is Song)
                                    {
                                        Console.WriteLine(((Song)m).ToString() + "\n--------------------");//display title, artist, year, and album.
                                    }
                                }
                            break;
                        case 6:                            
                            exitEnter = true;//Set exit boolean to true to close application.
                            break;
                        default:
                            Console.WriteLine("*** Invalid Choice - Try Again ***");//Display Message if user puts in a number that isn't from 1-6.
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DisplayMenu()
        {
            //Display menu            
            Console.WriteLine("Jess's Media Collection " +
           "\n=======================" +
           "\n1. List All Books" +
           "\n2. List All Movies" +
           "\n3. List All Songs" +
           "\n4. List All Media" +
           "\n5. Search All Media by Title" +
           "\n6. Exit Program");
            Console.WriteLine("Enter your choice: "); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static List<Media> ReadData()
        {
            StreamReader data = new StreamReader("data.txt"); // Connect stream reader to data.txt to get media list.
            List<Media> entertainments = new List<Media>(); // Create a List of Media objects called entertainments.

            string record; // Variable to hold the lines of data in data.txt

            while ((record = data.ReadLine()) != null)//while record isn't null do the following.
            {
                string[] exploded = record.Split('|'); //Divide the document into strings when there is a |

                string summary = ""; //Variable to hold the summary.
                do //do the following while the lines isn't ----- to know that there is a summary.
                {
                    record = data.ReadLine();  //Assign data line to record.
                    if (record != "-----") //if record isn't ----- then it is a summary.
                    {
                        summary += record;
                    }
                    else //otherwise it isn't a summary.
                    {
                        summary += "\n";
                    }
                } while (record != "-----");

                if (exploded[0].Equals("BOOK")) // if the type of media is BOOK then create a Book object.
                {
                    entertainments.Add(new Book(exploded[1], Convert.ToInt32(exploded[2]), exploded[3], summary));
                }
                else if (exploded[0].Equals("MOVIE")) //if the type of media is MOVIE then create a Movie object.
                {
                    entertainments.Add(new Movie(exploded[1], Convert.ToInt32(exploded[2]), exploded[3], summary));
                }
                else if (exploded[0].Equals("SONG")) //if the type of media is SONG then create a Song object.
                {
                    entertainments.Add(new Song(exploded[1], Convert.ToInt32(exploded[2]), exploded[3], exploded[4]));
                }
            }

            data.Close();//Close the data stream.
            return entertainments; //return media list.
        }
    }
}
