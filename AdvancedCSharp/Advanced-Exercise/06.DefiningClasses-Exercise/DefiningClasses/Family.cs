using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family : IEnumerable<Person>
    {
        private List<Person> _members = new();

        public Family()
        {
            
        }

        public Family(List<Person> members)
        {
            _members = members;
        }

        public void AddMember(Person person)
        {
            this._members.Add(person);
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return ((IEnumerable<Person>)_members).GetEnumerator();
        }

        public Person GetOldestMember()
        {
            return this._members.MaxBy(x => x.Age);
        }

        public Family GetPeopleOver30()
        {

            return new Family
                (
                this._members
                .Where(person => person.Age > 30)
                .OrderBy(person => person.Name)
                .ToList()
                );            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_members).GetEnumerator();
        }
    }
}
