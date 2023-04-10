using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.StudentModel
{
    public class Skill
    {
        public string SkillName { get; set; }

        private List<SubSkills> _SubSkills;

        public List<SubSkills> SubSkills
        {
            get { return _SubSkills; }
            set
            {
                _SubSkills = value;
            }
        }
    }
}
