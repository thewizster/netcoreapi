using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Webextant.Models
{
    public class PeopleRepository : IPeopleRepository
    {
        private static ConcurrentDictionary<string, Person> _people =
            new ConcurrentDictionary<string, Person>();
        public PeopleRepository()
        {
            var me = new Person();
            me.FirstName = "Raymond";
            me.LastName = "Brady";

            Add(me);
        }

        public void Add(Person item)
        {
            item.Key = Guid.NewGuid().ToString();
            _people[item.Key] = item;
        }

        public Person Find(string key)
        {
            Person item;
            _people.TryGetValue(key, out item);
            return item;
        }

        public IEnumerable<Person> GetAll()
        {
            return _people.Values;
        }

        public Person Remove(string key)
        {
            Person item;
            _people.TryGetValue(key, out item);
            _people.TryRemove(key, out item);
            return item;
        }

        public void Update(Person item)
        {
            _people[item.Key] = item;
        }
    }
}