using System;

namespace NRT_demo
{
    class Program
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }

            public string FullName => MiddleName == null 
                ? $"{FirstName} {LastName}" 
                : $"{FirstName} {MiddleName} {LastName}";
        }

        #nullable enable
        public class NRTPerson
        {
            // This string isn't nullable
            public string FirstName { get; set; } = "";
            // This string is nullable
            public string? MiddleName { get; set; }
            public string LastName { get; set; }

            // Warning for uninitialized variables, what does the programmer want the default value to be?
            public NRTPerson()
            {
                LastName = "";
            }

            // Force the user of your class to provide the values
            public NRTPerson(string firstName, string? middleName, string lastName)
            {
                FirstName = firstName;
                MiddleName = middleName;
                LastName = lastName;
            }
        }
        #nullable disable

        static void Main(string[] args)
        {
            var personWithoutMiddleName = new Person
            {
                FirstName = "Guus",
                LastName = "Meeuwis"
            };

            // This throws!
            // Activate NTR and you will get a warning doing this.
            var middleNameLength = personWithoutMiddleName.MiddleName.Length;

            var personWithMiddleName = new Person
            {
                FirstName = "Ankie",
                MiddleName = "van",
                LastName = "Grunsven"
            };

#nullable enable
            var nrtPersonWithoutMiddleName = new NRTPerson
            {
                FirstName = "Guus",
                LastName = "Meeuwis"
            };

            // This now gives a warning for being possible null
            var nrtMiddleNameLength = nrtPersonWithoutMiddleName.MiddleName.Length;

            var nrtPersonWithMiddleName = new NRTPerson("Ankie", "van", "Grunsven");
#nullable disable
        }
    }
}
