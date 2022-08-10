using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_management_system.ApplicationLogic.Validations
{
    class BaseValidation
    {
        public static bool IsLengthCorrect(string text, int startLengt, int endLength)
        {
            return text.Length >= startLengt && text.Length <= endLength;
        }
    }
}
