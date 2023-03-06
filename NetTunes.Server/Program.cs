using iTunesLib;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Net;
using System.Web;
using System.Net.Sockets;

namespace NetTunes.Server
{
    public static class vars
    {
       public static iTunesApp iTunes = new iTunesApp();
       public static WebSocketServer wssv = new WebSocketServer(20019);

    }
    internal class Program
    {
       
        static void Main(string[] args)
        {
             

            Console.WriteLine("Created by AWIRE9966 on github.");
            //The actual code.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("DO NOT HIT THE 'X' TO CLOSE OUT OF THIS WINDOW. PRESS THE 'F4' KEY TO CLOSE.");
            Console.ResetColor();
            Console.WriteLine("Use this device's ip to connect any devices to this server.");
            Console.WriteLine("AirPlay Devices are supported. Go into the newly created itunes window and set the output to what you want it to be.");
            vars.wssv.AddWebSocketService<Controller>("/cmd");
            vars.wssv.Start();
            var keypressed = Console.ReadKey(true);
            
            if(keypressed.Key == ConsoleKey.F4)
            {
                vars.wssv.Stop();
                vars.iTunes.Stop();
                return;

            }
            Thread.Sleep(Timeout.Infinite);

            
        }
        public class Controller : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
               string splitchar = "»";
               char[] splitcharr = splitchar.ToCharArray(); 
               string[] command = e.Data.Split(splitcharr);
                if (command[0] == "selectplay")
                {
                    
                   
                    
                    foreach (IITPlaylist pl in vars.iTunes.LibrarySource.Playlists)
                    {
                        if(pl.Name== command[1])
                        {
                            foreach(IITTrack track in pl.Tracks)
                            {
                                track.Play();
                                Send(track.Name + "»" + track.Artist);
                                Thread.Sleep(track.Duration * 1000);
                            }
                        }
                    }
                }
                if (command[0] == "pause")
                {
                    vars.iTunes.Pause();
                    Send("success");
                }
                if (command[0] == "stop")
                {
                    vars.iTunes.Stop();
                    Send("success");
                }
                if (command[0] == "prevtrack")
                {
                    vars.iTunes.PreviousTrack();
                    Send("success");
                }
                if (command[0] == "nexttrack")
                {
                    vars.iTunes.NextTrack();
                    Send("success");
                }
                if (command[0] == "volume")
                {
                    vars.iTunes.SoundVolume = int.Parse(command[1]);
                    Send("success");
                }
                if (command[0] == "resume")
                {
                    vars.iTunes.Resume();
                    Send("success");
                }
                else
                {
                    Send("Unknown Command");
                }
            }
        }

    }
}
