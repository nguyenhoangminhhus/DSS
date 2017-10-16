using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS_UI.Models
{
    public class Person
    {
        public string name;
        public string sexual;
        public string dateofbirth;
        public string homtown;
        public string position;
        public byte[] image;
        public string description;

        public Person()
        {
        }

        public Person(string name, string sexual, string dateofbirth, string homtown, string position,  byte[] image, string description)
        {
            this.name = name;
            this.sexual = sexual;
            this.dateofbirth = dateofbirth;
            this.homtown = homtown;
            this.position = position;
            this.image = image;
            this.description = description;
        }

    }
}
