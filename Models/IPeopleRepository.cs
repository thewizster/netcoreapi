using System.Collections.Generic;

namespace Webextant.Models
{
    public interface IPeopleRepository
    {
        void Add(Person item);
        IEnumerable<Person> GetAll();
        Person Find(string key);
        Person Remove(string key);
        void Update(Person item);
    }
}