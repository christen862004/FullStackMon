namespace FullStackMon.Models
{
    public class TestClass
    {
        public int Add(int x,int y) 
        { return x + y; }

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
