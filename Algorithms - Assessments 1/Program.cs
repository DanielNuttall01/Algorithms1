using System;
using System.Collections.Generic;
using System.IO;

namespace Algorithms___Assessments_1
{
    // Class object for Storing file data
    public class Networks
    {
        // Stores file name and values
        public string Name { get; }
        public int[] Values { get; set; }
        public int[] OriginalOrder { get; }


        // Constructor creates instances of the Class
        public Networks(string FileName, List<int> ValueList)
        {
            Name = FileName;
            Values = ValueList.ToArray();
            OriginalOrder = ValueList.ToArray();
        }
        // Function used to write the values to the console
        public void ReturnValues()
        {
            int count = 0;
            foreach (var item in Values)
            {
                // Is length is larger than 2048 writes every 50th value
                count++;
                if (Values.Length >= 2048)
                {
                    if ((count % 50) == 0)
                    {
                        Console.WriteLine(item);
                    }
                }
                // If less writes every 10th value
                else
                {
                    if ((count % 10) == 0)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }

    // Class stores all Algorithms used for sorting
    class SortingAlgorithms
    {
        // Quick sorts in ascending order
        static public void QuickSort_Ascending(int[] data, int start, int end)
        {
            // Sets starting values
            int i = start;
            int j = end;
            int pivot = data[((start + end) / 2)];

            // Reorders the collection
            do
            {
                while ((data[i] < pivot) && (i < end))
                    i++;
                while ((pivot < data[j]) && (j > start))
                    j--;

                if (i <= j)
                {
                    int temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            }
            // Recursively continue sorting the array
            while (i <= j);
            {
                if (start < j)
                    QuickSort_Ascending(data, start, j);
                if (i < end)
                    QuickSort_Ascending(data, i, end);
            }

        }
        // Quick sorts in descending order
        static public void QuickSort_Descending(int[] data, int start, int end)
        {
            // Sets starting values
            int i = start;
            int j = end;
            int pivot = data[((start + end) / 2)];

            // Reorders the collection
            do
            {
                while ((data[i] > pivot) && (i < end))
                    i++;
                while ((pivot > data[j]) && (j > start))
                    j--;

                if (i <= j)
                {
                    int temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            }
            // Recursively continue sorting the array
            while (i <= j);
            {
                if (start < j)
                    QuickSort_Descending(data, start, j);
                if (i < end)
                    QuickSort_Descending(data, i, end);
            }
        }
        // Merge sort in Ascending order
        public static void MergeSort_Ascending(int[] Data, int Start, int End)
        {
            if (Start < End)
            {
                // Sets the middle value
                int middle = (Start + End) / 2;

                // Recursively sorts the array
                MergeSort_Ascending(Data, Start, middle);
                MergeSort_Ascending(Data, middle + 1, End);

                // Merges the values in Ascening order
                MergeAscending(Data, Start, middle, End);
            }
        }
        public static void MergeAscending(int[] Data, int Start, int middle, int End)
        {
            // Sets required values
            int[] LeftArray = new int[middle - Start + 1];
            int[] RightArray = new int[End - middle];

            Array.Copy(Data, Start, LeftArray, 0, middle - Start + 1);
            Array.Copy(Data, middle + 1, RightArray, 0, End - middle);

            int i = 0;
            int j = 0;

            // Reorders the collection
            for (int k = Start; k < End + 1; k++)
            {
                if (i == LeftArray.Length)
                {
                    Data[k] = RightArray[j];
                    j++;
                }
                else if (j == RightArray.Length)
                {
                    Data[k] = LeftArray[i];
                    i++;
                }
                else if (LeftArray[i] <= RightArray[j])
                {
                    Data[k] = LeftArray[i];
                    i++;
                }
                else
                {
                    Data[k] = RightArray[j];
                    j++;
                }
            }
        }

        // Merge Sort in Descending
        public static void MergeSort_Descending(int[] Data, int Start, int End)
        {
            if (Start < End)
            {
                int middle = (Start + End) / 2;
                // Recursively sort the array
                MergeSort_Descending(Data, Start, middle);
                MergeSort_Descending(Data, middle + 1, End);
                // Merge data in Descending order
                MergeDescending(Data, Start, middle, End);
            }
        }
        public static void MergeDescending(int[] Data, int Start, int middle, int End)
        {
            // Sets start values
            int[] LeftArray = new int[middle - Start + 1];
            int[] RightArray = new int[End - middle];

            Array.Copy(Data, Start, LeftArray, 0, middle - Start + 1);
            Array.Copy(Data, middle + 1, RightArray, 0, End - middle);

            int i = 0;
            int j = 0;

            // Reorders the collection
            for (int k = Start; k < End + 1; k++)
            {
                if (i == LeftArray.Length)
                {
                    Data[k] = RightArray[j];
                    j++;
                }
                else if (j == RightArray.Length)
                {
                    Data[k] = LeftArray[i];
                    i++;
                }
                else if (LeftArray[i] >= RightArray[j])
                {
                    Data[k] = LeftArray[i];
                    i++;
                }
                else
                {
                    Data[k] = RightArray[j];
                    j++;
                }
            }
        }

        // Combines two data files
        static public object MergeFiles(int[] data1, int[] data2)
        {
            // Sets starting values
            int count1 = data1.Length;
            int count2 = data2.Length;
            int[] dataResult = new int[count1 + count2];
            int a = 0, b = 0;
            int i = 0;

            // Merges the the files in ascending order
            // Note to self: Possibly change at some point as just a slower version of merge sort.
            while (a < count1 && b < count2)
            {
                if (data1[a] <= data2[b])
                {
                    dataResult[i++] = data1[a++];
                }
                else
                {
                    dataResult[i++] = data2[b++];
                }
            }

            if (a < count1)
            {
                for (int j = a; j < count1; j++)
                {
                    dataResult[i++] = data1[j];
                }
            }
            else
            {
                for (int j = b; j < count2; j++)
                {
                    dataResult[i++] = data2[j];
                }
            }

            return dataResult;

        }
    }
    class SearchingAlgorithms
    {
        // Linear Search
        static public object Linear_Search(int[] Data, int Key, int[]OriginalOrder)
        {
            // Sets starting Values
            int max = Data.Length - 1;
            List<int> Positions = new List<int>();

            // Searches each position one by one
            for (int position = 0; position < max; position++)
            {
                // If values match adds postion data to the list
                if (Data[position] == Key)
                {
                    Positions.Add(position + 1);
                }
            }

            // Checks to see if key found
            if (Positions.Count > 0)
            {
                // Writes each found position to the console
                Console.WriteLine("\n{0} Found at position(s): ", Key);
                foreach (var Entry in Positions)
                {
                    Console.Write(Entry + ", ");
                }
                Console.WriteLine("");
            }
            // If key not found looks for next closest values
            else
            {
                Console.WriteLine("\nFailed to find value {0}. Searching for next closest value(s).", Key);
                // Sorts in ascending order
                SortingAlgorithms.QuickSort_Ascending(Data, 0, Data.Length - 1);
                // Calls binary search to find position data
                int[] newkeys = (int[])Binary_Search(Data, Key); //Converts to string and split
                foreach (var newkey in newkeys)
                {
                    Linear_Search(OriginalOrder, newkey, OriginalOrder);
                }

            }
            return -1;

        }
        // Uses Binary Search to find the position of the give value
        static public object Binary_Search(int[] data, int key)
        {
            int min = 0;
            int max = data.Length - 1;
            int mid = (min + max) / 2;

            // Commences search
            while (min <= max)
            {
                mid = (min + max) / 2;
                if (key == data[mid])
                {
                    return ++mid;
                }
                else if (key < data[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            // If value not found finds the next closest value
            if (key != data[mid])
            {
                int[] newkey = (int[])FindClosest(data, key, mid);
                return newkey;
            }
            return "None";
        }
        // Finds the closest value to the given key
        static public object FindClosest(int[] data, int key, int mid)
        {
            // Works out the difference between the closest values
            int updiff = data[mid + 1] - key;
            int downdiff = key - data[mid];
            List<int> KeysList = new List<int>();

            // Adds the value to a list
            if (updiff > downdiff)
            {
                KeysList.Add(data[mid]);
            }
            else if (updiff < downdiff)
            {
                KeysList.Add(data[mid + 1]);
            }
            // if difference is the same adds both values
            else
            {
                KeysList.Add(data[mid]);
                KeysList.Add(data[mid + 1]);
            }
            // Returns list of values as an array
            return KeysList.ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Gets the current file directory and finds the "networks" file
            string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "Networks");
            // Saves each Directory Path to a list
            var Directories = new DirectoryInfo(FilePath);

            // Creates a new list for the networks
            List<Networks> Networklist = new List<Networks>();

            // For each file in the Directory
            foreach (var file in Directories.GetFiles("*.txt"))
            {
                // Saves the full directory
                string filelocation = file.FullName;
                // Splits the file location and saves the name
                string[] LocationSplit = filelocation.Split(Path.DirectorySeparatorChar);
                string filename = LocationSplit[^1];
                // Reads each line of the file to an Array
                string[] lines = File.ReadAllLines(filelocation);
                // Creates a new list to save the integers
                List<int> integers = new List<int>();
                foreach (var line in lines)
                {
                    // Checks to see if it can be changed into an integer
                    if (int.TryParse(line, out int result))
                    {
                        // If so adds it to the list
                        integers.Add(result);
                    }
                }
                // Adds that array to the list
                Networklist.Add(new Networks(filename, integers));
            }
            // Sets values to be used later
            var ChosenFile = Networklist[1];
            int Length;

            while (true)
            {
                int Count = 1;
                // Prints a "menu" of each file name for the user to select
                Console.WriteLine("Which file would you like to organise:");
                Console.WriteLine("{0}) Merge files", Count);
                foreach (Networks network in Networklist)
                {
                    Count++;
                    Console.WriteLine("{0}) {1}", Count, network.Name);
                }

                // Makes sure the value is a number
                if (Int32.TryParse(Console.ReadLine(), out int MenuChoice) && MenuChoice <= Count && MenuChoice > 0)
                {
                    if (MenuChoice == 1)
                    {
                        Console.Clear();
                        while (true)
                        {
                            Count = 0;
                            Console.WriteLine("Which files would you like to Merge:");
                            foreach (Networks network in Networklist)
                            {
                                Count++;
                                Console.WriteLine("{0}) {1}", Count, network.Name);
                            }

                            // Gets the files the user wants to merge
                            Console.WriteLine("File 1: ");
                            if (Int32.TryParse(Console.ReadLine(), out int File1) && File1 <= Count && File1 > 0)
                            {
                                var ChosenFile1 = Networklist[File1 - 1];
                                int length1 = ChosenFile1.Values.Length;

                                Console.WriteLine("File 2: ");
                                if (Int32.TryParse(Console.ReadLine(), out int File2) && File2 <= Count && File2 > 0)
                                {
                                    var ChosenFile2 = Networklist[File2 - 1];
                                    int length2 = ChosenFile2.Values.Length;

                                    //Sorts both into Ascending Order
                                    SortingAlgorithms.QuickSort_Ascending(ChosenFile1.Values, 0, length1 - 1);
                                    SortingAlgorithms.QuickSort_Ascending(ChosenFile2.Values, 0, length2 - 1);

                                    //Performs the merge
                                    int[] MergeData = (int[])SortingAlgorithms.MergeFiles(ChosenFile1.Values, ChosenFile2.Values);
                                    List<int> MergeDataList = new List<int>();


                                    foreach (var item in MergeData)
                                    {
                                        MergeDataList.Add(item);
                                    }

                                    var NewFileName = ChosenFile1.Name + " & " + ChosenFile2.Name;
                                    Networklist.Add(new Networks(NewFileName.ToString(), MergeDataList));

                                    ChosenFile = Networklist[^1];
                                    Length = ChosenFile.Values.Length;
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid Option\n");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid Option\n");
                            }    
                        }
                    }
                    else
                    {
                        ChosenFile = Networklist[MenuChoice - 2];
                        Length = ChosenFile.Values.Length;
                    }

                    Console.Clear();
                    bool valid = false;
                    //Loops menu
                    while (valid != true)
                    {
                        Console.WriteLine("Would you like to view the file(s) {0} values in: \n1) Ascending Order \n2) Decending Order \n3) Find a specific Value", ChosenFile.Name);

                        if (Int32.TryParse(Console.ReadLine(), out int Action))
                        {
                            switch (Action)
                            {
                                // Sorts in Ascending Order
                                case 1:
                                    Console.WriteLine("\nAscending order: ");
                                    // If length 2048 values or more Merge Sorts
                                    if (Length >= 2048)
                                    {
                                        SortingAlgorithms.MergeSort_Ascending(ChosenFile.Values, 0, Length - 1);
                                    }
                                    // If smaller quick sorts
                                    else
                                    {
                                        SortingAlgorithms.QuickSort_Ascending(ChosenFile.Values, 0, Length - 1);
                                    }
                                    ChosenFile.ReturnValues();
                                    valid = true;
                                    break;

                                // Sorts in Descending Order
                                case 2:
                                    Console.WriteLine("\nDescending order: ");
                                    // If length 2048 values or more Merge Sorts
                                    if (Length >= 2048)
                                    {
                                        SortingAlgorithms.MergeSort_Descending(ChosenFile.Values, 0, Length - 1);
                                    }
                                    // If smaller quick sorts
                                    else
                                    {
                                        SortingAlgorithms.QuickSort_Descending(ChosenFile.Values, 0, Length - 1);
                                    }
                                    ChosenFile.ReturnValues();
                                    valid = true;
                                    break;

                                // Case 3 Search for value
                                case 3:
                                    Console.Clear();
                                    while (true)
                                    {
                                        Console.WriteLine("Please enter the value you'd like to find in file {0} :", ChosenFile.Name);
                                        if (Int32.TryParse(Console.ReadLine(), out int tempKey))
                                        {
                                            SearchingAlgorithms.Linear_Search(ChosenFile.Values, tempKey, ChosenFile.OriginalOrder);
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Invalid Option\n");
                                        }
                                    }
                                    valid = true;
                                    break;

                                // default if case is not selected
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Invalid option\n");
                                    break;

                            }
                        }
                        // Catches non integer input
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid option\n");
                        }
                    }
                    // Ends while loop
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid option\n");
                }
            }
        }
    }
}