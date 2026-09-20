using AutopesulaTellimused.Core;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
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
using System.Windows.Xps.Packaging;

namespace AutopesulaTellimused.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<WashOrder> _orders = new();
        private int _nextId = 1;
        public MainWindow()
        {
            InitializeComponent();

            OrdersDataGrid.ItemsSource = _orders;
            VehicleTypeComboBox.ItemsSource = Enum.GetValues<VehicleType>();
            WashProgramComboBox.ItemsSource= Enum.GetValues<WashProgram>();
        }

        private bool ValidateInput(out string plate, out VehicleType vehicle, out WashProgram program, int? currentOrderId = null)
        {
            StatusTextBlock.Text = string.Empty;
            plate = LicensePlateTextBox.Text.Replace(" ", "").ToUpper();
            vehicle = default;
            program = default;

            if (plate.Length < 2 || plate.Length > 10)
            {
                StatusTextBlock.Text = Properties.Resources.ErrInvalidPlate;
                return false;
            }

            string checkPlate = plate;

            bool isDuplicate = _orders.Any(o =>
                o.LicensePlate.Equals(checkPlate, StringComparison.OrdinalIgnoreCase) &&
                o.Id != currentOrderId);

            if (isDuplicate)
            {
                StatusTextBlock.Text = Properties.Resources.ErrDuplicatePlate;
                return false;
            }

            if (VehicleTypeComboBox.SelectedItem == null)
            {
                StatusTextBlock.Text = Properties.Resources.ErrSelectVehicle;
                return false;
            }

            if (WashProgramComboBox.SelectedItem == null)
            {
                StatusTextBlock.Text = Properties.Resources.ErrSelectProgram;
                return false;
            }

            vehicle = (VehicleType)VehicleTypeComboBox.SelectedItem;
            program = (WashProgram)WashProgramComboBox.SelectedItem;
            return true;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(!ValidateInput(out string plate, out VehicleType vehicle, out WashProgram program))
            {
                return;
            }

            WashOrder order = new WashOrder
            {
                Id = _nextId++,
                LicensePlate = plate,
                VehicleType = vehicle,
                WashProgram = program,
                Price = CarWashLogic.CalculatePrice(vehicle, program),
                DurationMinutes = CarWashLogic.CalculateDuration(vehicle, program)
            };

            _orders.Add(order);
            ClearInputs();
            UpdateTotals();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem is not WashOrder selectedOrder)
            {
                StatusTextBlock.Text = Properties.Resources.ErrSelectOrderToEdit;
                return;
            }

            if (!ValidateInput(out string plate, out VehicleType vehicle, out WashProgram program, selectedOrder.Id))
            {
                return;
            }

            selectedOrder.LicensePlate = plate;
            selectedOrder.VehicleType = vehicle;
            selectedOrder.WashProgram = program;
            selectedOrder.Price = CarWashLogic.CalculatePrice(vehicle, program);
            selectedOrder.DurationMinutes = CarWashLogic.CalculateDuration(vehicle, program);

            OrdersDataGrid.Items.Refresh();
            ClearInputs();
            UpdateTotals();   
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem is not WashOrder selectedOrder)
            {  
                StatusTextBlock.Text = Properties.Resources.ErrSelectOrderToDelete; 
                return; 
            }

            MessageBoxResult result = MessageBox.Show(
                Properties.Resources.ConfirmDelete,
                "Kustutamine",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                _orders.Remove(selectedOrder);
                ClearInputs();
                UpdateTotals();
            }
        }

        private void ClearInputs()
        {
            LicensePlateTextBox.Clear();
            VehicleTypeComboBox.SelectedIndex = -1;
            WashProgramComboBox.SelectedIndex = -1;
            OrdersDataGrid.UnselectAll();
            StatusTextBlock.Text = string.Empty;
        }

        private void UpdateTotals()
        {
            decimal totalPrice = _orders.Sum(o => o.Price);
            TotalScoreTextBlock.Text = $"Kokku tellimusi: {_orders.Count} | Kogusumma: {totalPrice:F2} €";
        }

        private void OrdersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem is WashOrder selectedOrder)
            {
                LicensePlateTextBox.Text = selectedOrder.LicensePlate;
                VehicleTypeComboBox.SelectedItem = selectedOrder.VehicleType;
                WashProgramComboBox.SelectedItem = selectedOrder.WashProgram;
                StatusTextBlock.Text = string.Empty;
            }
        }
    }
}