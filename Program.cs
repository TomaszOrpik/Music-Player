using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace Music_Player
{
    class Program
    {
        static int _SongIndex = 1; /// SORTED LIST INDEX
        static SortedList _SongsSList = new SortedList(); /// CREATE SORTED LIST
        static Song _Song;  /// INITIALIZE SONG OBJECT
        static int numberOfSongs;  /// COUNTS NUMBER OF ELEMENTS IN LIST
        static List<string> _SongsPlaylist = new List<string>(); /// DEFINE LIST OF SONGS FOR PLAYLIST MENU

        static void Main(string[] args)
        {
            string folder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\MyMusic\\";
            bool exists = System.IO.Directory.Exists(folder);

            if (!exists)
                System.IO.Directory.CreateDirectory(folder);

            /// PRINT WELCOME SCREEN
            Console.WriteLine("Welcome to Music Player 0.9 !" + Environment.NewLine +
                "Please insert all your music in .wav format to folder 'MyMusic' in the same direction as .exe file." + Environment.NewLine +
                "Press any key to start");

            Console.ReadKey();
            /// CREATES SORTED LIST
            Console.WriteLine("Song list: ");

            InsertSongsIntoSL();
            
            /// PRINTS SORTED LIST
            for (int i = 0; i < _SongsSList.Count; i++)
            {
                Console.WriteLine("{0}:\t{1}", _SongsSList.GetKey(i),
                                          _SongsSList.GetByIndex(i));
            }
            /// OPENS SONG MENU FUNCTION
            SongMenu();
        }

        static void SongMenu()
        {
            Console.WriteLine("Choose Song and confirm with [Enter] Key" + Environment.NewLine
                + "Input any letter and confirm with [Enter] if you want jump to create Playlist!");

            /// READS INPUT KEY
            int input;
            bool parsedSuccessfully = int.TryParse(Console.ReadLine(), out input); /// TRY TO CONVERT INPUT TO INT

            if (parsedSuccessfully == false)
            {
                /// CHECKS IF INPUT IS INT OR CHAR (OPENS THE PLAYLIST MENU WHEN CHAR)
                ResetLines(1);
                PlaylistMenu();
            }
            if (input > _SongIndex)
            {
                /// CHECKS IF SONG NUMBER EXIT IN SONG LIST
                ResetLines(2);
                Console.WriteLine("Invalid song number! Type number from the list above!");
                SongMenu();
            }
            /// CONVERTS CHOOSEN NUMBER TO SONG NAME
            string songName = Convert.ToString(_SongsSList.GetByIndex(input-1));
           
            /// PRINTS THE SONG MENU
            Console.WriteLine("Song Menu (choose option with button): " + Environment.NewLine
                + "Press [p] to play song" + Environment.NewLine
                + "Press [t] to play song from choosen second" + Environment.NewLine
                + "Press [o] to play song in repeat mode" + Environment.NewLine
                + "Press [c] to cancel song choose" + Environment.NewLine
                + "Press [q] to leave program" + Environment.NewLine
                );

            bool knownKeyPressed = false;
            do
            {
                /// READS ONLY KEYS THAT ARE REQUIRED
                ConsoleKeyInfo menuselection;
                menuselection = Console.ReadKey(true);

                switch (menuselection.KeyChar)
                {
                    case 'p':
                        /// PLAYS SONG
                        Console.WriteLine("Press [enter] button to stop the song");

                        _Song = new Song(songName);
                        _Song.Play(); /// PLAY THE SONG

                        /// CLEAR CONSOLE AFTER SONG END
                        ResetLines(11);
                        _Song.Stop();
                        SongMenu();
                        break;

                    case 't':
                        /// WAITS FOR INT
                        int choosenTime;
                        Console.WriteLine("Input the second you want start song from:");
                        bool parsedTimeSuccessfully = int.TryParse(Console.ReadLine(), out choosenTime);

                        if (parsedTimeSuccessfully == false)
                        {
                            /// CHECKS IF INPUT IS INT
                            ResetLines(11); ///poprawić od tego momentu
                            Console.WriteLine("Type a number!");
                            SongMenu();
                        }
                        if (choosenTime >= SongInfo.GetSoundLength(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\MyMusic\\" + songName))
                        {
                            /// CHECKS IF INPUT IS NOT BIGGER THEN SONG LENGTH
                            ResetLines(11);
                            Console.WriteLine("Entered time must be lower than song length!");
                            SongMenu();
                        }
                        /// PLAYS SONG FROM CHOOSEN SECOND (TIME)
                        Console.WriteLine("Press [enter] button to stop the song");
                        _Song = new Song(songName, choosenTime);
                        _Song.Play();
                        ResetLines(13);

                        _Song.Stop();
                        SongMenu();
                        break;

                    case 'o':

                        Console.WriteLine("Press Enter to stop playing song in repeat mode!");
                        _Song = new Song(songName);
                        /// LOOP THE SONG PLAYING FUNCTION
                         _Song.Play();
                        _Song.Stop();
                        ResetLines(11);
                        SongMenu();
                        break;

                    case 'c':
                        ResetLines(10);
                        SongMenu();
                        break;

                    case 'q':
                        /// QUITS THE CONSOLE WINDOW
                        Environment.Exit(0);
                        break;

                }
            } while (!knownKeyPressed);
            Console.WriteLine("Invalid key, choose one from options listed above!");
            SongMenu();
        }
        /// CREATES THE SONGS QUEUE
        static void PlaylistMenu()
        {
            /// DISPLAYS PLAYLIST MENU
            Console.WriteLine("Playlist Menu (choose option with button) :" + Environment.NewLine
                + "Press [a] to add song to Playlist" + Environment.NewLine
                + "Press [d] to delete song from Playlist" + Environment.NewLine
                + "Press [p] to play Playlist" + Environment.NewLine
                + "Press [e] to exit Playlist Menu");

            bool knownKeyPressed = false;
            do
            {
                /// READS ONLY KEYS THAT ARE REQUIRED
                ConsoleKeyInfo menuselection = Console.ReadKey(true);
                string choosenSong;

                switch (menuselection.KeyChar)
                {
                    case 'a':
                        /// WAITS FOR SONG NUMBER
                        Console.WriteLine("Choose song number and confirm with [Enter] key!");

                        bool parsedSuccessfully = int.TryParse(Console.ReadLine(), out int songNumber);

                        if (parsedSuccessfully == false)
                        {
                            /// CHECKS IF INPUT IS INTEGER
                            ResetLines(2);
                            Console.WriteLine("Please enter a number!");
                            break;
                        }
                        if (songNumber > _SongsSList.Count)
                        {
                            /// CHECKS IF INPUT EXIST IN THE SORTED LIST
                            ResetLines(2);
                            Console.WriteLine("Invalid song number! Type number from the list above!");
                            break;
                        }
                        ResetLines(8);
                        /// CONVERTS INDEX TO STRING SONG NAME
                        choosenSong = _SongsSList.GetByIndex(songNumber - 1).ToString();
                        numberOfSongs++;
                        /// ADDS SONG TO LIST
                        _SongsPlaylist.Add(choosenSong);

                        /// WRITES CURRENT LIST
                        Console.WriteLine("Your current Playlist (" + (numberOfSongs) + " songs):");
                        foreach (string song in _SongsPlaylist)
                        {
                            Console.WriteLine(song);
                        }
                        Console.SetCursorPosition(0, Console.CursorTop - (numberOfSongs));
                        PlaylistMenu();
                        break;
                    case 'd':
                        /// WAITS FOR SONG NUMBER
                        Console.WriteLine("Choose song number and confirm with [Enter] key!");
                        
                        bool parsedSuccessfully1 = int.TryParse(Console.ReadLine(), out songNumber);

                        if (parsedSuccessfully1 == false)
                        {
                            /// CHECKS IF INPUT IS INTEGER
                            ResetLines(2);
                            Console.WriteLine("Please enter a number!");
                            break;
                        }

                        if (songNumber > numberOfSongs)
                        {
                            /// CHECKS IF INPUT EXIST IN THE SORTED LIST
                            ResetLines(2);
                            Console.WriteLine("Invalid song number! Type number from the list above!");
                            break;
                        }
                        /// CONVERTS INDEX TO STRING SONG NAME
                        choosenSong = (_SongsSList.GetByIndex(songNumber - 1).ToString());
                        numberOfSongs--;
                        /// DELETE SONGS FROM THE LIST
                        _SongsPlaylist.Remove(choosenSong);

                        /// WRITES CURRENT LIST
                        Console.WriteLine("Your current Playlist (" + (numberOfSongs) + " songs):");
                        foreach (string song in _SongsPlaylist)
                        {
                            Console.WriteLine(song);
                        }
                        Console.SetCursorPosition(0, Console.CursorTop - numberOfSongs);
                        ResetLines(8);
                        PlaylistMenu();
                        break;
                    case 'p': //dodać reset line
                        /// PRINTS CURRENT QUEUE
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        Console.WriteLine("Your current Playlist (" + numberOfSongs + " songs):");
                        foreach (string song in _SongsPlaylist)
                        {
                            Console.WriteLine(song);
                        }

                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        Console.WriteLine("Press Enter to stop playing Playlist!");
                        do
                        {
                            /// PLAYS EVERY ELEMENT IN SONGS QUEUE USING "One Song Loop" CLASS
                            foreach (string song in _SongsPlaylist)
                            {
                                _Song = new Song(song);
                                _Song.Play();
                                _Song.Stop();
                            }
                        } while (Console.ReadKey(true).Key != ConsoleKey.Enter);

                        Console.SetCursorPosition(0, Console.CursorTop - (numberOfSongs + 4));
                        foreach (string song in _SongsPlaylist)
                        {
                            ResetLines(1);
                        }
                        ResetLines(4+numberOfSongs);
                        PlaylistMenu();
                        break;
                    case 'e': //dodać reset line
                        /// EXITS PLAYLIST MENU
                        ResetLines(8);
                        foreach (string song in _SongsPlaylist)
                        {
                            ResetLines(1);
                        }
                        SongMenu();
                        break;
                }
            } while (!knownKeyPressed);
            ResetLines(9);
            PlaylistMenu();
        }

        /// CREATES SORTED LIST
        static void InsertSongsIntoSL()
        {
            /// CREATES ARRAY OF FILES IN MYMUSIC FOLDER
            string[] files = Directory.GetFiles(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\MyMusic\\");
            /// SEARCH IN ARRAY FOR .WAV FILES
            foreach (string file in files)
            {
                Match match = Regex.Match(file, @".wav", RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    /// ADDS .WAV FILES TO SORTED LIST
                    _SongsSList.Add(_SongIndex, Path.GetFileName(file));
                    _SongIndex++;
                }
            }
        }

        static void ResetLines(int linesToReset)
        {
            Console.SetCursorPosition(0, Console.CursorTop - linesToReset);
            for (int i = 0; i < linesToReset; i++)
                Console.Write(new string(' ', Console.WindowWidth));

            Console.SetCursorPosition(0, Console.CursorTop - linesToReset);
        }
    }

}

