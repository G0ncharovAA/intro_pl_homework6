/*
* Урок 6. Двумерные массивы и рекурсия
*
* Задача 41: Пользователь вводит с клавиатуры M чисел. 
* Посчитайте, сколько чисел больше 0 ввёл пользователь.
*
* 0, 7, 8, -2, -2 -> 2
* 1, -7, 567, 89, 223-> 3
*
* Решение:
*/

double[] mapToInt(string[] strings)
{
    double[] numbers = new double[strings.Length];

    for (int i = 0; i < strings.Length; i++)
    {
        numbers[i] = Convert.ToDouble(strings[i]);
    }

    return numbers;
}

int countPositive(double[] numbers)
{
    int count = 0;
    foreach (var number in numbers)
    {
        if (number > 0)
        {
            count++;
        }
    }

    return count;
}

Console.WriteLine("Введите некоторое количаство(М) чисел, разделяя их пробелами");

string[] strNumbers = Console.ReadLine().Split(" ");

try
{
    double[] numbers = mapToInt(strNumbers);
    Console.WriteLine("Количество чисел больше 0: " + countPositive(numbers));
}
catch (Exception e)
{
    Console.WriteLine("Некорректное значение");
}

/*
* Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, 
* заданных уравнениями y = k1 * x + b1, y = k2 * x + b2;
* значения b1, k1, b2 и k2 задаются пользователем.
*
* b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)
*
* Решение:
*/

double calculateY(double x, double k, double b)
{
    return (k * x) + b;
}

/*
* Аналитически удалось вычислить, что 
* точка пересечения двух прямых буквально означает:
* 
* x1 = x2
* y1 = y2
*
* Тогда:
*
* k1 * x + b1 = k2 * x + b2
* (k1 * x) - (k2 * x) = b2 - b1
* x * (k1 - k2) = b2 - b1
* x = (b2 - b1) / (k1 - k2)
* y = k1 * x + b1 
*/

double findCrossingX(double k1, double b1, double k2, double b2)
{
    return (b2 - b2) / (k1 - k2);
}

Console.WriteLine("Введите коэффициент наклона первой линии, k1:");
double k1 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Введите слагаемое первой линии, b1:");
double b1 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Введите коэффициент наклона второй линии, k2:");
double k2 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Введите слагаемое второй линии, b2:");
double b2 = Convert.ToDouble(Console.ReadLine());

if (k1 == k2) // пренебрегаю здесь фактором точности чисел с плавающей точкой
{
    Console.WriteLine("Линии параллельны");
}
else
{
    double crossingX = findCrossingX(k1, b1, k2, b2);
    double crossingY = calculateY(crossingX, k1, b1);

    Console.WriteLine($"Точка пересечения имеет координаты {String.Format("{0:F2}", crossingX)} {String.Format("{0:F2}", crossingY)}");
}

/*
* Задача 42: Напишите программу, которая будет преобразовывать десятичное число в двоичное.
*
* 45 -> 101101
* 3 -> 11
* 2 -> 10
* 
* Решение: 
*/

string asBinary(int num)
{
    if (num == 1)
        return "1";
    else
        return asBinary(num / 2) + (num % 2);
}

Console.WriteLine("Введите десятичное число: ");
int num = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Двоичное представление числа: " + asBinary(num));

/*
* Задача 44: Не используя рекурсию, выведите первые N чисел Фибоначчи. 
* Первые два числа Фибоначчи: 0 и 1.
*
* Если N = 5 -> 0 1 1 2 3
* Если N = 3 -> 0 1 1
* Если N = 7 -> 0 1 1 2 3 5 8
*
* Решение:
*/

int nextFib(int prev, int prePrev)
{
    return prev + prePrev;
}

Console.WriteLine("Введите N - сколько чисел Фибоначчи показывать:");
int n = Convert.ToInt32(Console.ReadLine());

string fibs = "нет значений";
int prev = 1;
int prePrev = 0;
for (int i = 0; i < n; i++)
{
    if (i == 0)
    {
        fibs = "0";
    }
    else if (i == 1)
    {
        fibs += " 1";
    }
    else
    {
        int next = nextFib(prev, prePrev);
        fibs += $" {next}";
        prePrev = prev;
        prev = next;
    }
}

Console.WriteLine($"Первые {n} чисел Фибоначчи: {fibs}");

/*
* Задача 45: Напишите программу, которая будет создавать копию 
* заданного массива с помощью поэлементного копирования.
*/

// Тип элементов массива не указан. Это намёк на дженерики?
// А если общий тип Object, то как ввобдить массив таких объектов?
// Так или иначе, данных в задании явно недостаточно для выполнения.