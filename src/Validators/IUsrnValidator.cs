//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file=IUsrnValidator.cs company="">
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

namespace LGov.Library.Validators
    {
        /// <summary>
        /// </summary>
        public interface IUsrnValidator
            {
                /// <summary>
                /// </summary>
                /// <param name="usrn"></param>
                /// <returns></returns>
                bool ValidUsrn(string usrn);


                /// <summary>
                /// </summary>
                /// <param name="usrn"></param>
                /// <returns></returns>
                bool ValidUsrn(int usrn);


                /// <summary>
                /// </summary>
                /// <param name="usrn"></param>
                /// <returns></returns>
                bool ValidUsrn(long usrn);
            }
    }