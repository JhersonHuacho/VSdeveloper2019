using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.WebForm.Mantenimiento
{
    public partial class NewArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
                //{
                //    txtNombre.Text = Request.QueryString["name"];
                //}
                GetArtist();
            }
        }

        private void GetArtist()
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);
                var client = new MantenimientoServices.MantenimientoServicesClient();
                var artist = client.GetArtist(id);

                txtNombre.Text = artist.Name;
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            var artist = new Artist();
            artist.Name = txtNombre.Text;

            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                artist.ArtistId = Convert.ToInt32(Request.QueryString["id"]);
            }
            

            // llamando al proxy del servicio de mantenimiento
            var client = new MantenimientoServices.MantenimientoServicesClient();
            client.SaveArtist(artist);

            Response.Redirect("ManageArtist.aspx");
        }
    }
}