using System;
using System.Collections.Generic;
using System.Text;

namespace Sorteren
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data={40,2,1,43,3,65,0,-1,58,3,42,4};
            int[] temp = new int[12];

          //  bubbleSort(data, data.Length);
          //  selectionSort(data, data.Length);
           //   insertionSort(data, data.Length);
            //    mergeSort(data,data.Length);
               QuickSort(data, data.Length);
                      
            for (int i = 0; i < data.Length; i++)
                Console.Write( " " +data[i]);

            Console.WriteLine();
            Console.WriteLine(zoek(data, data.Length,-1));
            
            Console.Read();
           
        }

 

        public static int zoek(int[] data, int n, int waarde)
        {
            int high =n, low = -1, mid;
                while (high - low > 1)
                {
                    mid = (low + high)/2;
                    if (data[mid] > waarde)
                        high = mid;
                    else
                        low = mid;
                }
              if (low == -1 || data[low] != waarde)
                  return Int32.MinValue;
              else
                  return low;
                }

        public static void swap(int[] data, int i, int j)
        //pre: 0<=i,j<data.length
        //post: data[i] en data[j] zijn verwisseld      
        {
            int temp;
            temp=data[i];
            data[i]=data[j];
            data[j]=temp;
        }

        public static void bubbleSort(int[] data, int n)
        //pre: 0<=n<=data.length
        //post: waarden in data[0..n-1] in dalende volgorde
        {
            int numSorted = 0; // aantal waarden op volgorde
            int index;

            while (numSorted < n)
            {
                //bubble omhoog
                for(index=1;index<n-numSorted;index++)
                {
                    if(data[index]<data[index-1])
                        swap(data,index,index-1);
                }
                numSorted++;
            }
        }

        public static void selectionSort(int[] data, int n)
        //pre: 0<=n<=data.length
        //post: waarden in data[0..n-1] in dalende volgorde
        {
            int numUnsorted = n;
            int index;
            int max; //index van de grootste waarde

            while (numUnsorted > 0)
            {
                // bepaal maximum waarde in array
                max = 0;
                for (index = 1; index < numUnsorted; index++)
                {
                    if (data[max] < data[index])
                        max = index;
                }
                swap(data, max, numUnsorted - 1);
                numUnsorted--;
            }
        }


        public static void insertionSort(int[] data, int n)
        //pre: 0<=n<=data.length
        //post: waarden in data[0..n-1] in dalende volgorde
        {
            int numSorted = 1; //aantal waarden op de juiste plaats
            int index;

            while (numSorted < n)
            {   //pak de 1e ongesorteerde waarde
                int temp = data[numSorted];
                // en insert deze 
                for(index =numSorted;index>0;index--)
                {
                    if(temp<data[index-1])
                    {
                        data[index]=data[index-1];
                    }
                    else
                    {
                        break;
                    }
                }
                //re insert waarde
                data[index] = temp;
                numSorted++;

            }
        }

        public static void mergeSort(int[] data, int n)
         //pre: 0<=n<=data.length
        //post: waarden in data[0..n-1] in dalende volgorde
        {
            mergeSortRecursief(data, new int[n], 0, n - 1);
        }

        private static void merge(int[] data, int[] temp, int low, int middle, int high)
            //pre: data[middle..high] en temp[low..middle] zijn dalend
            //post: data[low..high] bevat alle waarden in aflopende volgorde
        {
            int ri = low; //resultaat index
            int ti = low; // temp index
            int di = middle; // doel index

            // zolang 2 lijsten niet leeg zijn merge de kleinere waarde

            while (ti < middle && di <= high)
            {
                if (data[di] < temp[ti])
                {
                    data[ri++] = data[di++]; // kleinere zit in de hoogste data
                }
                else
                {
                    data[ri++] = temp[ti++]; // kleinere zit in lagere temp
                }
            }
            // mogelijk zitten er nog waarden in Temp
            while (ti < middle)
            {
                data[ri++] = temp[ti++];
            }

           
        }
 

        private static void mergeSortRecursief(int[] data, int[] temp, int low, int high)
        
        // pre: 0<=low,+high<data.length
        //post: waarden in data[low..high] zijn in aflopende volgorde
        {
            int n = high - low+1;
            int middle = low + n / 2;
            int i;

            if (n < 2) return; //zet laagste waarden in tem

            for (i = low; i < middle; i++)
            {
                temp[i] = data[i];
            }

            //sorteer laagste deel
            mergeSortRecursief(data, temp, low,middle-1);
            //sorteer bovenste helft array
            mergeSortRecursief(data, temp,middle,high);
            //merge beid delen
            merge(data, temp,low, middle, high);
  
        }

        //    http://www.cse.iitk.ac.in/users/dsrkg/cs210/applets/sortingII/mergeSort/mergeSort.html


        public static void QuickSort(int[] data, int n)
        //pre: 0<=n<=data.length
        //post: waarden in data[0..n-1] in dalende volgorde
        {
            quickSortRecusief(data, 0, n - 1);
        }


        private static int partition(int[] data, int left, int right)
        //pre left<=right
        //post: data[left] gezet in de juiste lokatie
        {
            while(true)
            {
                //verplaats rechter wijzer naar links
                while(left<right && data[left]<data[right])
                    right--;
                if(left<right) // stopvoorwaarde
                    swap(data,left++,right); 
                else 
                    return left; //plaats pivot
                // verplaats linker wijzer naar rechts
                while(left<right && data[left]<data[right])
                    left++;
                if(left<right)
                    swap(data,left,right--);
                else
                    return right; //plaats pivot
            }
        }


        public static void quickSortRecusief(int[] data, int low, int high)
        //pre:high>low
        //post: dat[low..high] in aflopende volgorde
        {
            int pivot; //de plaats van de meest linkse waarde
            if (low >= high)
                return;
             //Zet de meeste linkse waarde op de correcte plaats (pivot)
            pivot = partition(data, low, high);
            //1. Sorteer de lagere waarden
            quickSortRecusief(data, low, pivot - 1);
            // 2. sorteer de hogere waarden
            quickSortRecusief(data, pivot + 1, high);
            //3 Klaar



        }

    }
 }
