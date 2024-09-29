using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Web.Script.Serialization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeMinisters
{
    public partial class frmPrimeMinisters : Form
    {
        private Dictionary<string, PrimeMinister> primeMinisters = new Dictionary<string, PrimeMinister>();

        public frmPrimeMinisters()
        {
            InitializeComponent();
            Load += frmPrimeMinisters_Load;  
            lstPrimeMinisters.SelectedValueChanged += lstPrimeMinisters_SelectedValueChanged;
        }

        private void frmPrimeMinisters_Load(object sender, EventArgs e)
        {
            using (StreamReader file = File.OpenText("PrimeMinisters.json"))
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                primeMinisters = serializer.Deserialize<Dictionary<string, PrimeMinister>>(file.ReadToEnd());
            }

            lstPrimeMinisters.DataSource = primeMinisters.Keys.ToList<string>();
        }


        private void lstPrimeMinisters_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstPrimeMinisters.SelectedItem != null)
            {
                string selectedLastName = lstPrimeMinisters.SelectedItem.ToString();

                PrimeMinister selectedPM = primeMinisters[selectedLastName];

                lblName.Text = $"{selectedPM.FirstName} {selectedPM.LastName}";
                lblTerm.Text =$"Term:{ selectedPM.Term}";
                lblParty.Text =$"Party:{ selectedPM.Party}";
               
                string imagePath = $"{selectedPM.LastName}.jpg";
                picPhoto.ImageLocation = imagePath;
            }
        }

        private void frmPrimeMinisters_Load_1(object sender, EventArgs e)
        {

        }
    }
}