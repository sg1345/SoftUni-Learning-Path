using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        //public RandomList()
        //{
            
        //}
        //public RandomList(params string[] list)
        //{
        //    this.list = list.ToList();
        //}

        //public RandomList(List<string> list)
        //{
        //    this.list = list;
        //}

        //public List<string> list {  get; set; }

        public string RandomString()
        {
            Random random = new Random();
            int index = random.Next(0,this.Count);

            string value = this[index];
            this.RemoveAt(index);
            return value;
        }
    }
}
