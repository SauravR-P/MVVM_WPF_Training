using Commands;
using DataModel.StudentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BusinessModel
{
    public class Student_ViewModel : INotifyPropertyChanged
    {
        private ICommand _clickcommand;
        public Student_ViewModel()
        {
            Students = new ObservableCollection<StudentModel>()
            {
                new StudentModel()
                {
                    Name ="Dhoni",
                    Id = "A007",
                    RollNo = "07",
                    Skills = new List<Skill>(){ new Skill() { SkillName = "Helicopter Shot", SubSkills = new List<SubSkills>(){ new SubSkills() {SubSkill = "WK" } } } }

                },
                new StudentModel()
                {
                    Name ="Ganguly",
                    Id = "A001",
                    RollNo = "01",
                    Skills = new List<Skill>(){ new Skill() {SkillName = "Offence", SubSkills = new List<SubSkills>(){ new SubSkills() {SubSkill = "WK" } } } }
                },
                new StudentModel()
                {
                    Name ="Tendulkar",
                    Id = "A010",
                    RollNo = "10",
                    Skills = new List<Skill>(){ new Skill() { SkillName = "Consistency", SubSkills = new List<SubSkills>(){ new SubSkills() {SubSkill = "WK" } } } }
                }
            };
        }
        public string Heading { get; set; } = "Learning WPF";

        public ObservableCollection<StudentModel> Students
        {
            get;

            set;
        }
        public ICommand ClickCommand_Remove
        {
            get
            {
                if (_clickcommand == null)
                {
                    _clickcommand = new RelayCommand(
                        param => RemoveZeroIndex(),
                        param => CanClick());
                }
                return _clickcommand;
            }
        }
        public ICommand ClickCommand_ChangeHeading
        {
            get
            {
                if (_clickcommand == null)
                {
                    _clickcommand = new RelayCommand(
                        param => ChangeHeading(),
                        param => CanClick());
                }
                return _clickcommand;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        private bool CanClick()
        {
            return true;
        }
        private void ChangeHeading()
        {
            try
            {
                Heading = "Command Executed";
                //Students.RemoveAt(0);
                OnPropertyChange("Heading");
            }
            catch (ArgumentOutOfRangeException)
            {
                Heading = "Heading Not Changed";
            }
        }
        private void RemoveZeroIndex()
        {
            try
            {
                Students.RemoveAt(0);
            }
            catch (ArgumentOutOfRangeException)
            {
                Heading = "No Row Available to remove";
            }
        }
    }
}
