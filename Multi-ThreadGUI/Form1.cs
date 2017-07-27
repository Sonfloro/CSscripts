using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormTest
{
    public partial class Form1 : Form
    {
        // Thread objects for multi-threading
        Thread oThread;
        Thread oThread2;
        // Bool checks to see if a specific thread is active
        bool isThread1Active = false;
        bool isThread2Active = false;
        // Bool check that will let the thread exit on next iteration
        bool stopThread1 = false;
        bool stopThread2 = false;
        //Auto generated constructor
        public Form1()
        {
            InitializeComponent();
        }

        // Function to pass into oThread object
        private void thread1Spam()
        {
            // Loop while stopThread1 is false
            while(!stopThread1)
            {
                // Append the textbox
                richTextBox1.AppendText("Thread Started\n");
                // Sleep for 100 miliseconds between each loop
                Thread.Sleep(100);
            }
            
        }
        // Second function to pass into oThread2 object
        private void thread2Spam()
        {
            // Loop while stopThread2 is false
            while(!stopThread2)
            {
                // Append the textbox
                richTextBox2.AppendText("Thread2 Started\n");
                // Sleep
                Thread.Sleep(100);
            }
        }
        // Auto generated function from a button. Is called when button is clicked
        private void Thread1_Start_Click(object sender, EventArgs e)
        {
            // Check if we've recently stopped the thread
            if (stopThread1)
                // If we have update stopThread1
                stopThread1 = false;
            // Check if the thread is already active
            if (isThread1Active)
                // Append an error message
                richTextBox1.AppendText("Error: Thread is already active\n");
            else
            {
                // Initilize oThread with thread1Spam function.
                // This will assign a new thread to execute the thread1Spam function.
                oThread = new Thread(new ThreadStart(thread1Spam));
                // Start the thread
                oThread.Start();
                // Update isThread1Active
                isThread1Active = true;
            }
        }
        // Auto generated function from the stop button.
        private void Thread1_Stop_Click(object sender, EventArgs e)
        {
            // Check if the thread is active
            if (isThread1Active)
            {
                // If it is, abort the thread
                oThread.Abort();
                // Update bools
                stopThread1 = true;
                isThread1Active = false;
            } 
            // If not, append an error.
            else
                richTextBox1.AppendText("Error: Thread is already deactivated.\n");
        }
        // Auto generated function from the start thread button. Too lazy to update name
        private void button2_Click(object sender, EventArgs e)
        {
           // Check if we've stopped thread
            if (stopThread2)
                stopThread2 = false;
            // Check if thread is active
            if (isThread2Active)
                richTextBox2.AppendText("Error: Thread is already active\n");
            // If thread hasn't been activated, start the thread with thread2Spam function
            else
            {
                oThread2 = new Thread(new ThreadStart(thread2Spam));
                oThread2.Start();
                isThread2Active = true;
            }   
        }
        // Stop button for thread2
        private void button4_Click(object sender, EventArgs e)
        {
            // Same shit
            if (isThread2Active)
            {
                oThread2.Abort();
                stopThread2 = true;
                isThread2Active = false;
            }
            else
                richTextBox2.AppendText("Error: Thread is already deactivated.\n");
        }
        // Auto generated function for when user selects "Exit" from "File -> Exit"
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Update stopThread bools so the threads stop in their next interation
            stopThread1 = true;
            stopThread2 = true;
            // Sleep the main thread to assure both new threads have been aborted
            Thread.Sleep(200);
            // Exit the program
            Environment.Exit(0);
        }

    }
}