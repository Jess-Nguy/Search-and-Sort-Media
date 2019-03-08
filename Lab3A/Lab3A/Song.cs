/*
  Class:     Song.cs
  Author:    Jess Nguyen
  Date:      November 05, 2018
  Purpose: .
  Authorship: I, Jess Nguyen, 000747411 certify that this material is my original work. No other person's work has been used without due acknowledgement.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
   
    public class Song : Media, IEncryptable
    {        
        private string Album { get; }//Album the Song is from. 
        
        private string Artist { get; }//Artist of the Song. 

        /// <summary>
        /// Constructor sets the 4 properties that all Song objects have
        /// </summary>
        /// <param name="title">The title of the Song object</param>
        /// <param name="year">The year of release</param>
        /// <param name="album">The album the song is from</param>
        /// <param name="artist">The artist of the song</param>
        public Song(string title, int year, string album, string artist) : base(title, year)
        {
            Artist = artist;
            Album = album;
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
        /// Decrypts data
        /// </summary>
        /// <returns>NotImplementedException</returns>
        public string Decrypt()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Over writes the ToString method of parent class to display information about Song class.
        /// </summary>
        /// <returns>Title, Year, Album, and Artist</returns>
        public override string ToString()
        {
            return $"Title: {Title,-15} Year: {Year,4} \nAlbum: {Album,-5} \t Artist: {Artist}";
        }
    }
}
