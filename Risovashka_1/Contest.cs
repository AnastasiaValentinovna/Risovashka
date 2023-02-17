using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Risovashka_1
{
    public class Contest
    {
        public int ID { get; set; }
        public string Name;
        public string Dates_of_the_event;
        public int Age;
        public string Description;

        public  string name
        {
            get { return Name; }
            set
            {
                Name = value;
                OnPropertyChanged("name");
            }
        }
        public string dates_of_the_event
        {
            get { return Dates_of_the_event; }
            set
            {
                Dates_of_the_event = value;
                OnPropertyChanged("dates_of_the_event");
            }
        }
        public int age
        {
            get { return Age; }
            set
            {
                Age = value;
                OnPropertyChanged("age");
            }
        }
        public string description
        {
            get { return Description; }
            set
            {
                Description = value;
                OnPropertyChanged("description");
            }
        }
        public Contest() { }
        public Contest(string Name, string Dates_of_the_event, int Age, string Description)
        {
            this.Name = Name;
            this.Dates_of_the_event = Dates_of_the_event;
            this.Age = Age;
            this.Description = Description;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")

        {

            if (PropertyChanged != null)

                PropertyChanged(this, new PropertyChangedEventArgs(prop));

        }
        //public override string ToString()
        //{
        //    return "Код конкурса: " + ID + " Наименование: " + Name + " Даты проведения: " + Dates_of_the_event + " Возраст от: " + Age + "лет" + " Описание: " + Description;
        //}
    }
}
