using System;
using System.Collections.Generic;

namespace Problem4
{
    internal class Problem4
    {
        static void Main()
        {
            var playlist = new List<Song>();

            int count = int.Parse(Console.ReadLine());
            int k = 0;
            string[] input;
            int totalMinutes = 0;
            int totalSeconds = 0;
            int totalHours = 0;
            do
            {
                k++;
                try
                {
                    input = Console.ReadLine().Split(new char[] { ';' });
                    string artist = input[0];
                    string title = input[1];
                    string[] time = input[2].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    int minutes = int.Parse(time[0]);
                    int seconds = int.Parse(time[1]);
                    playlist.Add(new Song(artist, title, minutes, seconds));
                    Console.WriteLine("Song added.");

                    totalMinutes += minutes;
                    totalSeconds += seconds;
                    if (totalSeconds >= 60)
                    {
                        totalSeconds -= 60;
                        totalMinutes += 1;
                    }
                    if (totalMinutes >= 60)
                    {
                        totalMinutes -= 60;
                        totalHours += 1;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (k < count);

            Console.WriteLine("Songs added: " + playlist.Count);
            Console.WriteLine($"Playlist length: {totalHours}h { totalMinutes }m { totalSeconds }s");
            
        }
    }

    public class InvalidSongException : Exception
    {
        string message = "Invalid song.";
        public override string Message => message;
    }
    class InvalidArtistNameException : InvalidSongException
    {
        public override string Message => $"Artist name should be between 3 and 20 symbols.";
    }
    class InvalidSongLengthException : InvalidSongException
    {
        public override string Message => "Invalid song length.";
    }
    class InvalidSongNameException : InvalidSongException
    {
        public override string Message => "Song name should be between 3 and 20 symbols.";
    }
    class InvalidSongMinutesException : InvalidSongLengthException
    {
        public override string Message => "Song minutes should be between 0 and 14";
    }
    class InvalidSongSecondsException : InvalidSongLengthException
    {
        public override string Message => "Song seconds should be between 0 and 59";
    }
    class Song
    {
        string artist;
        string tittle;
        int minutes;
        int seconds;

        public Song(string artist, string title, int minutes, int seconds)
        {
            Artist = artist;
            Title = title;
            Minutes = minutes;
            Seconds = seconds;  
        }

        string Artist
        {
            get { return this.artist; }
            set
            {
                if(value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }                
                this.artist = value;
            }
        }
        string Title
        {
            get { return this.tittle; }
            set
            {
                if (value == null)
                {
                    throw new InvalidSongLengthException();
                }
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidSongNameException();
                }
                this.tittle = value;
            }
        }
        int Minutes
        {
            get { return this.minutes; }
            set
            {
                if(value<0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }
                this.minutes = value;
            }
        }
        int Seconds
        {
            get { return this.seconds; }
            set
            {
                if(value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }
                this.seconds = value;
            }
        }

    }
}
