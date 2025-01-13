using Biblioteca_REST_API.Data.Converter.Contract;
using Biblioteca_REST_API.Data.VO;
using Biblioteca_REST_API.Models;

namespace Biblioteca_REST_API.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origin)
        {
            if (origin is null) return null;
            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<Person> Parse(List<PersonVO> origin)
        {
            if (origin is null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public PersonVO Parse(Person origin)
        {
            if (origin is null) return null;
            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<PersonVO> Parse(List<Person> origin)
        {
            if (origin is null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
