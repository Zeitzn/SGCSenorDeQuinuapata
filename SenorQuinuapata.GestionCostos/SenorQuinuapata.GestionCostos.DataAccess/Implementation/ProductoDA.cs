using SenorQuinuapata.GestionCostos.DataAccess.DataBase;
using SenorQuinuapata.GestionCostos.DataAccess.Interface;
using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.DataAccess.Implementation
{
    public class ProductoDA : IProductoDA
    {
        public readonly bd_sgcquinuapataEntities db = new bd_sgcquinuapataEntities();


        #region no transaccional
        public IEnumerable<ProductoResponse> List()
        {
            try
            {
                var result = new List<ProductoResponse>();
                using (db)
                {
                    
                    result = db.Database.SqlQuery<ProductoResponse>("sp_producto_list").ToList();

                }
                return result;
            }
            finally
            {
                db.Dispose();
            }
        }


        #endregion

        #region transaccional
        public void RegisterProducto(ProductoRequest producto)
        {
            try
            {
                using (db)
                {

                    db.Producto.Add(
                        
                        new Producto()
                        {
                            id=producto.id,
                            codigo=producto.codigo,
                            nombre=producto.nombre
                        }
                        
                        );

                    db.SaveChanges();

                }
            }
            finally
            {

                db.Dispose();
            }
        }
        #endregion
    }
}
