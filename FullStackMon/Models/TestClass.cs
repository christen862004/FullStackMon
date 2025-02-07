namespace FullStackMon.Models
{
    interface ISort
    {
        void Sort(int[] arr);
    }
    class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        { }
    }
    class SelectionSort:ISort/*open for extend*/
    {
        public void Sort(int[] arr)
        { }

    }
    class ChrisSort : ISort
    {
        public void Sort(int[] arr)
        {
            throw new NotImplementedException();
        }
    }
    //DIP :dont mae high level class based low level base
    //      high level class dependon on absr=traction | interface
    class MyList//MyList  not depnednce Bubble sort (tigh couple) (lossly Couple) IOC
    {
        int[] arr;
        ISort sortAlg;
        public MyList(ISort sort)//design dependance inject
        {
            arr = new int[10];
            sortAlg = sort; //new BubbleSort();
        }
        public void SortArr()
        {
            sortAlg.Sort(arr);
        }
    }

    public class TestClass
    {
        Dictionary<string, object> data;
        public dynamic bag
        {
            get { return data.First(); }
            set { }
        }


        public int Add(int x,int y) 
        {
            MyList intlist = new MyList(new BubbleSort());
            MyList intlist2 = new MyList(new SelectionSort ());
            MyList intlist3 = new MyList(new ChrisSort ());


            return x + y; }

        public void DisplaySum()
        {
            dynamic x1 = 10;
            dynamic x2 = "asdfsad";
            dynamic x3 = new Student();
            
            //Console.WriteLine(x1.Name);//Exception
            
            int a = 10;int b = 20;
            Add(a, b);
        }
    }
}
