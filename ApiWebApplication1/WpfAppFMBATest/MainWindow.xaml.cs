using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Collections.ObjectModel;


namespace WpfAppFMBATest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class Category
    {
        public Category()
        {
            Children = new ObservableCollection<Category>();
        }

        public ObservableCollection<Category> Children
        {
            get;
            set;
        }
        public string Name { get; set; }

    }

    public class CategoriesTreeViewModel
    {
        
        public ObservableCollection<Category> FirstGeneration { get; set; }
        private static IEnumerable<Category> SomeCategories
        {
            get
            {
                var A   = new Category() { Name = "A" };
                var B   = new Category() { Name = "B" };
                var A1  = new Category() { Name = "A1" };
                var A2  = new Category() { Name = "A2" };
                var B1  = new Category() { Name = "B1" };
                var B2  = new Category() { Name = "B2" };

                A.Children.Add(A1);
                A.Children.Add(A2);
                B.Children.Add(B1);
                B.Children.Add(B2);

                yield return A;
                yield return B;
            }
        }

        public static CategoriesTreeViewModel CreateDefault
        {
            get
            {
                var result = new CategoriesTreeViewModel()
                {
                    FirstGeneration = new ObservableCollection<Category>(SomeCategories.ToList())
                };
                return result;
            }
        }
    }



    public class Family
    {
        public Family()
        {
            members = new ObservableCollection<FamilyMember>();
        }

        public string Name { get; set; }

        public ObservableCollection<FamilyMember> members { get; set; }
    }

    public class FamilyMember
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

   
    public class Parent1 {
       public string Id;
       public string ParentId;
       public Parent1() {
          member = new ObservableCollection<ChildZone>();        
       }

      public ObservableCollection<ChildZone> member { get; set; }
      public string Name;
    }    
    
    public class ChildZone
    {
        public string Id;
        public string ParentId;
        public string Name;
        public ObservableCollection<ChildZone> Childs;       
    }

    public class LayerTest
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }              

    }

    public class Layer
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public Layer(){
           members = new ObservableCollection<Layer1>();
         }
       public ObservableCollection<Layer1> members{ get; set; }

    }
    public class Layer1
    {
        public string Id { get; set; }
        public string ParentId {get;set;} 
        public string Name { get; set; }                
        public ObservableCollection<Layer1>  Childs { get; set; }
    } 

    
    
    public partial class MainWindow : Window
    {
     


     public ObservableCollection<Layer1> it_CG = new ObservableCollection<Layer1>();
     public  ObservableCollection<Layer1> it = new ObservableCollection<Layer1>();
     
     public  ObservableCollection<Layer1> items = new ObservableCollection<Layer1>()
                   {
                       new Layer1{Id = "1", ParentId = "null", Name = "First"},
                       new Layer1{Id = "2", ParentId = "1", Name = "First SubLayTest1" },
                       new Layer1{Id = "3", ParentId = "1", Name = "First SubLayTest2" },
                       new Layer1{Id = "4", ParentId = "1", Name = "First SubLayTest3" },
                       new Layer1{Id = "5", ParentId = "null", Name = "Second" },
                       new Layer1{Id = "6", ParentId = "5", Name = "МРУ" },
                       new Layer1{Id = "7", ParentId = "6", Name = "ЦГиЭ № 23" },
                       new Layer1{Id = "8", ParentId = "7", Name = "ПР3" },
                       new Layer1{Id = "9", ParentId = "6", Name = "ЦГиЭ №25" },
                       new Layer1{Id = "10", ParentId = "9", Name = "ПР7" },
                       new Layer1{Id = "11", ParentId = "10", Name = "ss6" },
                       new Layer1{Id = "12", ParentId = "11", Name = "ss7" },
                       new Layer1{Id = "13", ParentId = "1", Name = "Второй"},
                       new Layer1{Id = "14", ParentId = "13", Name = "третий"},
                       new Layer1{Id = "15", ParentId = "null", Name = "Third"},

                   };
  
        

        public MainWindow()
        {
            InitializeComponent();                       
            //this.DataContext = CategoriesTreeViewModel.CreateDefault;
           
            var item = items.Where(o => o.Id == "null");
                                              
            foreach (var zo in items.Where(o => o.ParentId == "null"))
            {                         
               Layer1 lr = new Layer1()
                {
                    Id = zo.Id,
                    ParentId = zo.ParentId,
                    Name = zo.Name,
                    Childs = new ObservableCollection<Layer1>()
                };

               GetChildren(lr);                    
      }
    }

     private void GetChildren(Layer1 source)   
    {         
            var children = items.Where(x => x.ParentId == source.Id).ToList();
            int i = (children).Count;
            if (i > 0)
            {
                foreach (var ch in children)
                {

                    //if (ch.Name.StartsWith("ЦГиЭ") == true )
                    //{
                    //    Layer1 lr1 = new Layer1
                    //    {
                    //        Id = ch.Id,
                    //        ParentId = ch.ParentId,
                    //        Name = ch.Name,
                    //        Childs = new ObservableCollection<Layer1>()
                    //    };
                        
                    //    GetChildren(lr1);
                    //}
                    //else
                    //{
                    Layer1 lr1 = new Layer1
                    {
                                 Id = ch.Id,
                                 ParentId = ch.ParentId,
                                 Name = ch.Name,
                                 Childs = new ObservableCollection<Layer1>()
                    };

                    //if (ch.Name.StartsWith("ЦГиЭ") == true)
                    //{
                    //      //var children1 = items.Where(x => x.ParentId == ch.Id).ToList();

                    //      getSubChild(source);

                    //      //foreach (var chi in children1)
                    //      //{

                    //      //    Layer1 lr2 = new Layer1
                    //      //    {
                    //      //        Id = ch.Id,
                    //      //        ParentId = ch.ParentId,
                    //      //        Name = ch.Name,
                    //      //        Childs = new ObservableCollection<Layer1>()
                    //      //    };

                    //      //    source.Childs.Add(lr2);
                    //      //   // GetChildren1(lr1);
                    //      //}
                    //}
                    //else
                    //{
                        source.Childs.Add(lr1);
                        GetChildren(lr1);
                    
                    //}

                    //}
                }

                if (source.ParentId == "null")
                {
                    it.Add(source);
                    it_CG.Add(source);                      
                    
                }
                          
            }
            else
            {
                if (source.ParentId == "null")
                it.Add(source);
            }

          
        }
           
    private void getSubChild(Layer1 ob)
    {

        var children1 = items.Where(x => x.ParentId == ob.Id).ToList();

        foreach (var ch in children1)
        {
        
        
        }
    }
    

        
    }
}
