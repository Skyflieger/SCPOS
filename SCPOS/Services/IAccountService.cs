using SCPOS.Models;

namespace SCPOS.Services; 

public interface IAccountService {
    Account GetUser(string username, string password);
}