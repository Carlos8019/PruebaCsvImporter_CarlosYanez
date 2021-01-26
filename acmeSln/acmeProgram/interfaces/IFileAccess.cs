using System.Threading.Tasks;

namespace acmeProgram.interfaces
{
    public interface IFileAccess
    {
        Task readFileAsync(string url, int numRows);
    }
}
