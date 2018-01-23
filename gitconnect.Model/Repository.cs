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
    }
}
