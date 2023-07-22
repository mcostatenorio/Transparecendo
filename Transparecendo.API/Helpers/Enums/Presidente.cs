using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Transparecendo.API.Helpers.Enums
{
    public enum Presidente
    {
        [Display(Name = "Luiz Inácio Lula da Silva")]
        LuizInacioLulaDaSilva = 1,
        [Display(Name = "Dilma Vana Rousseff")]
        DilmaVanaRousseff = 2,
        [Display(Name = "Michel Miguel Elias Temer Lulia")]
        MichelMiguelEliasTemerLulia = 3,
        [Display(Name = "Jair Messias Bolsonaro")]
        JairMessiasBolsonaro = 4,
    }
}
