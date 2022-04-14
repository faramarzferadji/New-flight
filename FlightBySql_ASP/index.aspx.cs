using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySqlConnector;
using MySqlDataAdapter = MySql.Data.MySqlClient.MySqlDataAdapter;

namespace FlightBySql_ASP
{
    public partial class index : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlConnection con;
        private decimal totalprice = (decimal)0.0;
        public string Total = "Total";
        

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxreturn.Visible = true;

            if (!Page.IsPostBack)
            {
                
                radlistgender.Items.Add(new ListItem("Mr"));
                radlistgender.Items.Add(new ListItem("Mm"));
                radlistgender.SelectedIndex = 0;

                cbocity.Items.Add(new ListItem("SElect your city ", ""));
                cbocity.Items.Add(new ListItem("Montreal", "300"));
                cbocity.Items.Add(new ListItem("Torento", "400"));
                cbocity.Items.Add(new ListItem("Vancover", "600"));
                cbocity.SelectedIndex = 0;
                listdist.Items.Add(new ListItem("London", "500"));
                listdist.Items.Add(new ListItem("Montreal", "-100"));
                listdist.Items.Add(new ListItem("NewYork", "100"));

                listdist.Items.Add(new ListItem("Baltimor", "200"));
                listdist.Items.Add(new ListItem("PhyladelPhy", "300"));
                listdist.Items.Add(new ListItem("Washangton DC", "400"));
                listdist.Items.Add(new ListItem("Torento", "-110"));
                listdist.Items.Add(new ListItem("Vancover", "120"));

                listdist.SelectedIndex = 0;

                radlisttrip.Items.Add(new ListItem("Simple", "1"));
                radlisttrip.Items.Add(new ListItem("Round", "1.5"));
                radlisttrip.SelectedIndex = 0;

                ListBoxfclass.Items.Add(new ListItem("Economie", "0"));
                ListBoxfclass.Items.Add(new ListItem("First Class", "250"));
                ListBoxfclass.Items.Add(new ListItem("VIP", "350"));
                ListBoxfclass.SelectedIndex = 0;

                chkboxlisservice.Items.Add(new ListItem("", "0"));
                chkboxlisservice.Items.Add(new ListItem("Extabagage ,", "50"));
                chkboxlisservice.Items.Add(new ListItem("Taxi ,", "70"));
                chkboxlisservice.Items.Add(new ListItem("Hote for l night", "200"));
                chkboxlisservice.SelectedIndex = 0;

            }
            if (cbocity.SelectedIndex > 0)
            {
               
            }


        }
        private void ClculPrice()
        {
            decimal baseprice = 0, disprice = 0, trpprice = 0, fclassprice = 0, servprice = 0, subtotal = 0,
                tax = 0, total = 0;
            String from = "", ditance = "", trip = "", fclass = "", service = "", dtime = "",dtimereturn="";
         
            trpprice = Convert.ToDecimal(radlisttrip.SelectedItem.Value);
            fclassprice = Convert.ToDecimal(ListBoxfclass.SelectedItem.Value);
            fclass = ListBoxfclass.SelectedItem.Text;
            foreach (ListItem item in cbocity.Items)
            {
                baseprice += (item.Selected) ? Convert.ToDecimal(item.Value) : 0;
                if (item.Selected)
                {
                    from += cbocity.SelectedIndex.ToString(item.Text);
                }

            }
            foreach (ListItem item in listdist.Items)
            {
                disprice += (item.Selected) ? Convert.ToDecimal(item.Value) : 0;
                if (item.Selected)
                {
                    ditance += listdist.SelectedIndex.ToString(item.Text);
                }

            }
            if (from == ditance)
            {
                
                Response.Write("<Script languge 'javascript'>alert('Please choice the other distanation')</script>");
            }
            else
            {


                foreach (ListItem item in chkboxlisservice.Items)
                {
                    servprice += (item.Selected) ? Convert.ToDecimal(item.Value) : 0;
                    if (item.Selected)
                    {
                        service += chkboxlisservice.SelectedIndex.ToString(item.Text);
                    }


                }
               
                
                decimal mp = baseprice + disprice;

                subtotal = ((baseprice + disprice) * trpprice) + fclassprice + servprice;
                tax = (subtotal * 15) / 100;
                total = subtotal + tax;
              
                dtime = txtdattime.Text;
                dtimereturn = TextBoxreturn.Text;
                trip = radlisttrip.SelectedItem.Text;
                
            }

        }

        protected void ListBoxfclass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            decimal baseprice = 0, disprice = 0, trpprice = 0, fclassprice = 0, servprice = 0, subtotal = 0,
              tax = 0, total = 0;
            
            String from = "", ditance = "", trip = "", fclass = "", service = "", dtime = "", dtimereturn = "";

            trpprice = Convert.ToDecimal(radlisttrip.SelectedItem.Value);
            fclassprice = Convert.ToDecimal(ListBoxfclass.SelectedItem.Value);
            fclass = ListBoxfclass.SelectedItem.Text;
            foreach (ListItem item in cbocity.Items)
            {
                baseprice += (item.Selected) ? Convert.ToDecimal(item.Value) : 0;
                if (item.Selected)
                {
                    from += cbocity.SelectedIndex.ToString(item.Text);
                }
                
            }
            foreach (ListItem item in listdist.Items)
            {
                disprice += (item.Selected) ? Convert.ToDecimal(item.Value) : 0;
                if (item.Selected)
                {
                    ditance += listdist.SelectedIndex.ToString(item.Text);
                }

            }
            if (from == ditance)
            {

                Response.Write("<Script languge 'javascript'>alert('Please choice the other distanation')</script>");
            }
            else
            {


                foreach (ListItem item in chkboxlisservice.Items)
                {
                    servprice += (item.Selected) ? Convert.ToDecimal(item.Value) : 0;
                    if (item.Selected)
                    {
                        service += chkboxlisservice.SelectedIndex.ToString(item.Text);
                    }


                }
              
                
                decimal mp = baseprice + disprice;

                subtotal = ((baseprice + disprice) * trpprice) + fclassprice + servprice;
                tax = (subtotal * 15) / 100;
                total = subtotal + tax;
                con = new MySql.Data.MySqlClient.MySqlConnection(@"server=localhost;user id=root;database=flight; password=SYSTEM;");
                con.Open();
                cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT into flightasp(name,fromcity,tocity,datego,datereturn,price) Values(@name,@fromcity,@tocity,@datego,@datereturn,@price)", con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@fromcity", cbocity.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@tocity", listdist.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@datego", txtdattime.Text);
                cmd.Parameters.AddWithValue("@datereturn", TextBoxreturn.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(total));
                cmd.ExecuteNonQuery();
                Response.Write("<Script language 'javascript'>alert('Data successfuly insert in database')</script>");
                con.Close();
            }
        }
        void Cleare()
        {
            HiddenField1.Value = "";
            txtName.Text = txtdattime.Text = TextBoxreturn.Text =  "";
            ButtonSave.Text = "SAVE";
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            Cleare();
        }
        void GridFill()
        {
            con = new MySql.Data.MySqlClient.MySqlConnection(@"server=localhost;user id=root;database=flight; password=SYSTEM;");
            cmd = new MySql.Data.MySqlClient.MySqlCommand("Select * from flightasp ", con);
            MySqlDataAdapter mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter();
            cmd.Connection = con;
            con.Open();
            mySqlDataAdapter.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
            con.Close();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            GridFill();

        }
        void Search()
        {
            con = new MySql.Data.MySqlClient.MySqlConnection(@"server=localhost;user id=root;database=flight; password=SYSTEM;");
            cmd = new MySql.Data.MySqlClient.MySqlCommand("select * from flightasp where name='" + txtName.Text + "'", con);
            MySqlDataAdapter mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter();
            cmd.Connection = con;
            con.Open();
            mySqlDataAdapter.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            DataTable data = new DataTable();
            mySqlDataAdapter.Fill(data);
            GridView1.DataSource = data;
            GridView1.DataBind();
            con.Close();


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int c = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                totalprice += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "price"));

                c++;

            }
            else if(e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[5].Text = string.Format("{0:c}", totalprice);
                e.Row.Cells[4].Text = string.Format("Total", totalprice);
                e.Row.Cells[1].Text = string.Format("{0}", c);
                e.Row.Cells[0].Text = string.Format("Total Ticekes sell", c);
                e.Row.Cells[3].Text = string.Format("{0}",(350- c));
                e.Row.Cells[2].Text = string.Format("Total Ticekes Remaind", (350 - c));

            }
        }

        protected void Delrte_Click(object sender, EventArgs e)
        {
            con = new MySql.Data.MySqlClient.MySqlConnection(@"server=localhost;user id=root;database=flight; password=SYSTEM;");
            con.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("Delete from flightasp where name='"+txtName.Text+"'", con);
            cmd.ExecuteNonQuery();
           // Response.Write("<Script language 'javascript'>alert('Data successfuly Deleted from database')</script>");
            Response.Write("<Script language 'javascript'>  alert('Data successfully deleted in data base')</Script>");
            con.Close();

        }

        protected void radlisttrip_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (ListItem item in radlisttrip.Items)
            {
                //if (radlisttrip.SelectedItem.Value == "Round")
                if (radlisttrip.SelectedItem.Text == "Simple")
                {

                    TextBoxreturn.Visible = false;
                    TextBoxreturn.Text =txtdattime.Text;
                }

            }

        }

        protected void ButtonRemove_Click(object sender, EventArgs e)
        {
           

        }

        protected void Buttonsearch_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
    
}