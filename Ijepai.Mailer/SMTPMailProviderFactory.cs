using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ijpieMailer.Interface;

namespace ijpieMailer
{
    class SMTPMailProviderFactory : IMailProviderFactory
    {
        public IMailProvider Create(string url, int port, string username, string password, bool ssl)
        {
            return new SMTPMailProvider(url, port, username, password, ssl);
        }
    }
}
