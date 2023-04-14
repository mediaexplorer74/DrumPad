//using Plugin.SimpleAudioPlayer; 
using SimpleAudio;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DrumPad
{
    public partial class App : Application
    {
        //public static Func<ISimpleAudioPlayer> CreateAudioPlayer { get; set; }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new DrumPad.MainPage();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
