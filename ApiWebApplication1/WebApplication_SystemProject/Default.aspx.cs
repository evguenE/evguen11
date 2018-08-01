using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication_SystemProject.ServiceReference1;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication_SystemProject
{
    public partial class _Default : Page
    {
       
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();                              
            }                       
        }

        private void BindGrid()
        {                                   
            FormViewService.DataSource = client.Get().CustomersTable;
            FormViewService.DataBind();
        }               
                    
        protected void ItemDeleting(object sender, FormViewDeleteEventArgs e)
        {                                   
            int customerId = Convert.ToInt32( ((System.Web.UI.WebControls.FormView)(sender)).DataKey.Value);                        
            client.Delete(customerId);
            this.BindGrid();
        }

        protected void ModeChanging(object sender, FormViewModeEventArgs e)
        {

            switch (e.NewMode)
            {
                case FormViewMode.Edit:                    
                    FormViewService.ChangeMode(FormViewMode.Edit);
                    this.BindGrid();
                    break;
                case FormViewMode.ReadOnly:                  
                     FormViewService.ChangeMode(FormViewMode.ReadOnly);
                    this.BindGrid();
                    break;
                case FormViewMode.Insert:
                    FormViewService.ChangeMode(FormViewMode.Insert);
                    this.BindGrid();               
                    break;
                default:             
                    break;
            }
        }       

        protected void ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            string name = (FormViewService.FindControl("TextName") as TextBox).Text;
            string country = (FormViewService.FindControl("TextCountry") as TextBox).Text;
            client.Insert(name, country);
            this.BindGrid();        
        }       

        protected void ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            int customerId = Convert.ToInt32(FormViewService.DataKey.Value);          
            string name = (FormViewService.FindControl("txtName") as TextBox).Text;
            string country = (FormViewService.FindControl("txtCountry") as TextBox).Text;            
            client.Update(customerId, name, country);            
            this.BindGrid();                
        }

        protected void FormViewService_PageIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid();  
        }       

        protected void FormViewService_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            
        }       
      
        protected void Add_Row(object sender, EventArgs e)
        {
            TextBox tbn = (TextBox)GridView1.FooterRow.Cells[2].FindControl("txbname");
            String nm = tbn.Text;
            TextBox tbc = (TextBox)GridView1.FooterRow.Cells[1].FindControl("txbcountry");
            String ln = tbc.Text;

            string constr = ConfigurationManager.ConnectionStrings["SystemProjectConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Customers (Name, Country) VALUES (@Name, @Country)"))
                {
                    cmd.Parameters.AddWithValue("@Name", nm);
                    cmd.Parameters.AddWithValue("@Country", ln);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }                
        }

        protected void GridView1_Init(object sender, EventArgs e)
        {
           
        }

        protected void GridView1_Load(object sender, EventArgs e)
        {
             GridView1.DataBind();

            Button btn = new Button();
            btn.Text = "Add";
            btn.Click += new EventHandler(Add_Row);
            btn.ID = "add";

            TextBox txtn = new TextBox();
            txtn.ID = "txbname";

            TextBox txtc = new TextBox();
            txtc.ID = "txbcountry";

            GridView1.FooterRow.Cells[0].Controls.Add(btn);
            GridView1.FooterRow.Cells[2].Controls.Add(txtn);
            GridView1.FooterRow.Cells[3].Controls.Add(txtc);
           
        }
    }
}