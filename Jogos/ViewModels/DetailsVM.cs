using Jogos.Models;

namespace Jogos.ViewModels;

public class DetailsVM
{
    public Jogo Anterior { get; set; }    
    public Jogo Atual { get; set; }     
    public Jogo Proximo { get; set; }
}