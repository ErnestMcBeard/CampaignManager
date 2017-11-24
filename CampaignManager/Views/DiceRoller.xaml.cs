using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CampaignManager.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
        }

        private void d4_Click(object sender, RoutedEventArgs e)
        {
            DiceBag bag = new DiceBag();
            string d4_resultValue = bag.Roll(DiceBag.Dice.D4).ToString();
        }

        private void d6_Click(object sender, RoutedEventArgs e)
        {
            DiceBag bag = new DiceBag();
            string d6_result = bag.Roll(DiceBag.Dice.D6).ToString();
        }

        private void d8_Click(object sender, RoutedEventArgs e)
        {
            DiceBag bag = new DiceBag();
            string d8_result = bag.Roll(DiceBag.Dice.D8).ToString();
        }

        private void d10_Click(object sender, RoutedEventArgs e)
        {
            DiceBag bag = new DiceBag();
            string d10_result = bag.Roll(DiceBag.Dice.D10).ToString();
        }

        private void d12_Click(object sender, RoutedEventArgs e)
        {
            DiceBag bag = new DiceBag();
            string d12_result = bag.Roll(DiceBag.Dice.D12).ToString();
        }

        private void d20_Click(object sender, RoutedEventArgs e)
        {
            DiceBag bag = new DiceBag();
            string d20_result = bag.Roll(DiceBag.Dice.D20).ToString();
        }

        private void d100_Click(object sender, RoutedEventArgs e)
        {
            DiceBag bag = new DiceBag();
            string d100_result = bag.Roll(DiceBag.Dice.D100).ToString();
        }

        private void d4_result_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    public class DiceBag
    {
        public enum Dice : uint
        {
            D4 = 4,
            D6 = 6,
            D8 = 8,
            D10 = 10,
            D12 = 12,
            D20 = 20,
            D100 = 100
        };

        private Random rng;

        public DiceBag()
        {
            rng = new Random();
        }

        private int InternalRoll(uint dice)
        {
            return 1 + rng.Next((int)dice);
        }

        public int Roll(Dice d)
        {
            return InternalRoll((uint)d);
        }

        public int RollWithModifier(Dice dice, uint modifier)
        {
            return InternalRoll((uint)dice) + (int)modifier;
        }

        public List<int> RollQuantity(Dice d, uint times)
        {
            List<int> rolls = new List<int>();
            for (int i = 0; i < times; i++)
            {
                rolls.Add(InternalRoll((uint)d));
            }
            return rolls;
        }
    }
}
