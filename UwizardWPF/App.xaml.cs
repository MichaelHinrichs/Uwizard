using System.Windows;
using AutoMapper.Internal;
using UwizardWPF.Server;

namespace UwizardWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ISQLiteDatabase _database;
        private Setup _setup;

        public App()
        {
            _setup = new Setup();
            
            _setup.Register();
        }
    }
}
