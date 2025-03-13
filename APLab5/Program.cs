namespace APLab5
{
    class Program
    {
        //create the threads – this does not start the threads though
        static Thread t1 = new Thread(new ThreadStart(Incrementer));
        static Thread t2 = new Thread(new ThreadStart(Decrementer));


        static void Main(string[] args)
        {

            t1.Start();   //start the thread which increments

            t2.Start();   //starts the thread that decrements

            Console.ReadLine();  //we need this so the console does not disappear 
        }


        public static void Incrementer()
        {
            // Keep the following line of code commented for now.
            // It’s role is to let Thread2 run to completion before Thread1 can start 
            // running its code. 
             t2.Join();

            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Incrementer: {0}", i);

                //Keep the following line of code commented for now.
                //It’s role is to keep Thread1 idle (blocked) for 1 millisecond.
                //Thread.Sleep(1);

                // Console.ReadLine();
            }
            Console.WriteLine("Incrementer is now finished");
        }
        public static void Decrementer()
        {

            //Keep the following line of code commented for now
            t1.Join();

            for (int i = 10; i >= 0; i--)
            {
                Console.WriteLine("Decrementer: ==========  {0}", i);

                //Thread.Sleep(1);

                // Console.ReadLine();
            }

            Console.WriteLine("Decrementer is now finished");
        }
    }

}
