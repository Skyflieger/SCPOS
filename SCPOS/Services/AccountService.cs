using System.Security.Cryptography;
using SCPOS.Models;
using SqlKata.Execution;

namespace SCPOS.Services; 

public class AccountService : IAccountService {
    
    private readonly QueryFactory _queryFactory;
    
    public AccountService(QueryFactory queryFactory) {
        _queryFactory = queryFactory;
    }
    
    public Account GetUser(string username, string password) {

        return _queryFactory.Query("Account").Select("Username", "Id")
            .Where("Username", username)
            .Where("Password", Hash.GetHash(SHA256.Create(), password))
            .First<Account>();
        
    }
}