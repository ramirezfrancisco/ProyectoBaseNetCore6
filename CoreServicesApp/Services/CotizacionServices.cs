using DataAccess.DBContext;
using DataAccess.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CoreServicesApp.Services
{
    public class CotizacionServices
    {
        private readonly ChicoteIoContext _ChicoteIoContext;
        public CotizacionServices(ChicoteIoContext chicoteIoContext)
        {
            _ChicoteIoContext = chicoteIoContext;
        }

        public async Task<Response> getCotizacion(string idCotizacion)
        {
            Response res = new Response { status = Constants.Error_Status };
            try
            {
                var cotizacion = await _ChicoteIoContext.DsVentasCotizacionEncabezados.Where(x => x.SalesId.Equals(idCotizacion)).FirstOrDefaultAsync();

                if (cotizacion != null)
                {
                    res.status = Constants.Ok_Status;
                    res.message = "Se obtuvo con éxito la cotización";
                }

                res.message = "No se encontró la cotización";
                res.data = new List<string>();

            }
            catch (DbUpdateException ex) { res.message = ex.Message; res.data = ex.InnerException.Message == null ? ex.Message.ToString() : ex.InnerException.Message; }
            catch (Exception ex) { res.message = ex.Message; res.data = ex.Message.ToString(); }
            return res;
        }
    }
}
