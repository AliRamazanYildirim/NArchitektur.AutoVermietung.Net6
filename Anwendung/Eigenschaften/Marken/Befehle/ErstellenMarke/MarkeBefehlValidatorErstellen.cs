using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anwendung.Eigenschaften.Marken.Befehle.ErstellenMarke
{
    public class MarkeBefehlValidatorErstellen:AbstractValidator<ErstellenMarkeEinheitsBefehl>
    {
        public MarkeBefehlValidatorErstellen()
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Name).MinimumLength(2);

        }
    }
}
