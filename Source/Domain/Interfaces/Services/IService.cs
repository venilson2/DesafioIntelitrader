using DesafioIntelitrader.Source.Domain.Entites;

namespace DesafioIntelitrader.Source.Domain.Interfaces.Services
{
    interface IService<T>
    {
        List<T> ReadFile();
    }
}
