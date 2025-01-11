using Biblioteca_REST_API.Models;

namespace Biblioteca_REST_API.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {

            List<Person> persons = new List<Person>();
            for(int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementaAndGet(),
                FirstName = "First Name",
                LastName = "Last Name",
                Address = "Address",
                Gender = "Gender"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementaAndGet(),
                FirstName = "First Name" + i,
                LastName = "Last Name" + i,
                Address = "Address" + i,
                Gender = "Gender"
            };
        }

        private long IncrementaAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
