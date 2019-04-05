using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.WebForm.Mantenimiento
{
    public partial class UpdateArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            var artist = new Artist();
            artist.ArtistId =  int.Parse(txtId.Text);
            artist.Name = txtNombre.Text;

            // llamando al proxy del servicio de mantenimiento
            var client = new MantenimientoServices.MantenimientoServicesClient();
            client.SaveArtist(artist);

            Response.Redirect("ManageArtist.aspx");
        }
    }
}