# Music-Player
 Console based music player.

# Introduction

This app is made for example of my .Net C# console app knowledge. It's simple program made to play your music with minimum system load in most intuitive way, the console app can. Music player have implemententation typical for graphic based players functions, like playlist, and auto-loop. App don't need to be installed, just generate .exe file and put the .wav format music in same location. Voilà! It's that simple!

![](example.gif)

# Technologies

App is programmed in C# language, based on .Net framework in version 4.7.1, for correct working i recommend update/ install minimum this version. Libraries used in project:
* Text.RegularExpressions (C# built in library for choosing format to operate on)
* IO (C# built in library for operate on systems directory)
* Windows.Media (C# library for reading music format)
* NAudio (open source library: [Author's Page](https://github.com/naudio/NAudio) for open music formats in app)

# Setup

### Download release file:

* Download [zip](https://www115.zippyshare.com/v/py4FkzmJ/file.html)
* Unrar folder
* Run Music Player.exe in folder
* follow instructions on screen
* You can put your music in MyMusic folder (use .wav format)

### Compile file by yourself (requires Visual Studio):

* On repository screen select Download>Open in Visual Studio
* Download NUGET package NAudio
* In Visual Studio press **Compile**
* App automatically creates MyMusic folder in Music Player/bin/debug - put your music in .wav format there
* follow instructions on screen

# Features

Application have full player functionality like:
* Play songs from choosen seconds
* Play songs in repeat mode
* Create and manage playlist

# Motivation

Application was created as a passing project for study. Main goal behind app was to create Music Player witch can play songs in background without using as minimum system resources ass possible. Second goal was to make application simulate graphic interface for accessibility. Lastly it helped me to improve my skills in using classes and libraries.

# Others
### Report Bug and improves

You can report encountered bugs or send ideas for improvement [here](https://github.com/TomaszOrpik/Music-Player/issues/new)

### License

Application was uploaded under GENERAL PUBLIC LICENSE for more information [check license file](https://github.com/TomaszOrpik/Music-Player/blob/master/LICENSE)

### Contact

Feel free to [Contact me!](https://github.com/TomaszOrpik)
