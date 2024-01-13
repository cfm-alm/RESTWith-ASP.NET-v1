using RestwithASPNETUdemy.Model;

namespace RestwithASPNETUdemy.Services.Implementations
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
            for (int i = 0; i < 8; i++)
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
                Id = id,
                FirstName = "Ceci",
                LastName = "Fossa",
                Address = "SP",
                Gender = "Female"
            };
        }

        public Person Update(Person person)
        {
            // fazer update da pessoa na base de dados
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "PersonName" + i,
                LastName = "PersonSurname" + i,
                Address = "PersonAddress" + i,
                Gender = "Female"
            };
        }

        private int IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
