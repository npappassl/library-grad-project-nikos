using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryGradProject.Repos
{
    public interface IDbContextFactory<T>
    {
        T Create();
        T Create(string connectionString);

    }
}
