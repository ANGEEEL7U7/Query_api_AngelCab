using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using QueryApi.Domain;
using System.Threading.Tasks;

namespace QueryApi.Repositories
{
    public class PersonRepository
    {
        List<Person> _persons;

        public PersonRepository()
        {
            var fileName = "dummy.data.queries.json";
            if(File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                _persons = JsonSerializer.Deserialize<IEnumerable<Person>>(json).ToList();
            }
        }

        //Escribe un método en el cual se retorne la información de todas las personas
        public IEnumerable<Object> GetDate(){

            var query = _persons.Select(person => new {Identificador = person.Id, NombreCompleto = $"{person.FirstName}{person.LastName}",Fecha = DateTime.Now.AddYears(person.Age * - 1).Year,
            Correo = person.Email, Sexo = person.Gender, Trabajo = person.Job});
            return query;
        }
        //Escribe un método en el cual se retorne únicamente el nombre completo de las personas, el correo y el año de nacimiento.
         public IEnumerable<Object> GetFields(){
            var query = _persons.Select(person => new{NombreCompleto = $"{person.FirstName}{person.LastName}",AnioN = DateTime.Now.AddYears(person.Age * - 1).Year,
            Correo = person.Email
            });
            return query;
        } 
        //Escribe un método que retorne la información de todas las personas cuyo genero sea Femenino.
            public IEnumerable<Person> GetGenero(char gender){

               // var gender = 'F';
                var query = _persons.Where(person => person.Gender == gender);
                return query;
            }
        //Escribe un método que retorne la información de todas las personas cuya edad se encuentre entre los 20 y 30 años.
        public IEnumerable<Person> GetEdades(int minAge, int maxAge){
            //var minAge = 20;
            //var maxAge = 30;
            var query = _persons.Where(Person => Person.Age >= minAge && Person.Age <= maxAge);
            return query;
        }
        //Escribe un método que retorne la información de los diferentes trabajos que tienen las personas
        public IEnumerable<String> GetJob(){//<- este muestra los trabajos que estan registrados
            var query = _persons.Select(person => person.Job ).Distinct();
            return query;
            
        }
        public IEnumerable<Object> GetDistinct(){// Muestra  el nombre del empleado y de que es su especialidad
            var query = _persons.Select(person => new{Nombre = $"{person.FirstName}{person.LastName}", Especialidad = person.Job
            }).Distinct();
            return query;
        } 
        //Escribe un método que retorne la información de las personas cuyo nombre contenga la palabra “ar”
        public IEnumerable<Person> GetarWith(string ar){

            //var ar = "ar";
            var query = _persons.Where(p => p.FirstName.Contains(ar));
            return query;
        }
        //Escribe un método que retorna la información de las personas cuyas edades sean 25, 35 y 45 años
        public IEnumerable<Person> GetListAge(int ageone, int agetwo, int agethree){
            //var Age = new List<int>{25,35,45};
            var ages = new List<int> {ageone,agetwo,agethree};
            var query = _persons.Where(Person => ages.Contains(Person.Age));
            return query;
        } 
        //Escribe un método que retorne la información ordenas por edad para las personas que sean mayores a 40 años
         public IEnumerable<Person> GetOrder(int age){
            //var age = 40;
            var query = _persons.Where(person => person.Age > age).OrderBy(person => person.Age);
            return query;
        }
        //Escribe un método que retorne la información ordenada de manera descendente para todas las personas de género masculino y que se encuentren entre los 20 y 30 años de edad
        public IEnumerable<Person> GetDesc(int edadmin, int edadmax, char Genero){
            //var edadmin = 20;
            //var edadmax = 30;
            //var Genero = 'M';
            var query = _persons.Where(p => (p.Age >= edadmin && p.Age <= edadmax) && (p.Gender == Genero)).OrderByDescending(p => p.Id);
            return query;
        }
        //Escribe un método que retorne la cantidad de personas con género femenino.
        public IEnumerable<Person> GetFemale(char gender){
            //var gender = 'F';
            var query = _persons.Where(person => person.Gender == gender);
            return query;
        }
        //Escribe un método que retorna si existen personas con el apellido “Shemelt”.
        public bool Exist(string Shemelt)
        {
            //var Shemelt = "Shemelt";
            var query = _persons.Exists(person => person.LastName == Shemelt);
            return query; 
        }
        //Escribe un método que retorne únicamente una persona cuyo trabajo sea “Software Consultant” y tenga 25 años de edad

         public IEnumerable<Person> GetOneperson(int edad, string onejob){
            //var edad = 25;
            //var onejob = "Software Consultant";
            var query = _persons.Where(p => (p.Age == edad) && (p.Job == onejob));
            return query;
        }
        //Escribe un método que retorne la información de las primeras 3 personas cuyo puesto de trabajo sea “Software Consultant”
        public IEnumerable<Person> TakePerson(string TakeJob, int list)
        {
           // var TakeJob = "Software Consultant";
            //var list = 3;
            var query = _persons.Where(person => person.Job == TakeJob).Take(list);
            return query;
        }
        //Escribe un método que omita la información de las primeras 3 personas cuyo puesto de trabajo sea “Software Consultant”
        public IEnumerable<Person> TakeLastPerson(string TakeJob, int list)
        {
           // var TakeJob = "Software Consultant";
            //var list = 3;
            var query = _persons.Where(person => person.Job == TakeJob).TakeLast(list);
            return query;
        }
        //Escribe un método que omita la información de las primeras 3 personas y que retorne la información de las siguientes 3 personas cuyo puesto de trabajo sea “Software Consultant”
        public IEnumerable<Person> TakeandLastPerson(string TakeJob, int list)
        {
            
            var query = _persons.Where(person => person.Job == TakeJob).Take(list).TakeLast(list);
            return query;
        }
    } 
}