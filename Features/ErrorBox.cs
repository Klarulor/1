using System.Windows;

namespace Task2.Features;

public static class ErrorBox
{
    public static void Show(string text)
    {
        MessageBox.Show(text);
    }
}