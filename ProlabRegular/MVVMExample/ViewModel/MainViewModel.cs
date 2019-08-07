using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Reactive.Bindings;

namespace MVVMExample.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Model.MainModel MainModel = new Model.MainModel();

        public ObservableCollection<string> Images { get; set; } = new ObservableCollection<string>()
        {
            ("../../Resources/Black.png"),
            ("../../Resources/White.png"),
            ("../../Resources/Red.png"),
            ("../../Resources/Blue.png"),
            ("../../Resources/Green.png"),
        };

        public ReactiveProperty<int> ID { get; set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> HP { get; set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> Attack { get; set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> Deffence { get; set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> Speed { get; set; } = new ReactiveProperty<int>();

        public ReactiveProperty<string> Selected { get; set; } = new ReactiveProperty<string>();

        public ReactiveProperty<BitmapImage> Icon { get; set; } = new ReactiveProperty<BitmapImage>();

        public ReactiveProperty<bool> Saveable { get; set; } = new ReactiveProperty<bool>();

        public ICommand Save
        {
            get
            {
                return new Share.RelayCommand(_ =>
                {
                    var sfd = new SaveFileDialog();
                    if(sfd.ShowDialog() == DialogResult.OK)
                    {
                        MainModel.Save(sfd.FileName);
                    }
                });
            }
        }


        public MainViewModel()
        {
            Selected.PropertyChanged += (_, __) =>
            {
                Icon.Value = new BitmapImage();
                Icon.Value.BeginInit();

                Icon.Value.CacheOption = BitmapCacheOption.OnLoad;
                Icon.Value.DecodePixelWidth = 50;
                Icon.Value.CreateOptions = BitmapCreateOptions.None;

                Icon.Value.UriSource = new Uri(System.IO.Path.GetFullPath(Selected.Value));
                Icon.Value.EndInit();

                Icon.Value.Freeze();
            };

            ID.PropertyChanged += (_, __) =>
            {
                Saveable.Value = ID.Value > 0;
            };
        }
    }
}
