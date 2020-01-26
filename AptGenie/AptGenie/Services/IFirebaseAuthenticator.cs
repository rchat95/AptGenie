using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AptGenie.Services
{
    public interface IFirebaseAuthenticator
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        Task<string> CreateWithEmailPassword(string email, string password);
    }
}
