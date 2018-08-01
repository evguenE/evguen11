using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Xml.Schema;
using System.IO;


namespace TestWPF
{
    public partial class Export : Form
    {
        public Export()
        {
            InitializeComponent();
        }
        public string UploadFilePath { get; set; }
        public static string sSelectedFile;       
        private static bool isValid = true;
 
        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
                sSelectedFile = choofdlog.FileName;
            else
                sSelectedFile = string.Empty;

            textBox1.Text = sSelectedFile;            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            XmlSchemaSet schemaSet = new XmlSchemaSet();           
            schemaSet.Add(null, "XMLImport1.xsd");

            //Validate             
            Validate(sSelectedFile, schemaSet);
           
            SqlCommand command;
            SqlDataAdapter adpter = new SqlDataAdapter();
            DataSet   ds = new DataSet();
            DataSet   dsDb = new DataSet();

            XmlReader xmlFile;
            string    sql = null;          

            int       CustomerID = 0;
            string    OrderDate = null;           
            string    OrderValue = null;
            int       OrderStatus = 0;
            int       OrderType = 0;

            if (isValid)
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["customConnection"].ConnectionString);
                try
                {
                    xmlFile = XmlReader.Create(sSelectedFile, new XmlReaderSettings());
                    ds.ReadXml(xmlFile);
                    int i = 0;
                    connection.Open();
                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        CustomerID = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);
                        OrderDate = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                        OrderValue = ds.Tables[2].Rows[i].ItemArray[0].ToString();
                        OrderStatus = Convert.ToInt32(ds.Tables[2].Rows[i].ItemArray[1]);
                        OrderType = Convert.ToInt32(ds.Tables[2].Rows[i].ItemArray[2]);

                        sql = "INSERT INTO [Order] (CustomerID, OrderDate,  OrderValue, OrderStatus, OrderType) VALUES(" + CustomerID + ",'" + OrderDate + "','" + OrderValue + "'," + OrderStatus + "," + OrderType + ")";
                        command = new SqlCommand(sql, connection);
                        adpter.InsertCommand = command;
                        adpter.InsertCommand.ExecuteNonQuery();
                    }
                    label2.Text = "Successfuly Inserted data";

                    sql = "select OrderID,  CustomerID, OrderDate,  OrderValue, OrderStatus,    DateTimeAdded,  DateTimeUpdated,    OrderType from [Order]";
                    command = new SqlCommand(sql, connection);
                    adpter.SelectCommand = command;
                    adpter.SelectCommand.ExecuteNonQuery();

                    adpter.Fill(dsDb, "Order");
                    DataGridView grdv = new DataGridView();
                    grdv.Width = 900;
                    grdv.DataSource = dsDb.Tables["Order"];
                    panel1.Controls.Add(grdv);
                    
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
            else
             label1.Text = "Duplicates";
            
        }


        private static void Validate(String filename, XmlSchemaSet schemaSet)
        {                     

            XmlSchema compiledSchema = null;
            foreach (XmlSchema schema in schemaSet.Schemas())
            {
                compiledSchema = schema;
            }

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(compiledSchema);
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
            settings.ValidationType = ValidationType.Schema;

            //Create the schema validating reader.
            XmlReader vreader = XmlReader.Create(filename, settings);

            while (vreader.Read()) { }

            //Close the reader.
            vreader.Close();
        }

        //Display any warnings or errors.
        private static void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            
            
            if (args.Severity == XmlSeverityType.Error)  //if duplicate 
            {
                isValid = false;
                Console.WriteLine("\tValidation error: " + args.Message);

                XmlReader xmlFile = XmlReader.Create(sSelectedFile, new XmlReaderSettings());
                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);
                string xmlInput = ds.GetXml();
                string csvOut = string.Empty;
                XDocument doc = XDocument.Parse(xmlInput);
                StringBuilder sb = new StringBuilder(100000);
                foreach (XElement node in doc.Descendants("Orders"))
                {
                    foreach (XElement innerNode in node.Elements())
                    {
                        //"{0}," give you the output in Comma seperated format.
                        sb.AppendFormat("{0},", innerNode.Value);
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.AppendLine();
                }

                
                csvOut = sb.ToString();
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                //write to file .csv
                using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\WriteLines.csv", true)) 
                {
                    outputFile.WriteLine(csvOut);
                    outputFile.Close();
                }                                               
            }
           
        }

       
    }
}
