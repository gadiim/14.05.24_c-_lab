using _14._05._24_c__lab;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _14._05._24_c__lab.Student;

//Тема: Вступ до LINQ
//Модуль 13. Ч. 1

namespace _14._05._24_c__lab
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Завдання 1:
            //Для масиву цілих реалізуйте наступні запити:
            // Отримати весь масив цілих.
            // Отримати парні цілі.
            // Отримати непарні цілі.
            // Отримати значення більше заданого.
            // Отримати числа в заданому діапазоні.
            // Отримати числа, кратні семи.Результат відсортуйте за
            //зростанням.
            // Отримати числа, кратні восьми.Результат відсортуйте за
            //спаданням.

            Console.WriteLine($"Task 1\n");

            int[] array_1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            Console.Write("integer numbers:\t\t");
            var selected_integers = from i in array_1 select i;
            foreach (var i in selected_integers)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            Console.Write("integer numbers:\t\t");
            var selected_integers_l = array_1.Select(i => i);
            Display(selected_integers_l);

            Console.Write("even numbers:\t\t\t");
            var selected_evens = array_1.Where(i => i % 2 == 0);
            Display(selected_evens);

            Console.Write("odd numbers:\t\t\t");
            var selected_odds = array_1.Where(i => i % 2 != 0);
            Display(selected_odds);

            Console.Write("more then 5 numbers:\t\t");
            var selected_max_then = array_1.Where(i => i > 5);
            Display(selected_max_then);

            Console.Write("in range 3-6 numbers:\t\t");
            var selected_in_range = array_1.Where(i => (i >= 3 && i <= 6));
            Display(selected_in_range);

            Console.Write("multiples of 7 numbers:\t\t");
            var selected_by_mult_7 = array_1.Where(i => i % 7 == 0).OrderBy(i => i);
            Display(selected_by_mult_7);

            Console.Write("multiples of 8 numbers:\t\t");
            var selected_by_mult_8 = array_1.Where(i => i % 8 == 0).OrderByDescending(i => i);
            Display(selected_by_mult_8);

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.Clear();

            //Завдання 2:
            //Для масиву рядків з назвою міст, реалізуйте наступні запити:
            // Отримати весь масив міст.
            // Отримати міста з довжиною назви, що дорівнює заданому.
            // Отримати міста, назви яких починаються з літери A.
            // Отримати міста, назви яких закінчуються літерою M.
            // Отримати міста, назви яких починаються з літери N і
            //закінчуються літерою K.
            // Отримати міста, назви яких починаються з Ne. Результат
            //відсортувати за спаданням.

            Console.WriteLine($"Task 2\n");

            string[] cities = { "Adelaide", "Albany", "Armadale", "Armidaleim", "Mandurah", "Melbourne", "Mildura", "Newcastle", "Newmarkek" };

            Console.Write("all cities:\t\t\t");
            var all = cities;
            Display(all);

            Console.Write("cities starts \"A\":\t\t");
            var starts_a = cities.Where(c => c.StartsWith("A"));
            Display(starts_a);

            Console.Write("cities ends \"M\":\t\t");
            var ends_m = cities.Where(c => c.ToUpper().EndsWith("M"));
            Display(ends_m);

            Console.Write("cities starts \"N\" ends \"K\":\t");
            var starts_n_ends_k = cities.Where(c => c.ToUpper().StartsWith("N") && c.ToUpper().EndsWith("K"));
            Display(starts_n_ends_k);

            Console.Write("cities starts \"Ne\":\t\t");
            var starts_ne = cities.Where(c => c.StartsWith("Ne")).OrderByDescending(c => c);
            Display(starts_ne);

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.Clear();

            //Завдання 3:
            //Реалізуйте тип користувача «Студент» з інформацією про ім'я,
            //прізвище, вік, назву навчального закладу.
            //Для масиву «Студент» реалізуйте наступні запити:
            // Отримати весь масив студентів.
            // Отримати список студентів з ім'ям Boris.
            // Отримати список студентів з прізвищем, яке починається з Bro.
            // Отримати список студентів, старших 19 років.
            // Отримати список студентів, старших 20 років і молодших 23 років.
            // Отримати список студентів, які навчаються в MIT.
            // Отримати список студентів, які навчаються в Oxford, і вік
            //яких старше 18 років. Результат відсортуйте за віком, за спаданням.

            Console.WriteLine($"Task 3\n");

            Student[] students = GetStudentArray();
            
            Console.WriteLine("all students:\n");
            Display(students);

            Console.WriteLine("boris name students:\n");
            var boris_students = students.Where(s => s.FirstName=="Boris");
            Display(boris_students);

            Console.WriteLine("contain bro students:\n");
            var contain_bro_students = students.Where(s => s.LastName.StartsWith("Bro"));
            Display(contain_bro_students);

            Console.WriteLine("more 19 old students:\n");
            var more_19_students = students.Where(s => s.Age >= 19);
            Display(more_19_students);

            Console.WriteLine("in range 20-23 old students:\n");
            var range_20_23_students = students.Where(s => s.Age >= 20 && s.Age <= 23);
            Display(range_20_23_students);

            Console.WriteLine("MIT educational students:\n");
            var mit_students = students.Where(s => s.Educational == "MIT");
            Display(mit_students);

            Console.WriteLine("Oxford educational students:\n");
            var oxford_students = students.Where(s => s.Educational == "Oxford" && s.Age >= 18).OrderByDescending(s => s.Age);
            Display(oxford_students);

            Console.WriteLine();

        }
        static void Display<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Educational { get; set; }

        public static ArrayList GetStudentArrayList()
        {
            ArrayList arrayList = new ArrayList();

            arrayList.Add(new Student { FirstName = "Walter", LastName = "White", Age = 20, Educational = "Oxford" });
            arrayList.Add(new Student { FirstName = "Jesse", LastName = "Pinkman", Age = 18, Educational = "Oxford" });
            arrayList.Add(new Student { FirstName = "Skyler", LastName = "White", Age = 21, Educational = "MIT" });
            arrayList.Add(new Student { FirstName = "Hank", LastName = "Schrader", Age = 25, Educational = "DEA" });
            arrayList.Add(new Student { FirstName = "Boris", LastName = "Schrader", Age = 18, Educational = "DEA" });
            arrayList.Add(new Student { FirstName = "Saul", LastName = "Goodman", Age = 15, Educational = "MIT" });
            arrayList.Add(new Student { FirstName = "Gustavo", LastName = "Fring", Age = 20, Educational = "Oxford" });
            arrayList.Add(new Student { FirstName = "Mike", LastName = "Bromantraut", Age = 20, Educational = "MIT" });
            arrayList.Add(new Student { FirstName = "Tuco", LastName = "Salamanca", Age = 22, Educational = "DEA" });

            return arrayList;
        }
        public static Student[] GetStudentArray()
        {
            ArrayList arrayList = GetStudentArrayList();
            return (Student[])arrayList.ToArray(typeof(Student));
        }
        public override string ToString()
        {
            return $"first name:\t\t{FirstName}\n"+
                    $"last name:\t\t{LastName}\n" +
                    $"age:\t\t\t{Age}\n" +
                    $"educational inst:\t{Educational}\n";
        }
    }
}

    


