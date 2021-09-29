using Project3_FinalExam.Models;

namespace Project3_FinalExam.Services
{
    public interface IGetEmployment
    {
        System.Threading.Tasks.Task<System.Collections.Generic.List<Employment>> Getemployment();
    }
}