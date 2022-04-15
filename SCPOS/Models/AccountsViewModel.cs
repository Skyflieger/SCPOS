namespace SCPOS.Models; 

public class AccountsViewModel {
    public List<Account> Accounts { get; set; }
    public int WindowId { get; set; }
}

public class Account {
    public int Id { get; set; }
    public string Username { get; set; }
}