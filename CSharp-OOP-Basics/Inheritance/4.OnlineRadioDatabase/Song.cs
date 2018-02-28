using System;
using System.Collections.Generic;
using System.Text;

public class Song
{
    private string artistName;

    public string ArtistName
    {
        get { return artistName; }
        set
        {

            artistName = value;
        }
    }

    private string songname;

    public string SongName
    {
        get { return songname; }
        set { songname = value; }
    }

    private int minutes;

    public int Minutes
    {
        get { return minutes; }
        set { minutes = value; }
    }

    private int seconds;

    public int Seconds
    {
        get { return seconds; }
        set { seconds = value; }
    }

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        ArtistName = artistName;
        SongName = songName;
        Minutes = minutes;
        Seconds = seconds;
    }

    public Song(string[] args)
    {

    }

    public Song(string songLine)
    {

    }


    private void ValidateName(string name, int minSymbols, int maxSymbols, string argumentName)
    {
        if (name.Length <= minSymbols)
        {
            throw new ArgumentException($"Expected length at least {minSymbols + 1} symbols! Argument: {argumentName}");
        }
        if (!char.IsUpper(name[0]))
        {
            throw new ArgumentException($"Expected upper case letter! Argument: {argumentName}");
        }
    }

}
