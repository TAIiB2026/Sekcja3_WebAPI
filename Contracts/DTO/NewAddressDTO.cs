using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTO
{
    public record NewAddressDTO(string PostalCode, string City, string Street);
}
