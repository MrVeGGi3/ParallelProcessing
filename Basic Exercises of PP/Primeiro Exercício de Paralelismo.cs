/******************************************************************************
Parallelizing one verification in the (X,Y) axis of one video game,
To see if exists two objects overlaying each other.

*******************************************************************************/
using System;
using System.Threading; 

class HelloWorld {
  public static int[] VetX = new int [4]; //declaring VetX as point positions of the objects(four);
  public static int[] VetY = new int [4]; //declaring VetY as a point positions of the objects(four);
  static void Main() {
    Random rnd = new Random();
    Thread t1 = new Thread(Calc1); //instantiate the first thread;
    t1.Start(); //Start the first Thread;
    Thread t2 = new Thread(Calc2);//instantiate the second thread;
    t2.Start();//Start the second Thread;
    for(int i = 0; i < VetX.Length; i++){
        VetX[i] = rnd.Next(0,255); 
        Console.WriteLine("VetX {0} = {1}", i, VetX[i //positions generator of X;
    }
    for(int i = 0; i < VetY.Length; i++){
        VetY[i] = rnd.Next(0,255);
        Console.WriteLine("VetY {0} = {1}", i, VetY[i]); //positions generator of Y;
    }
    t1.Join(); //block thread
    t2.Join();//block thread
  }
  static void Calc1()
    {
       int i = 0;
       while( i < VetX.Length){
            for(int n = 1; n<VetX.Length/2; n++){
                if(VetX[i] == VetX[i+n] && VetY[i] == VetY[i+n]){ //checks if (X1, Y1) = (X2,Y2) in the first half
                     Console.WriteLine("Overlay in the Points: {0} e {1}", i, i+n);
                }  
            }
            i++;
        }   
    }
  static void Calc2()
  {
       int i = 0;
       while(i < VetY.Length){
            for(int n = VetX.Length/2; n<VetY.Length; n++){
                if(VetX[i] == VetX[i+n] && VetY[i] == VetY[i+n]){//checks if (X1, Y1) = (X2,Y2) in the second half
                    Console.WriteLine("Overlay in the points: {0} e {1}", i, i+n);
                }  
            }
            i++;
        }
  }
}
