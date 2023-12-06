using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGifts_Тепляков.Interfaces
{
    public interface ICategory
    {
        void Save(bool Update = false);
        List<Classes.CategoryContext> AllCategories();
        void Delete();
    }
}
