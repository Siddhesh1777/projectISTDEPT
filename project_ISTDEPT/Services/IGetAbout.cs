using Project3_FinalExam.Models;

namespace Project3_FinalExam.Services
{
    public interface IGetAbout
    {
        System.Threading.Tasks.Task<System.Collections.Generic.List<About>> Getabout();
    }
}