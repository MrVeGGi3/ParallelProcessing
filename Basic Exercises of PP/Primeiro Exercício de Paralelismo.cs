/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
using System.Threading;

class HelloWorld {
  public static int[] VetX = new int [4];
  public static int[] VetY = new int [4];
  static void Main() {
    Random rnd = new Random();
    Thread t1 = new Thread(Calc1);
    Thread t2 = new Thread(Calc2);
    for(int i = 0; i < VetX.Length; i++){
        VetX[i] = rnd.Next(0,4);
        Console.WriteLine("VetX {0} = {1}", i, VetX[i]);
    }
    for(int i = 0; i < VetY.Length; i++){
        VetY[i] = rnd.Next(0,4);
        Console.WriteLine("VetY {0} = {1}", i, VetY[i]);
    }
    t1.Start();
    t2.Start();
    t1.Join();
    t2.Join();
  }
  static void Calc1()
    {
       int i = 0;
       while( i < VetX.Length){
            for(int n = 1; n<VetX.Length/2; n++){
                if(VetX[i] == VetX[i+n] && VetY[i] == VetY[i+n]){
                     Console.WriteLine("Há sobreposição nos pontos: {0} e {1}", i, i+n);
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
                if(VetX[i] == VetX[i+n] && VetY[i] == VetY[i+n]){
                    Console.WriteLine("Há sobreposição nos pontos: {0} e {1}", i, i+n);
                }  
            }
            i++;
        }
  }
}