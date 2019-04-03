using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.WebForm.Mantenimiento
{
    public partial class ManageArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtFiltroPorNombre.Text;
            // Recuperando el servicio de cliente
            var client = new MantenimientoServices.MantenimientoServicesClient();
            List<Artist> listado = client.GetArtistAll(nombre);
            // asignado la colección a la propiedad del grid
            gvListado.DataSource = listado;
            // enlazando los datos
            gvListado.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewArtist.aspx");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateArtist.aspx");
        }
    }
}