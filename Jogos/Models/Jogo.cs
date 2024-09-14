using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jogos.Models;
[Table("Jogo")]
public class Jogo
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Informe o nome")]
    [StringLength(30, ErrorMessage = "O nome deve possuir no máximo 30 caracteres")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Informe o caminho da imagem.")]
    [StringLength(300, ErrorMessage = "O caminho da imagem deve possuir 300 caracteres")]
    public string Imagem { get; set; }
    [Required(ErrorMessage = "Informe a descrição.")]
    [StringLength(500, ErrorMessage = "A descrição deve possuir no máximo 500 caracteres")]
    public string Descricao { get; set; }
    [Required]
    public int EmpresaId { get; set; }
    [ForeignKey("EmpresaId")]
    public Empresa Empresa { get; set; }
    public ICollection<JogoGenero> Generos { get; set; }
}
