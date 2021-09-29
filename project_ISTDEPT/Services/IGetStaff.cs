using Project3_FinalExam.Models;

namespace Project3_FinalExam.Services
{
    public interface IGetStaff
    {
        System.Threading.Tasks.Task<System.Collections.Generic.List<Staff>> GetAllStaff();
    }
}