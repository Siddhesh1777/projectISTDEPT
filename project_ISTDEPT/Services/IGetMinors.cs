using Project3_FinalExam.Models;

namespace Project3_FinalExam.Services
{
    public interface IGetMinors
    {
        System.Threading.Tasks.Task<System.Collections.Generic.List<Minors>> GetMinors();
    }
}