//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=PersonValidator.cs company="">
//  Solution : -  NLC.Library
// 
//  </copyright>
//  <summary>
// 
//  Created - 17/03/2021 17:48
//  Altered - 25/04/2022 12:17 - Stephen Ellwood
// 
//  Project : - NLC.Library
// 
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using LGov.Library.Interfaces;

namespace LGov.Library.Validators
    {
        /// <summary>
        /// </summary>
        public class PersonValidator : IPersonValidator
            {
                /// <summary>
                /// </summary>
                /// <param name="person"></param>
                /// <returns></returns>
                public bool ValidPerson(IPerson person) => person.IsValid();

                /// <inheritdoc />
                public bool ValidPerson(string surname, string forename)
                    {
                        var person = new Person { FamilyName = surname, GivenName = forename };
                        return person.IsValid();
                    }
            }
    }