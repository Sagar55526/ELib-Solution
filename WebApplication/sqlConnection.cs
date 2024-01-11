using System;
using System.Data;

namespace WebApplication
{
    internal class sqlConnection
    {
        private string strcon;

        public sqlConnection(string strcon)
        {
            this.strcon = strcon;
        }

        public ConnectionState State { get; internal set; }

        internal void Open()
        {
            throw new NotImplementedException();
        }

        internal void Close()
        {
            throw new NotImplementedException();
        }
    }
}