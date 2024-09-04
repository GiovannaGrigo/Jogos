using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jogos.Models;
[Table("JogoGenero")]
public class JogoGenero
{
    [Key, Column(Order = 1)]
    public int JogoId { get; set; }
    [ForeignKey("JogoId")]
    public Jogo Jogo { get; set; }

    [Key, Column(Order = 2)]
    public int GeneroId { get; set; }
    [ForeignKey("GeneroId")]
    public Genero Genero { get; set; }
}
