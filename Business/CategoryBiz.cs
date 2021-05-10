using Data.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business
{
    public class CategoryBiz
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Agregar(Category model)
        {
            var db = new BaseDataService<Category>();
            db.Create(model);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Delete(Category model)
        {
            var db = new BaseDataService<Category>();
            db.Delete(model);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Actualizar(int id, string name)
        {
            var db = new BaseDataService<Category>();
            Category model = db.GetById(id);
            model.Name = name;
            db.Update(model);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Category> Listar()
        {
            var db = new BaseDataService<Category>();
            var lista = db.Get();
            return lista;
        }
    }
}
