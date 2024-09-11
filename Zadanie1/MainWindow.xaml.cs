using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zadanie1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
///

public class Card
{
    public string Color { get; set; }
    public string Value { get; set; }
}
public partial class MainWindow : Window
{
    private List<Image> images;
    private List<Card> actualCards = new List<Card>();


    public MainWindow()
    {
        InitializeComponent();

        images = new List<Image>()
        {
            CardImg1,
            CardImg2,
            CardImg3,
            CardImg4,
            CardImg5
        };
    }

    private void GenerateRandom(object sender, RoutedEventArgs e)
    {
        Random random = new Random();

        List<Card> actualCards = new List<Card>();

        for (int i = 0; i < images.Count; i++)
        {
            int index = random.Next(Cards.CardsList.Count);
            string cardPath = Cards.CardsList[index];
            BitmapImage bitmap = new BitmapImage(new Uri(cardPath, UriKind.Relative));
            images[i].Source = bitmap;

            string cardWithoutPath = cardPath.Split('/').Last();
            string cardWithoutPath2 = cardWithoutPath.Split('\\').Last();
            string[] cardInfo = cardWithoutPath2.Split('_');
            actualCards.Add(new Card()
            {
                Color = cardInfo[2].Split(".").First(),
                Value = cardInfo[0]
            });
        }

    }

    private void CheckCombination(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(PokerHandEvaluator.EvaluateHand(actualCards));
    }
}