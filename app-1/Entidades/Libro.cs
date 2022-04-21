using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace app_1.Entidades
{
    public class Libro : IValidatableObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AutorId { get; set; }

        public Autor Autor { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                var primeraLetra = Name.ToString()[0].ToString();
                if (primeraLetra != primeraLetra.ToUpper())
                {
                    yield return new ValidationResult("Valida Modelo: La primer letra debe ser en mayúscula!", new string[] { nameof(Name) } );
                }
            }
        }
    }
}
