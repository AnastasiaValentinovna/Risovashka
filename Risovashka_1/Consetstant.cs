using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Risovashka_1
{
   public class Consetstant
    {
        public int ID { get; set; }
        public int ID_contests { get; set; }
        public int ID_user { get; set; }

        public int Age { get; set; }
        public string Drawing { get; set; }
        public int Number_of_votes { get; set; }
        public string drawing
        {

            get { return Drawing; }
            set
            {
                Drawing = value;
                OnPropertyChanged("drawing");
            }
        }
        public int id_contests
        {
            get { return ID_contests; }
            set
            {
                ID_contests = value;
                OnPropertyChanged("id_contests");
            }
        }
        public int id_user
        {
            get { return ID_user; }
            set
            {
                ID_user = value;
                OnPropertyChanged("id_user");
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
        public int number_of_votes
        {
            get { return Number_of_votes; }
            set
            {
                Number_of_votes = value;
                OnPropertyChanged("number_of_votes");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")

        {

            if (PropertyChanged != null)

                PropertyChanged(this, new PropertyChangedEventArgs(prop));

        }
        public Consetstant() { }
        public Consetstant(int ID_contests, int ID_user, int Age, string Drawing, int Number_of_votes)
        {
            this.ID_contests = ID_contests;
            this.ID_user = ID_user;
            this.Age = Age;
            this.Drawing = Drawing;
            this.Number_of_votes = Number_of_votes;
        }

    }
}
