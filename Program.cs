
void IncorrectValue() //Завершение программы, по причине введенного некорректного значения.
{
    Console.WriteLine("Введено некорректное значение");
    Environment.Exit(0);
}

void IncorrectStringArrayValue(string element) //Завершение работы, в случае "пропущенного элемента массива"
{
    if (element == string.Empty)
    {
        Console.WriteLine("Элемент исходного массива не должен быть пустым");
        IncorrectValue();
    }
}

int UserInput() // Проверка корректности введенного числа
{
    if (!int.TryParse(Console.ReadLine(), out int temp)) IncorrectValue();
    return temp;
}

string[] CreateArray(int size) // Создание первоначального массива с клавиатуры через консоль.
{
    string[] stringArray = new string[size];
    for (int i = 0; i < stringArray.Length; i++)
    {
        stringArray[i] = Console.ReadLine();
        IncorrectStringArrayValue(stringArray[i]);
    }
    return stringArray;
}

int SuitableElemsCount(string[] textArray) // Подсчет кол-ва элементов соответствующих условию (для определения длины нового массива).
{
    int count = 0;
    for (int i = 0; i < textArray.Length; i++)
    {
        if (textArray[i].Length <= 3) count++;
    }
    return count;
}

string[] NewThreeDigitsElementsArray(string[] textArray, int arraySize) // Создание нового массива из подходящих элементов.
{
    string[] newArray = new string[arraySize];
    int temp = 0;
    for (int i = 0; i < textArray.Length; i++)
    {
        if (textArray[i].Length <= 3)
        {
            newArray[temp] = textArray[i];
            temp++;
        }
    }
    return newArray;
}

void PrintArray(string[] resultArray) // Вывод массива в консоль (в соответствии с примерами).
{
    Console.Write("[");
    for (int i = 0; i < resultArray.Length; i++)
    {
        if (i < resultArray.Length - 1) Console.Write($"'{resultArray[i]}', ");
        else Console.Write($"'{resultArray[i]}'");
    }
    Console.Write("]");
}

Console.Write("Введите длину исходного массива: ");
int lengthForStartArray = UserInput();
if (lengthForStartArray <= 0) IncorrectValue();
Console.WriteLine(string.Empty);
Console.WriteLine("Введите элементы массива в формате один элемент - одна строка. Пример: "
+ "\r\nExample1"
+ "\r\nexamp2"
+ "\r\n1243"
+ "\r\n1+18"
+ "\r\n:D"
+ "\r\n....");
Console.WriteLine("Введите элементы исходного массива: ");
string[] startArray = CreateArray(lengthForStartArray);
int newArraySize = SuitableElemsCount(startArray);
string[] result = NewThreeDigitsElementsArray(startArray, newArraySize);
Console.WriteLine(string.Empty);
Console.WriteLine("Результат:");
PrintArray(startArray);
Console.Write(" -> ");
PrintArray(result);
