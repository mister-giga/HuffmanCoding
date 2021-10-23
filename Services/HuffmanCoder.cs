using HuffmanCoding.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HuffmanCoding.Services
{
    public class HuffmanCoder : INotifyPropertyChanged
    {
        string input = "";
        public string Input
        {
            get => input;
            set
            {
                SetProperty(ref input, value);
                IsAvailable = !string.IsNullOrWhiteSpace(value);
            }
        }

        bool isAvailable = false;
        public bool IsAvailable
        {
            get => isAvailable;
            set => SetProperty(ref isAvailable, value);
        }
        public CharInfoStore CharInfoStore { get; }

        public HuffmanCoder(CharInfoStore charInfoStore)
        {
            CharInfoStore = charInfoStore;
        }
       

        public event PropertyChangedEventHandler? PropertyChanged;
        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

            storage = value;
            RaisePropertyChanged(propertyName);

            return true;
        }
        void RaisePropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}