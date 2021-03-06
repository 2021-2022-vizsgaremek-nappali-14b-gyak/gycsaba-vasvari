using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vizsgaremek.Models;
using Vizsgaremek.Stores;
using Vizsgaremek.Repositories.Interface;

namespace Vizsgaremek.Repositories
{
    public partial class Teachers : IRepositoryAPIStringId<Teacher>
    {
        public Teacher FindTeacher(string id)
        {
            foreach (Teacher teacher in teachers)
            {
                if (teacher.Id.CompareTo(id) == 0)
                {
                    return teacher;
                }
            }
            return null;
        }
    }
}
