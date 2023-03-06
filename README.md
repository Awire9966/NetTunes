# NetTunes
Have you ever opened up itunes and said: "Wouldnt it be nice if I could Control it through a websocket so I can use it with a rasberry pi for a party?"
Okay you probably didnt say that but yes that is a thing. And its possible with NetTunes.
## A Few Notes
1. Before going any further, you need to create a playlist of the songs you want to use. The `SelectPlay' Command Only accepts Playlist names.
2. This is sadly not for mac. Due to Apple's Over-the-top security, this software is not, and most likely will never be mac compatible.
3. This software uses [Sta's WebSocketSharp](https://github.com/sta/websocket-sharp) API. You might want to look into that before writing your own programs.
## Commands
To Send commands, connect to the pc's IP by port `20019` (Fun fact: This was the day itunes was created, The 9th day of 2001, or Jan 9, 2001.)
To send arguments to a command, use the following unicode character instead of a space:
```
»
```
Below are several Commands that can be sent to your computer while NetTunes is running.
```
selectplay : Play a playlist by it's name : selectplay»My Super Cool Playlist
pause : Pause the current Track
stop : Stops the current track.
prevtrack : Go back to the previous song.
nexttrack : Go to the next song.
volume : Set the volume : volume»75
resume : Resumes the Current Track if it has been paused.

```

