using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string error) : base(error)
        {
        }
        public static void When(bool hasErro, string error)
        {
            if (hasErro)
            {
                throw new DomainExceptionValidation(error);
            }
        }
            
    }
}
