using Project3_FinalExam.Models;

namespace Project3_FinalExam.Services
{
    public interface IGetCoop
    {
        System.Threading.Tasks.Task<System.Collections.Generic.List<Coop>> Getcoop();
    }
}