using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumExercises
{
    public static class UserFactory
    {
        public static RegistrationUser CreateValidUser()
        {
            return new RegistrationUser //Values of variables
            {
                Email = "vasil@abv.bg",
                FirstName = "Vasil",
                LastName = "Stanoev",
                Year = "1994",
                Month = "4",
                Date = "2",
                Password = "pass1123",
                Gender = "male"
            };
    }
    }
}
