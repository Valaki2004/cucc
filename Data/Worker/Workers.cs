using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DB.Worker
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public int Id { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string age;
        public string Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged();
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }

        private string job;
        public string Job
        {
            get { return job; }
            set
            {
                job = value;
                OnPropertyChanged();
            }
        }

        private string income;
        public string Income
        {
            get { return income; }
            set
            {
                income = value;
                OnPropertyChanged();
            }
        }

        public User()
        {
            Id = 0;
        }

        public User(string name, string age, string city, string job, string income)
        {
            Name = name;
            Age = age;
            City = city;
            Job = job;
            Income = income;
        }

        public User(string sor)
        {
            string[] t = sor.Split(';');
            Name = t[0];
            Age = t[1];
            City = t[2];
            Job = t[3];
            Income = t[4];
        }

        public override string? ToString()
        {
            return $"{Name}, neve a(z) {City} városban lakik, {Job}-ként dolgozik, {Age} éves, bevétel: {Income}.";
        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

