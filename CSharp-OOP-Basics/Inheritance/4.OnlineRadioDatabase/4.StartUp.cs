using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var songs = new List<Song>();
        int number = int.Parse(Console.ReadLine());
        for (int i = 0; i < number; i++)
        {
            try
            {
                var song = new Song(Console.ReadLine());
                songs.Add(song);
                Console.WriteLine("Song added.");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        var totalSeconds = songs.Select(x => x.SongLenghtSeconds).Sum();
        Console.WriteLine($"Songs added: {songs.Count}");
        Console.WriteLine("Playlist length: " + SecondsToString(totalSeconds));
    }

    public static string SecondsToString(int totalSeconds)
    {
        var seconds = totalSeconds % 60;
        var minutes = ((totalSeconds - seconds) / 60) % 60;
        var hours = (totalSeconds - seconds - minutes * 60) / 3600;

        return $"{hours}h {minutes}m {seconds}s";
    }
}