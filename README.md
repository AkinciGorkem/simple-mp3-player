# MP3 Player in C# WinForms

This MP3 Player is a simple application developed using C# and WinForms. It allows you to load, play, pause, stop, and shuffle MP3 files. You can also set a repeat mode to repeat one song or all songs.

## Features
1. **Load MP3 files:** The application automatically loads MP3 files from a predefined directory at startup.
2. **Play MP3 files:** You can play a song by selecting it from the list and pressing the play button.
3. **Pause MP3:** The application allows you to pause the current song.
4. **Stop MP3:** You can stop the current song at any time.
5. **Shuffle songs:** You can shuffle the songs in the list.
6. **Repeat mode:** You can set the player to repeat the current song or all songs.

## How to Use
1. Clone this repository to your local machine.
2. Open the solution in Visual Studio.
3. Build and run the solution.
4. The MP3 files should be in a directory named "Musics" at the root directory of the application.
5. Use the GUI to control the player.

## Function Descriptions
- **LoadMP3Files:** Loads all MP3 files from the given directory into a list.
- **DisplayMP3FilesInListBox:** Displays the loaded MP3 files in a ListBox.
- **PlayMP3:** Plays the selected MP3 file.
- **PauseMP3:** Pauses the currently playing MP3 file.
- **StopMP3:** Stops the currently playing MP3 file.
- **NextSong:** Plays the next song in the list, depending on the repeat mode.
- **PreviousSong:** Plays the previous song in the list, depending on the repeat mode.
- **ShuffleSongs:** Shuffles the song list.
- **PlaySelectedSong:** Plays the song selected in the ListBox.

## Technical Details
The application uses the `winmm.dll` library to control media playback. It also uses the `TagLib` library to get song durations.

## Dependencies
- .NET Framework
- TagLib

## License
This project is licensed under the terms of the MIT license.
