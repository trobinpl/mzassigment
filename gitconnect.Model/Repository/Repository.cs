using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gitconnect.Model
{
    public class Repository
    {
        public Repository(string name, int stargazerCount)
        {
            this.Name = name;
            this.StargazerCount = stargazerCount;
        }

        public string Name { get; set; }

        public int StargazerCount { get; set; }

        public override bool Equals(object obj)
        {
            Repository anotherRepository = obj as Repository;

            if(anotherRepository == null)
            {
                return false;
            }

            return this.Name == anotherRepository.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }


        public override string ToString()
        {
            return $"Name: {this.Name}, Stargazer count: {this.StargazerCount}";
        }
    }
}