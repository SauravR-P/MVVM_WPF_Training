using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.StudentModel
{
        public class StudentModel : INotifyPropertyChanged
    {
        private string _id, _name, _rollNo;
        private List<Skill> _skills;
        public string Id
        {
            get { return _id; }set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_id == "A001")
                {
                    _rollNo = "X001";
                    OnPropertyChange(RollNo);
                }
                _name = value;
            }
        }
        public string RollNo
        {
            get { return _rollNo; }
            set { _rollNo = value; }
        }

        public List<Skill> Skills
        {
            get { return _skills; }
            set
            {
                _skills = value;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

