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
            ValidateName(value, 3, 20, "Artist name");
            artistName = value;
        }
    }

    private string songName;

    public string SongName
    {
        get { return songName; }
        set
        {
            ValidateName(value, 3, 30, "Song name");
            songName = value;
        }
    }

    private int minutes;

    public int Minutes
    {
        get { return minutes; }
        set
        {
            if (value < 0 || value > 14)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }
            minutes = value;
        }
    }

    private int seconds;

    public int Seconds
    {
        get { return seconds; }
        set
        {
            if (value < 0 || value > 59)
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }
            seconds = value;
        }
    }

    public int SongLenghtSeconds
    {
        get => Minutes * 60 + Seconds;
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
        if (args.Length < 3)
        {
            throw new ArgumentException("Invalid song.");
        }
        ArtistName = args[0];
        SongName = args[1];
        
        try
        {
            var splitLenght = args[2].Split(':');
            Minutes = int.Parse(splitLenght[0]);
            Seconds = int.Parse(splitLenght[1]);
        }
        catch(ArgumentException ae)
        {
            throw new ArgumentException(ae.Message);
        }
        catch (Exception)
        {
            throw new ArgumentException("Invalid song length.");
        }
        
    }

    public Song(string songLine) : this(songLine.Split(";")) { }

    private void ValidateName(string name, int minSymbols, int maxSymbols, string argumentName)
    {
        if (name.Length < minSymbols || name.Length > maxSymbols)
        {
            throw new ArgumentException($"{argumentName} should be between {minSymbols} and {maxSymbols} symbols.");
        }        
    }

}
