using System.Security.Policy;
using System.Windows;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string result;
    Dictionary<int, string> ones = new()
    {
        {0, "զրո"},
        {1, "մեկ"},
        {2, "երկու"},
        {3, "երեք"},
        {4, "չորս"},
        {5, "հինգ"},
        {6, "վեց"},
        {7, "յոթ"},
        {8, "ութ"},
        {9, "իննը"},
    };

    Dictionary<int, string> tens = new()
    {
        {0, ""},
        {1, "սասն"},
        {2, "քսան "},
        {3, "երեսուն "},
        {4, "քառասուն "},
        {5, "հիսուն "},
        {6, "վաթսուն "},
        {7, "յոթանասուն "},
        {8, "ութսուն "},
        {9, "իննսուն "},
    };

    Dictionary<int, string> handrids = new()
    {
        {0, ""},
        {1, "հարյուր "},
        {2, "երկու հարյուր "},
        {3, "երեք հարյուր "},
        {4, "չորս հարյուր "},
        {5, "հինգ հարյուր "},
        {6, "վեց հարյուր "},
        {7, "յոթ հարյուր "},
        {8, "ութ հարյուր "},
        {9, "իննը հարյուր "},
    };

    Dictionary<int, string> thousands = new ()
    {
        {0, ""},
        {1, "հազար "},
        {2, "երկու հազար "},
        {3, "երեք հազար "},
        {4, "չորս հազար "},
        {5, "հինգ հազար "},
        {6, "վեց հազար "},
        {7, "յոթ հազար "},
        {8, "ութ հազար "},
        {9, "իննը հազար "},
    };
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var numberInText = textBox.Text;
        numberInText = numberInText.Trim().Replace(" ", "");
        if(numberInText.Length == 0)
        {
            result = "Մուտքագրեք թվանշանը";
            MessageBox.Show(result);
            return;
        }
        if(numberInText.Length > 4)
        {
            result = "Ծրագիրը դեո չի աշխատում 9999 թվից մեծ թվերի հետ";
            MessageBox.Show(result);
            return;
        }
        if(!numberInText.All(char.IsDigit))
        {
            result = "Մուտքագրեք միայն թվանշաններ";
            MessageBox.Show(result);
            return;
        }
        if(numberInText != "0" && numberInText.All(n => n == '0'))
        {
            result = "Այս տարբերակը ևս ստուգվում է :)";
            MessageBox.Show(result);
            return;
        }

        bool hasOnes = false;
        bool hasTens = false;
        bool hasHandrids = false; 
        bool hasThousands = false;
        if (numberInText.Length == 4)
        {
            hasOnes = true;
            hasTens = true;
            hasHandrids = true;
            hasThousands = true;
        }

        if (numberInText.Length >= 3)
        {
            hasOnes = true;
            hasTens = true;
            hasHandrids = true;
        }
        if (numberInText.Length >= 2)
        {
            hasOnes = true;
            hasTens = true;
        }
        if (numberInText.Length >=1)
        {
            hasOnes = true;
        }
        
        if(hasOnes)
        {
            result = GetOnes(numberInText[numberInText.Length - 1] - '0');
        }
        if(hasTens)
        {
            if(result == "զրո")
            {
                result = string.Empty;
            }
            result = GetTens(numberInText[numberInText.Length - 2] - '0', numberInText[numberInText.Length - 1] - '0') + result;
        }
        if (hasHandrids)
        {
            result = GetHandrids(numberInText[numberInText.Length - 3] - '0') + result;
        }
        if(hasThousands)
        {
            result = GetThousands(numberInText[numberInText.Length - 4] - '0') + result;
        }
        textBox.Text = numberInText;
        MessageBox.Show(result);
    }

    private void Joke_Button_Click(object sender, RoutedEventArgs e)
    {
        if(textBox.Text != "123")
        {
            result = "Մւտքագրեք 123";
        }
        else
        {
            result = "Հարյուր քսան երեք";
        }
        MessageBox.Show(result);
    }

    private string GetOnes(int el)
    {
        return ones[el];
    }

    private string GetTens(int el1, int el2)
    {
        if(el1 == 1 && el2 == 0)
        {
            return "տաս";
        }
        //if (el1 == 0)
        //    return "";
        return tens[el1];
    }

    private string GetHandrids(int el)
    {
        return handrids[el];
    }

    private string GetThousands(int el)
    {
        return thousands[el];
    }
}