static int[] bubbleSort(int[] array)
{
    int temp;

    for (int i=0;i < array.Length - 1; i++)
    {
        for (int j=0; j < array.Length - i - 1;j++)
        {
            if (array[j] > array[j + 1])
            {
                temp = array[j + 1];
                array[j + 1] = array[j];
                array[j] = temp;
            }
        }
    }
    return array;
}

int[] randomNumbers = { 123, 22, 53, 91, 787, 0, -23, 5 };

int[] sortedArray = bubbleSort(randomNumbers);

Console.WriteLine("Sorted:");
for (int i = 0; i < sortedArray.Length; i++)
{
    Console.Write(sortedArray[i] + " ");
}