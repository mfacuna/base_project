using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace base_project.Exceptions
{
    public class BusinessValidationException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public BusinessValidationException(string message)
            : base(message)
        {
        }
    }
}
