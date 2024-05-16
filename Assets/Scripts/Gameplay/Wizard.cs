using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int MessageBox(int hWnd, string text, string caption, int options);

    // shows a dialog with a message and a title
    public void ShowDialog(string title, string message)
    {
        MessageBox(0, message, title, 0);
    }

    // makes a text file on the desktop
    public void CreateTextFile(string name, string content)
    {
        System.IO.File.WriteAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\" + name, content);
    }
}
