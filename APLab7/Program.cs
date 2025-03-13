using System.Threading.Tasks;
using System.Threading;

namespace APLab7
{
    class LockExample
    {

        static int counter = 0;

        static void Main(string[] args)
        {
            LockExample demoLock = new LockExample();

            Thread t1 = new Thread(new ThreadStart(demoLock.Incrementer));
            Thread t2 = new Thread(new ThreadStart(demoLock.Incrementer));

            t1.Start();   //start thread t1 which increments

            //name the thread
            t1.Name = "T1";

            t2.Start();   //start thread t2 which increments as well

            //name the thread
            t2.Name = "T2";

            Console.ReadLine();

        }

        //without Synchronisation
        //public void Incrementer()
        //{
        //    try
        //    {
        //        while (counter < 10)
        //        {
        //            int temp = counter;
        //            temp++; // increment

        //            // simulate some work in this method
        //            Thread.Sleep(1);

        //            // assign the incremented value and display the results
        //            counter = temp;
        //            Console.WriteLine("Thread {0}. Incrementer: {1}", Thread.CurrentThread.Name, counter);
        //        }
        //    }
        //    catch (ThreadInterruptedException)
        //    {
        //        Console.WriteLine("Thread {0} interrupted! ", Thread.CurrentThread.Name);
        //    }
        //    finally
        //    {
        //        Console.WriteLine("Thread {0} Exiting. ", Thread.CurrentThread.Name);
        //    }
        //}

        //// with Synchronisation
        public void Incrementer()
        {
            try
            {
                while (counter < 10)
                {
                    int temp;
                    lock (this)
                    {
                        temp = counter;
                        temp++;
                        Thread.Sleep(1);
                        counter = temp;
                    }
                    // assign the incremented value and display the results
                    Console.WriteLine("Thread {0}. Incrementer: {1}", Thread.CurrentThread.Name, temp);
                }
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Thread {0} interrupted! ", Thread.CurrentThread.Name);
            }
            finally
            {
                Console.WriteLine("Thread {0} Exiting. ", Thread.CurrentThread.Name);
            }
        }
    }
}
