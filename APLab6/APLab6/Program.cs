//using System;
//using System.Text;
//using System.Threading.Tasks;
//using System.Threading;

//namespace APLab6
//{
//    class Program
//    {
//        //The priority of a thread can be either:
//        // - Lowest (0)
//        // - BelowNormal (1)
//        // - Normal (2) - default priority
//        // - AboveNormal (3)
//        // - Highest (4)

//        static bool keepalive = true;
//        static Thread t1 = new Thread(new ThreadStart(Incrementer));
//        static Thread t2 = new Thread(new ThreadStart(Decrementer));

//        static public void Incrementer()
//        {
//            //for (int i = 0; i <= 10; i++)
//            //    Console.WriteLine("{0} - {1}", t1.Name, i);

//            int number = 0;

//            while (keepalive)
//                number++;

//            Console.WriteLine("Thread {0} has counted to {1}", Thread.CurrentThread.Name, number);

//        }

//        static public void Decrementer()
//        {
//            //for (int i = 10; i >= 0; i--)
//            //    Console.WriteLine("{0} - {1}", Thread.CurrentThread.Name, i);

//            int number = 0;

//            while (keepalive)
//                number++;

//            Console.WriteLine("Thread {0} has counted to {1}", Thread.CurrentThread.Name, number);

//        }

//        //create thread using the ParameterizedThreadStart delegate
//        //static Thread t3 = new Thread(new ParameterizedThreadStart(ThreadMethodWithParameter));
//        static Thread t3 = new Thread(ThreadMethodWithParameter);


//        //the method outlining the code for thread t3
//        static public void ThreadMethodWithParameter(Object o)
//        {
//            int number = (int)o;
//            Console.WriteLine("\n\n{0} got some input data = {1}\n\n", Thread.CurrentThread.Name, number);
//        }

//        //we are now replacing the named method with an anonymous one
//        static Thread t4 = new Thread(delegate () {
//            Console.WriteLine("\n\nHello from an unnamed method");
//            Console.WriteLine("We did manage to make this method an anonymous one\n\n");
//        });

//        //create a thread using an anonymous method which takes one object as parameter
//        static Thread t5 = new Thread(delegate (Object o) {
//            int number = (int)o;
//            Console.WriteLine("\n\nHello from an unnamed method with input data = {0}", number);
//            Console.WriteLine("We did manage to make this method an anonymous one\n\n");
//        });

//        static Thread t6 = new Thread(delegate (Object o) {
//            //we are dealing with an anonymous method which has only one line of code
//            //calling another named method
//            FalseWayOfPassingInputDataToTheThread((int)o, "Hello");
//        });

//        //create a named method – notice that this method can have any number of parameters
//        static void FalseWayOfPassingInputDataToTheThread(int i, string s)
//        {
//            Console.WriteLine("\n\n{0} from a named method with input data = {1}", s, i);
//            Console.WriteLine("We did manage to make this method look like we input some data into the thread\n\n");
//        }

//        static Thread t7 = new Thread(delegate () {
//            //we are dealing with an anonymous method which has only one line of code
//            //calling another named method
//            FalseWayOfPassingInputDataToTheThread(1000, "Hi");
//        });

//        static void Main(string[] args)
//        {
//            //name threads t1 and t2
//            t1.Name = "Incrementer thread";
//            t2.Name = "Decrementer thread";

//            //start threads t1 and t2
//            t1.Start();
//            t2.Start();


//            //change the priority of the threads
//            t1.Priority = ThreadPriority.BelowNormal;
//            t2.Priority = ThreadPriority.AboveNormal;

//            Console.WriteLine("Thread t1 has priority {0} meaning numerical value {1}", t1.Priority, (int)t1.Priority);
//            Console.WriteLine("Thread t2 has priority {0} meaning numerical value {1}", t2.Priority, (int)t2.Priority);

//            //put the main thread to sleep (block it) for 2 seconds
//            Thread.Sleep(2000);

//            keepalive = false;

//            t3.Name = "Thread_t3";

//            t3.Start(5);
//            t4.Start();
//            t5.Start(20);
//            t6.Start(100);
//            t7.Start();

//            //using lambda expression to create threads
//            Thread t8 = new Thread(new ThreadStart(
//                () =>
//                {
//                    Console.WriteLine("Hello from a lambda expression");
//                    Console.WriteLine("I look a bit funny but works well");
//                }
//                ));
//            t8.Start();

//            //using lambda expression to create thread
//            Thread t9 = new Thread(
//                () =>
//                {
//                    FalseWayOfPassingInputDataToTheThread(259, "How are you");
//                }
//                );

//            t9.Start();

//            // getting even lazyer and decide not to even name the thread object
//            // using lambda expression
//            new Thread(
//                () => FalseWayOfPassingInputDataToTheThread(500, "How are you doing")

//                ).Start();

//            // we can use lambda expression with an object parameter
//            Thread t10 = new Thread(
//                (Object o) =>
//                {
//                    FalseWayOfPassingInputDataToTheThread((int)o, "How are you");
//                }
//                );

//            t10.Start(300);
//            Console.ReadLine();
//        }
//    }
//}
using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // Creating threads with different array sizes
        Thread thread1 = new Thread(() => FillArray(10));
        Thread thread2 = new Thread(() => FillArray(50));

        // Naming threads
        thread1.Name = "Thread-1";
        thread2.Name = "Thread-2";

        // Setting thread priorities
        thread1.Priority = ThreadPriority.Lowest;   // Lowest priority
        thread2.Priority = ThreadPriority.Highest;  // Highest priority

        // Setting thread2 as a background thread
        thread2.IsBackground = true;

        // Displaying thread properties before starting
        Console.WriteLine($"{thread1.Name}: Priority = {thread1.Priority}, IsBackground = {thread1.IsBackground}");
        Console.WriteLine($"{thread2.Name}: Priority = {thread2.Priority}, IsBackground = {thread2.IsBackground}");

        // Starting threads
        thread1.Start();
        thread2.Start();

        // Ensuring the main thread waits for thread1 to finish
        thread1.Join();

        Console.WriteLine("Main thread execution complete.");
    }

    static void FillArray(int size)
    {
        int[] arr = new int[size];
        string threadName = Thread.CurrentThread.Name; // Get current thread's name
        ThreadPriority priority = Thread.CurrentThread.Priority; // Get thread priority

        for (int i = 0; i < size; i++)
        {
            arr[i] = i + 1; // Assigning consecutive values
            Console.WriteLine($"{threadName} (Priority: {priority}): arr[{i}] = {arr[i]}");
            Thread.Sleep(50); // Simulating a delay for visibility
        }

        // Printing the full array when done
        Console.WriteLine($"\n{threadName} Final Array: [{string.Join(", ", arr)}]\n");
    }
}
