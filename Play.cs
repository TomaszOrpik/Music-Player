using NAudio.Wave;
using System;
using System.IO;

namespace Music_Player
{
    class Song
    {

        string _SongName;
        int _Time;
        string _SongPath;
        int _SongLenght;

        /// INITIALIZES SONG PLAYER (NAUDIO)
        WaveOutEvent WOE;
        MediaFoundationReader MFR;

        public Song(string songName, int time = 0)
        {
            /// MAKES SONG NAME INTO COMPLETE DIRECTORY
            _SongName = songName;
            _Time = time;

            _SongPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\MyMusic\\" + songName;
            _SongLenght = SongInfo.GetSoundLength(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\MyMusic\\" + songName);
            WOE = new WaveOutEvent();
            MFR = new MediaFoundationReader(_SongPath);
            MFR.CurrentTime = TimeSpan.FromSeconds(_Time);
            WOE.Init(MFR);
            
        }

        public void Play()
        {
            Console.CursorVisible = false; /// HIDE CURSOR
            WOE.Play(); /// PLAY SONG FUNCTION
            do
            {
                while (_Time <= _SongLenght && !Console.KeyAvailable)  ///SET COUNTING LENGHT
                {
                    /// INITIALIZE COUNTER
                    int dwStartTime = System.Environment.TickCount;

                    while (true)
                    {
                        if (System.Environment.TickCount - dwStartTime > 1000) break; /// REFRESH COUNTER AFTER 1000 MILISECONDS 
                    }

                    _Time++;
                    /// CONVERTS AKTUAL TIME AND SONG LENGHT INTO MIN:SEC FORMAT
                    int currentSeconds = _Time % 60;
                    int currentMinutes = _Time / 60;

                    int maxSeconds = this._SongLenght % 60;
                    int maxMinutes = this._SongLenght / 60;
                    /// DISPLAYS SONG TIME
                    Console.WriteLine("Playing:  " + _SongName + " " + currentMinutes + ":" + currentSeconds.ToString("00") + "/" + maxMinutes + ":" + maxSeconds.ToString("00"));
                    /// DISPLAYS PROGRESS BAR
                    switch (_Time)
                    {
                        case int now when (now <= ((3 * _SongLenght) / 100)):
                            Console.WriteLine("|<>---------------------------------|");
                            break;
                        case int now when (now <= ((6 * _SongLenght) / 100)):
                            Console.WriteLine("|-<>--------------------------------|");
                            break;
                        case int now when (now <= ((9 * _SongLenght) / 100)):
                            Console.WriteLine("|--<>-------------------------------|");
                            break;
                        case int now when (now <= ((12 * _SongLenght) / 100)):
                            Console.WriteLine("|---<>------------------------------|");
                            break;
                        case int now when (now <= ((15 * _SongLenght) / 100)):
                            Console.WriteLine("|----<>-----------------------------|");
                            break;
                        case int now when (now <= ((18 * _SongLenght) / 100)):
                            Console.WriteLine("|-----<>----------------------------|");
                            break;
                        case int now when (now <= ((21 * _SongLenght) / 100)):
                            Console.WriteLine("|------<>---------------------------|");
                            break;
                        case int now when (now <= ((24 * _SongLenght) / 100)):
                            Console.WriteLine("|-------<>--------------------------|");
                            break;
                        case int now when (now <= ((27 * _SongLenght) / 100)):
                            Console.WriteLine("|--------<>-------------------------|");
                            break;
                        case int now when (now <= ((30 * _SongLenght) / 100)):
                            Console.WriteLine("|---------<>------------------------|");
                            break;
                        case int now when (now <= ((33 * _SongLenght) / 100)):
                            Console.WriteLine("|----------<>-----------------------|");
                            break;
                        case int now when (now <= ((36 * _SongLenght) / 100)):
                            Console.WriteLine("|-----------<>----------------------|");
                            break;
                        case int now when (now <= ((39 * _SongLenght) / 100)):
                            Console.WriteLine("|------------<>---------------------|");
                            break;
                        case int now when (now <= ((42 * _SongLenght) / 100)):
                            Console.WriteLine("|-------------<>--------------------|");
                            break;
                        case int now when (now <= ((45 * _SongLenght) / 100)):
                            Console.WriteLine("|--------------<>-------------------|");
                            break;
                        case int now when (now <= ((48 * _SongLenght) / 100)):
                            Console.WriteLine("|---------------<>------------------|");
                            break;
                        case int now when (now <= ((51 * _SongLenght) / 100)):
                            Console.WriteLine("|----------------<>-----------------|");
                            break;
                        case int now when (now <= ((54 * _SongLenght) / 100)):
                            Console.WriteLine("|-----------------<>----------------|");
                            break;
                        case int now when (now <= ((57 * _SongLenght) / 100)):
                            Console.WriteLine("|------------------<>---------------|");
                            break;
                        case int now when (now <= ((60 * _SongLenght) / 100)):
                            Console.WriteLine("|-------------------<>--------------|");
                            break;
                        case int now when (now <= ((63 * _SongLenght) / 100)):
                            Console.WriteLine("|--------------------<>-------------|");
                            break;
                        case int now when (now <= ((66 * _SongLenght) / 100)):
                            Console.WriteLine("|---------------------<>------------|");
                            break;
                        case int now when (now <= ((69 * _SongLenght) / 100)):
                            Console.WriteLine("|----------------------<>-----------|");
                            break;
                        case int now when (now <= ((72 * _SongLenght) / 100)):
                            Console.WriteLine("|-----------------------<>----------|");
                            break;
                        case int now when (now <= ((75 * _SongLenght) / 100)):
                            Console.WriteLine("|------------------------<>---------|");
                            break;
                        case int now when (now <= ((78 * _SongLenght) / 100)):
                            Console.WriteLine("|-------------------------<>--------|");
                            break;
                        case int now when (now <= ((81 * _SongLenght) / 100)):
                            Console.WriteLine("|---------------------------<>------|");
                            break;
                        case int now when (now <= ((84 * _SongLenght) / 100)):
                            Console.WriteLine("|----------------------------<>-----|");
                            break;
                        case int now when (now <= ((87 * _SongLenght) / 100)):
                            Console.WriteLine("|-----------------------------<>----|");
                            break;
                        case int now when (now <= ((90 * _SongLenght) / 100)):
                            Console.WriteLine("|------------------------------<>---|");
                            break;
                        case int now when (now <= ((93 * _SongLenght) / 100)):
                            Console.WriteLine("|-------------------------------<>--|");
                            break;
                        case int now when (now <= ((96 * _SongLenght) / 100)):
                            Console.WriteLine("|--------------------------------<>-|");
                            break;
                        case int now when (now <= ((99 * _SongLenght) / 100)):
                            Console.WriteLine("|---------------------------------<>|");
                            break;
                        default:
                            Console.WriteLine("|---------------------------------<>|");
                            break;
                    }

                    if ((System.Environment.TickCount - dwStartTime > 1000))
                    {
                        /// RESET CURSOR POSITION AFTER 1000 MILISECONDS
                        Console.SetCursorPosition(0, Console.CursorTop - 2);
                    }
                }
            } while (false || Console.ReadKey(true).Key != ConsoleKey.Enter);
        }

        public void Stop()
        {
            WOE.Stop(); /// STOP SONG FUNCTION
            WOE.Dispose(); /// DISPOSE SONG FROM NAUDIO
            Clear();
        }

        public void Clear()
        {
            /// CLEARS THE LINES AFTER LOOP FINISH
            Console.Write(new string(' ', Console.WindowWidth));
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 2);
            Console.CursorVisible = true;
        }
    }
    
}
