using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace OnlineShop.DataLayer.DataLayer.Interfaces
{
    public interface ISQLConnectionFactory
    {
        SqlConnection Create();
    }
}
