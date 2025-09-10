**[View document in Syncfusion .NET MAUI Knowledge Base](https://www.syncfusion.com/kb/13176/how-to-highlight-the-tapped-view-in-itemtemplate-in-net-maui-listview-sflistview)**

## Sample

```xaml
ContentPage.Resources>
    <ResourceDictionary>
        <local:BackgroundColorConverter x:Key="backgroundColorConverter"/>
    </ResourceDictionary>
</ContentPage.Resources>

<ContentPage.Content>
    <syncfusion:SfListView x:Name="listView"  ItemSpacing="1" 
                        ItemSize="120" ItemsSource="{Binding contactsinfo}">
            <syncfusion:SfListView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Button x:Name="Button1" Margin="5" CornerRadius="15" Text="Busy" FontFamily="RobotoMedium" FontSize="15" BackgroundColor="{Binding Availability, Converter={StaticResource backgroundColorConverter}, ConverterParameter={x:Reference Button1}}" TextColor="Black" Grid.Column="1"/>
                        <Button x:Name="Button2" Margin="5" CornerRadius="15" Text="Available" FontFamily="RobotoMedium" FontSize="15" BackgroundColor="{Binding Availability, Converter={StaticResource backgroundColorConverter}, ConverterParameter={x:Reference Button2}}" TextColor="Black" Grid.Column="2"/>
                        <Button x:Name="Button3" Margin="5" CornerRadius="15" Text="Away" FontFamily="RobotoMedium" FontSize="15" BackgroundColor="{Binding Availability, Converter={StaticResource backgroundColorConverter}, ConverterParameter={x:Reference Button3}}" TextColor="Black" Grid.Column="3"/>
                    </Grid>
                </DataTemplate>
            </syncfusion:SfListView.ItemTemplate>
        </syncfusion:SfListView>
</ContentPage.Content>

C#:

Button1.Clicked += OnClicked;
Button2.Clicked += OnClicked;
Button3.Clicked += OnClicked;

private void OnClicked(object sender, EventArgs e)
{
    var button = sender as Button;
    var bc = button.BindingContext as Contacts;

    if (button.Text == "Available")
        bc.Availability = true;
    else if (button.Text == "Away")
        bc.Availability = false;
    else
        bc.Availability = null;
}

public class BackgroundColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var button = parameter as Button;

        if ((bool?)value == null && button.Text == "Busy")
            return Colors.Red;
        else if ((bool?)value == true && button.Text == "Available")
            return Colors.YellowGreen;
        else if ((bool?)value == false && button.Text == "Away")
            return Colors.Orange;
        else
            return Colors.Transparent;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```