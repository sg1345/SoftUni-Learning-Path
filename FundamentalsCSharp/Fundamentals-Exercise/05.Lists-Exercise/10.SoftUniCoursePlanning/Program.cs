/*
lesson1, lesson2, lesson3
Add:lesson5
Add:lesson5
Add:lesson1
course start 
//Add correct//

lesson1, lesson2, lesson3
Insert:lesson5:-10
Insert:lesson3:1
Insert:lesson10:3
Insert:lesson0:0
Insert:lesson10:3
course start
//Insert correct//

lesson1, lesson1-Exercise, lesson2, lesson2.5, lesson3, lesson3-Exercise
Remove:lesson10
Remove:lesson1
Remove:lesson2
Remove:lesson3
course start
//Remove correct//

lesson1, lesson1-Exercise, lesson2, lesson2.5, lesson3, lesson3-Exercise
Swap:lesson1:lesson3
Swap:lesson2:lesson2.5
Swap:lesson1:lesson2.5
Swap:lesson3:lesson2.5
Swap:lesson1:lesson2.5
course start
//Swap correct//

lesson1, lesson1-Exercise, lesson2, lesson2.5, lesson3, lesson3-Exercise

 */


using System.Collections.Generic;
using System.Xml.Linq;

internal class Program
{
    static void Main()
    {
        List<string> schedule = ReadListOfStrings(", ");

        var input = string.Empty;
        while ((input = Console.ReadLine()) != "course start")
        {
            var command = input.Split(":");

            switch(command[0])
            {
                case "Add":
                    var lessonTitle = command[1];
                    
                    AddLesson(lessonTitle,schedule);

                    break;
                case "Insert":
                    lessonTitle = command[1];
                    var index = int.Parse(command[2]);

                    InsertLesson(lessonTitle, index, schedule);
                    break;
                case "Remove":
                    lessonTitle= command[1];

                    RemoveLesson(lessonTitle, schedule);
                    break;
                case "Swap":
                    var firstLessonTitle = command[1];
                    var secondLessonTitle = command[2];

                    SwapLessons(firstLessonTitle, secondLessonTitle, schedule);
                    break;
                case "Exercise":
                    lessonTitle = command[1];

                    AddExercise(lessonTitle, schedule);

                    break;
            }
        }
        for (int i = 0; i < schedule.Count; i++)
        {
            Console.WriteLine($"{i+1}.{schedule[i]}");
        }
    }
    static void AddLesson(string element,List<string> list)
    {
        if (NotExist(element,list))
        {
            list.Add(element);
        }        
    }
    static void InsertLesson(string element, int index, List<string> list)
    {
        if (NotExist(element, list) && IndexExists(index, list.Count))
        {
            list.Insert(index, element);
        }
    }
    static void RemoveLesson(string element, List<string> list)
    {
        if (NotExist(element, list))
        {
            return;
        }

        if (ExerciseExist(element, list))
        {
            list.Remove($"{element}-Exercise");
        }

        list.Remove(element);
        
    }
    static void SwapLessons(string firstElement, string secondElement, List<string> list)
    {
        var firstElementIndex = 0;
        var secondElementIndex = 0;

        if(NotExist(firstElement,list) || NotExist(secondElement,list))
        {
            return;
        }

        firstElementIndex = list.FindIndex(0,element => element == firstElement);
        secondElementIndex = list.FindIndex(0,element => element == secondElement);
            
        list.RemoveAt(firstElementIndex);
        list.Insert (firstElementIndex, secondElement);
        
        list.RemoveAt (secondElementIndex);
        list.Insert(secondElementIndex,firstElement);

        if (ExerciseExist(firstElement, list))
        {
            list.RemoveAt(firstElementIndex + 1);
            firstElementIndex = list.FindIndex(0, element => element == firstElement);
            list.Insert (firstElementIndex + 1, $"{firstElement}-Exercise");
        }

        if(ExerciseExist(secondElement, list))
        {
            list.RemoveAt(secondElementIndex + 1);
            secondElementIndex = list.FindIndex(0, element => element == secondElement);
            list.Insert(secondElementIndex + 1, $"{secondElement}-Exercise");
        }

    }
    static void AddExercise(string element, List<string> list)
    {
        var exercise = $"{element}-Exercise";

        if (ExerciseExist(element, list))
        {
            return;
        }
        
        if (NotExist(element, list))
        {
            list.Add(element);
            list.Add(exercise);            
        }
        else
        {
            var index = list.FindIndex(0, item => item == element);
            
            list.Insert(index + 1, exercise);
            
        }
    }

    static bool ExerciseExist(string element, List<string> list)
    {
         return list.Exists(exercise => exercise == $"{element}-Exercise");
    }
    static bool NotExist(string element, List<string> list)
    {
        return list.All(currentSubject => currentSubject  != element);
    }
    private static bool IndexExists(int index, int length)
    {
        if(index >= 0 & index < length)
        {
            return true;
        }
        return false;
    }


    static List<int> ReadListOfIntegers(string separator = " ")
    {
        return Console.ReadLine().Split(separator).Select(int.Parse).ToList();
    }
    static List<double> ReadListOfDoubles(string separator = " ")
    {
        return Console.ReadLine().Split(separator).Select(double.Parse).ToList();
    }
    static List<String> ReadListOfStrings(string separator = " ")
    {
        return Console.ReadLine().Split(separator).ToList();
    }

    static void PrintListOfIntegers(List<int> listInput, string separator = " ")
    {
        Console.WriteLine(string.Join(separator, listInput));
    }
    static void PrintListOfDoubles(List<double> listInput, string separator = " ")
    {
        Console.WriteLine(string.Join(separator, listInput));
    }
    static void PrintListOfStrings(List<string> listInput, string separator = " ")
    {
        Console.WriteLine(string.Join(separator, listInput));
    }
    static void PrintArrayOfIntegers(int[] array, string separator = " ")
    {
        Console.WriteLine(string.Join(separator, array));
    }
}