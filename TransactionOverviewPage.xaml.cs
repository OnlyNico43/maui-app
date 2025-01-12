namespace PayBuddy;

using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Linq;

    public partial class TransactionsOverviewPage : ContentPage
    {
        public ObservableCollection<Transaction> Transactions { get; set; }
        private ObservableCollection<Transaction> AllTransactions { get; set; }

        public TransactionsOverviewPage()
        {
            InitializeComponent();

            AllTransactions = new ObservableCollection<Transaction>
            {
                new Transaction { Amount = "- $11.15", AmountColor = Color.FromArgb("#F31260"), Description = "Coop Ryflihof" },
                new Transaction { Amount = "+ $9.20", AmountColor = Color.FromArgb("#17C964"), Description = "Money Received from H..." },
                new Transaction { Amount = "- $50.45", AmountColor = Color.FromArgb("#F31260"), Description = "Loeb Bern" },
                new Transaction { Amount = "- $21.95", AmountColor = Color.FromArgb("#F31260"), Description = "Sprüngli Bern HB" },
                new Transaction { Amount = "- $105.70", AmountColor = Color.FromArgb("#F31260"), Description = "Digitec Galaxus" },
                new Transaction { Amount = "+ $6537.25", AmountColor = Color.FromArgb("#17C964"), Description = "Swisscom (Schweiz) AG" },
            };

            Transactions = new ObservableCollection<Transaction>(AllTransactions);
            TransactionsCollectionView.ItemsSource = Transactions;
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchTerm = e.NewTextValue?.ToLower() ?? string.Empty;
            Transactions.Clear();

            foreach (var transaction in AllTransactions.Where(t => t.Description.ToLower().Contains(searchTerm)))
            {
                Transactions.Add(transaction);
            }
        }
    }

    public class Transaction
    {
        public string Amount { get; set; }
        public Color AmountColor { get; set; }
        public string Description { get; set; }
    }

