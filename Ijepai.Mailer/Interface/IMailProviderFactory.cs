using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijpieMailer.Interface
{
    public interface IMailProviderFactory
    {
        IMailProvider Create(string url, int port, string username, string password, bool ssl);
    }
}
