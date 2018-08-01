using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Net.Http; 

using TeleSharp.TL;
using TeleSharp.TL.Messages;
using TLSharp.Core;
using TLSharp.Core.Network;
using TLSharp.Core.Requests;
using TLSharp.Core.Utils;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.ObjectModel;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Layer
{
    public string Id { get; set; }
    public string ParentId { get; set; }
    public string Name { get; set; }
}
 


    public partial class MainWindow :  Window
    {

        //ObservableCollection<Layer> items = new ObservableCollection<Layer>
        //           {
        //               new Layer{Id = "1", ParentId = "null", Name = "First Layer" },
        //               new Layer{Id = "2", ParentId = "1", Name = "First SubLayer1" },
        //               new Layer{Id = "3", ParentId = "1", Name = "First SubLayer2" },
        //               new Layer{Id = "4", ParentId = "1", Name = "First SubLayer3" },
        //               new Layer{Id = "5", ParentId = "null", Name = "Second Layer" },
        //               new Layer{Id = "6", ParentId = "5", Name = "Second SubLayer1" },
        //               new Layer{Id = "7", ParentId = "5", Name = "Second SubLayer2" },
        //               new Layer{Id = "8", ParentId = "7", Name = "Sub -3" },
        //               new Layer{Id = "9", ParentId = "8", Name = "Sub -4" }
        //           };
        
        
        private TelegramClient client1;
        private string hash1;

        private string NumberToSendMessage { get; set; }
        
        private string ApiHash { get; set; }

        private int ApiId { get; set; }
        
        private string NumberToAuthenticate { get; set; }

        private string CodeToAuthenticate { get; set; }

        //private string hash;
        //private string client;

        class Assert
        {
            static internal void IsNotNull(object obj)
            {
                IsNotNullHanlder(obj);
            }

            static internal void IsTrue(bool cond)
            {
                IsTrueHandler(cond);
            }
        }

        internal static Action<object> IsNotNullHanlder;
        internal static Action<bool> IsTrueHandler;
       

        protected void Init(Action<object> notNullHandler, Action<bool> trueHandler)
        {
            IsNotNullHanlder = notNullHandler;
            IsTrueHandler = trueHandler;

            
            // Setup your API settings and phone numbers in app.config
            GatherTestConfiguration();

            //var item = items.Where(o => o.Id == "null");

            //foreach (var zone in items.Where(o => o.Id == "null"))
            //{
            //    GetZone(zone);
            //}        
        }
        void Initialize()
        {
            // ...
        }
        public void Init()
        { 
        
        
        }
        private void init()
        {
            // Do initialisation or something
        }

        //private void GetZone(Layer zone)
        //{
        //    var Parent = items.Where(o => o.Id == "null");  
        //}      

        private void GatherTestConfiguration()
        {
            string appConfigMsgWarning = "{0} not configured in app.config! Some tests may fail.";

            ApiHash = ConfigurationManager.AppSettings[ApiHash];
            if (string.IsNullOrEmpty(ApiHash))
                Debug.WriteLine(appConfigMsgWarning, ApiHash);

            var apiId = ConfigurationManager.AppSettings[ApiId];
            if (string.IsNullOrEmpty(apiId))
                Debug.WriteLine(appConfigMsgWarning, ApiId);
            else
                ApiId = int.Parse(apiId);

            NumberToAuthenticate = ConfigurationManager.AppSettings[NumberToAuthenticate];
            if (string.IsNullOrEmpty(NumberToAuthenticate))
                Debug.WriteLine(appConfigMsgWarning, NumberToAuthenticate);

            CodeToAuthenticate = ConfigurationManager.AppSettings[CodeToAuthenticate];
            if (string.IsNullOrEmpty(CodeToAuthenticate))
                Debug.WriteLine(appConfigMsgWarning, CodeToAuthenticate);
        
        }

        private TelegramClient NewClient()
        {

            try
            {   int     ApiId   = 54126;
                string  ApiHash = "dc4666bbe26d6c2c50ca21af6d8d3d1c";

                return new TelegramClient(ApiId, ApiHash);
            }
            catch (MissingApiConfigurationException ex)
            {
                throw new Exception("Please add your API settings to the `app.config` file. (More info: {MissingApiConfigurationException.InfoUrl})",
                                    ex);
            }
        }

        public virtual async Task AuthUser()
        {
           var client = NewClient();

            await client.ConnectAsync();
           
            // TB2.Text = "<+79055107243>";
  
            var hash = await client.SendCodeRequestAsync("79055107243");
            //var hash = await client.SendCodeRequestAsync(TB2.Text);
            //var code = CodeToAuthenticate; // you can change code in debugger too
            client1 = client;
            hash1 = hash;  
            

            //var code = TB3.Text; // you can change code in debugger too
            //string NumberToAuthenticate = "+79055107243";


            //if (String.IsNullOrWhiteSpace(code))
            //{
            //    throw new Exception("CodeToAuthenticate is empty in the app.config file, fill it with the code you just got now by SMS/Telegram");
            //}

            //TLUser user = null;
            //try
            //{
            //    user = await client.MakeAuthAsync(NumberToAuthenticate, hash, code);
            //}
            ////catch (CloudPasswordNeededException ex)
            ////{
            ////    var password = await client.GetPasswordSetting();
            ////    var password_str = PasswordToAuthenticate;

            ////    user = await client.MakeAuthWithPasswordAsync(password, password_str);
            ////}
            //catch (InvalidPhoneCodeException ex)
            //{
            //    throw new Exception("CodeToAuthenticate is wrong in the app.config file, fill it with the code you just got now by SMS/Telegram", ex);
            //}
            //Assert.IsNotNull(user);
            //Assert.IsTrue(client.IsUserAuthorized());
        }

        public virtual async Task SendMessageTest()
        {


            NumberToSendMessage = ConfigurationManager.AppSettings["NumberToSendMessage"];
            //if (string.IsNullOrWhiteSpace(NumberToSendMessage))
            //    throw new Exception("Please fill the '{nameof(NumberToSendMessage)}' setting in app.config file first");
            //NumberToSendMessage = "79670599815";
            // this is because the contacts in the address come without the "+" prefix
            var normalizedNumber = NumberToSendMessage.StartsWith("+") ?
                NumberToSendMessage.Substring(1, NumberToSendMessage.Length - 1) :
                NumberToSendMessage;

            var client = NewClient();

            await client.ConnectAsync();

            var result = await client.GetContactsAsync();

           // string NotRegisteredNumberToSignUp = "79162141367";

           //var hash = await client1.SendCodeRequestAsync("<+79162141367>");
          //  var registeredUser = await client1.SignUpAsync("79162141367", hash, "", "Peter", "Peter");

            //normalizedNumber = "+79670599815";

            //TLContact item = new TLContact();

            //result.contacts.lists.Add(item);

            //foreach (var it in Lb1.Items)
            //{
            TLUser item1 = new TLUser();

            item1.phone = NumberToSendMessage;  // Петя телефон
            item1.mutual_contact = true;
            item1.id = 275728079;
            item1.username = "@m_e_r_c";


            //var con =  client.contacts.importContacts;            

            result.users.lists.Add(item1);


            var user = result.users.lists.OfType<TLUser>().FirstOrDefault(x => x.phone == normalizedNumber);
            //var user = result.users.lists.OfType<TLUser>().FirstOrDefault();
            //var user = result.users.lists.OfType<TLUser>().First(x => x.username == "Peter");

            //var userByPhoneId = await client.SendCodeRequestAsync("79162141367"); //import by phone
            

            if (user == null)
            {
                throw new System.Exception("Number was not found in Contacts List of user: " + NumberToSendMessage);
            }
            
                //var contacts = new TLVector<T>();	            

           

               // await client.SendTypingAsync(new TLInputPeerUser() { user_id = user.id });
                Thread.Sleep(3000);
                //await client.SendMessageAsync(new TLInputPeerUser() { user_id = user.id }, TB1.Text);
            //}
        }


        public MainWindow()
        {
         //   InitializeComponent();
           
        
        }              
      
        private void Button_Click_Load(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string line;
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);

                while ((line = sr.ReadLine()) != null)
                {
                 //   Lb1.Items.Add(line);
                }

                sr.Close();

            }
        }

        private async void Button_Click_Auth(object sender, RoutedEventArgs e)
        {
            await AuthUser();
            //await SendMessageTest();
        }

        //private async void Button_Click_Confirmation(object sender, RoutedEventArgs e)
        //{

        //    //var code = TB3.Text;
        //    //var hash = await client.SendCodeRequestAsync(TB2.Text);
        //    string NumberToAuthenticate = "<+79055107243>";
        //    //if (String.IsNullOrWhiteSpace(TB3.Text))
        //    //{
        //    //    throw new Exception("CodeToAuthenticate is empty in the app.config file, fill it with the code you just got now by SMS/Telegram");
        //    //}

        //    TLUser user = null;
        //    try
        //    {
        //     //   user = await client1.MakeAuthAsync(NumberToAuthenticate, hash1, code);
        //    }
        //    //catch (CloudPasswordNeededException ex)
        //    //{
        //    //    //var password = await client.GetPasswordSetting();
        //    //    //var password_str = PasswordToAuthenticate;

        //    //    //user = await client.MakeAuthWithPasswordAsync(password, password_str);
        //    //}
        //    catch (InvalidPhoneCodeException ex)
        //    {
        //        throw new Exception("CodeToAuthenticate is wrong in the app.config file, fill it with the code you just got now by SMS/Telegram", ex);
        //    }
        //    //Assert.IsNotNull(user);
        //    //Assert.IsTrue(client.IsUserAuthorized());

        //}

        private async void Button_Click_Send(object sender, RoutedEventArgs e)
        {
            await SendMessageTest(); 
        }

        void cmbItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //...do your item selection code here...
           // CB2.IsEnabled = true;

        }

        private void cbSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Process excel = new Process();
            excel.StartInfo.FileName = @"C:\\Users\\Evg\\Downloads\\Extantion_15-21 последняя.xlsx";
            excel.Start();
            //excel.WaitForInputIdle();

            //IntPtr p = excel.MainWindowHandle;

           // Excel.Application xlApp;
           // Excel.Workbook xlWorkBook;
           // Excel.Worksheet xlWorkSheet;
           // object misValue = System.Reflection.Missing.Value;

           // xlApp = new Excel.Application();
           // xlWorkBook = xlApp.Workbooks.Open("C:\\Users\\Evg\\Downloads\\Extantion_15-21 последняя.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
           // xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

           //// MessageBox.Show(xlWorkSheet.get_Range("A1", "A1").Value2.ToString());

           // xlWorkBook.Close(true, misValue, misValue);
           // xlApp.Quit();

           // releaseObject(xlWorkSheet);
           // releaseObject(xlWorkBook);
           // releaseObject(xlApp);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            //catch (Exception ex)
            //{
            //    obj = null;
            //   // MessageBox.Show("Unable to release the Object " + ex.ToString());
            //}
            finally
            {
                GC.Collect();
            }
        } 
    }
}
