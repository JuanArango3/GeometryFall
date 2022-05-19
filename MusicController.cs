using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryFall
{
    class MusicController
    {
        private List<Song> songs;
        private int actualsong;

        public MusicController()
        {
            songs = new List<Song>();
            actualsong = 0;

            MediaPlayer.Volume = 0.1f;
        }

        public void loadSongs(ContentManager cm, bool shouldStart)
        {
            songs.Add(cm.Load<Song>("bgm1"));
            songs.Add(cm.Load<Song>("bgm2"));

            MediaPlayer.MediaStateChanged += StateSongChanged;

            if (shouldStart) start();
        }

        public void start()
        {
            MediaPlayer.Play(songs[actualsong]);
        }

        private void StateSongChanged(object sender, EventArgs e)
        {
            if (MediaPlayer.State == MediaState.Stopped || MediaPlayer.State == MediaState.Paused)
            {
                nextSong();
            }

        }

        public void nextSong()
        {
            actualsong++;
            if (actualsong>songs.Count-1) actualsong = 0;
            start();
        }

        public void stop()
        {
            MediaPlayer.Stop();
        }
    }
}
